using CsvHelper;
using EJFilter.Models;
using EJFilter.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EJFilter.Scheduler
{

    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public  ConfigurationVM RMConfig = null;

        public Program()
        {
            RMConfig = GetConfiguration();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter company branch code CCCbbbb");
            var companyBranch = Console.ReadLine();
            Console.WriteLine("Please enter company branch code CCCbbbb");
            var tranDate = Console.ReadLine();
            using (var dbCommon = new EJCommonDBContext())
            {
                var scheduleList = dbCommon.ScheduleSettings.Where(x => x.RunningStatus == 0).Take(5).ToList();

                foreach (var schedule in scheduleList)
                {
                    var dbData = dbCommon.DBSettings.FirstOrDefault(x => x.Id == schedule.DBId);

                    if (dbData != null)
                    {
                        var connectionString = $"Server={dbData.DataSource};Database={dbData.InitialCatalog};User Id={dbData.UserID};Password={dbData.Password};multipleactiveresultsets=True;application name=EntityFramework";

                        var db = new EJFilterContextDB(connectionString);

                        RunFunction(db,Convert.ToDateTime(tranDate));
                    }
                }
            }

            

#if DEBUG
            Console.WriteLine("Press enter to close...");
                Console.ReadLine();
#endif
           // }
        }


        public static void RunFunction( EJFilterContextDB db, DateTime TranDate)
        {
            Program obj = new Program();
            //DateTime TranDate = Convert.ToDateTime("07/22/2022");

            log4net.Config.XmlConfigurator.Configure();

            log.Info("EJ Filter Scheduler Starts Running");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            db.Database.CommandTimeout = 0;
            log.Info("Application Starts");
            log.Info($"Execuation Date:{DateTime.Now:yyyy-MM-dd HH:mm:ss:ms}");

            Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Application Starts");
            Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Transaction Date: {DateTime.Now.ToShortDateString()}");
            #region ========== Check Duplicate Transaction / SI# ==========

            List<string> fileLineText = new List<string>();
            List<string> salesInvoiceList = new List<string>();
            List<HistMain> missingTransList = new List<HistMain>();

            string EJFolderPath = obj.RMConfig.OriginalEJFolderPath;

            // Get All POS# List in HistMain
            SqlParameter[] parameter =
            {
                new SqlParameter ("@TranDate",TranDate)
            };


            var registerIdList = db.Database.SqlQuery<int>("Exec RPT_GET_DISTINCT_REGISTER_ID @TranDate", parameter).ToList();
            SqlParameter[] parameters =
            {
                   
                new SqlParameter ("@ScheduleDate",TranDate)
            };

            missingTransList = db.Database.SqlQuery<HistMain>("exec SCHD_GET_MISSING_TRANSACTION @ScheduleDate", parameters).ToList();

            if (registerIdList.Any())
            {


                foreach (var item in registerIdList)
                {
                    //string fileName = $"{item.TranDate:yyMMdd}{item.ToString().PadLeft(2, '0')}.prn";
                    string fileName = $"{TranDate:yyMMdd}{item.ToString().PadLeft(2, '0')}.prn";
                    if (File.Exists($"{EJFolderPath}{fileName}"))
                    {
                        fileLineText = File.ReadAllLines($"{EJFolderPath}{fileName}").ToList();
                        int row = 0;
                        fileLineText.ForEach(delegate (string readline)
                        {
                            if (readline.Contains("SI# "))
                            {
                                salesInvoiceList.Add(readline.Split('#')[1] + "!" + fileLineText[row + 1].Split('#')[1] + "!" + fileLineText[row + 2].Substring(1, 10));
                            }

                            row++;
                        });
                    }

                }

                //check if there is duplicate SI

                var duplicates = salesInvoiceList
                    .GroupBy(i => i)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key);

                //02-00017211\u001b|1C
                foreach (var d in duplicates)
                {
                    Console.WriteLine(d.Substring(1, 11) + "!" + d.Split('!')[1]); // 4,3
                    missingTransList.Add(new HistMain
                    {
                        Register = d.Split('!')[0].Split('-')[0],
                        Branch = d.Split('!')[1].Substring(1, 4),
                        SalesInvoice = $"SI#{d.Substring(1, 11)}",
                        Transact = $"{d.Split('!')[1].Trim().Split(' ')[0]}{d.Split('!')[1].Trim().Split(' ')[1]}",
                        TranDate = Convert.ToDateTime(d.Split('!')[2]),
                        IsDuplicate = "Y"

                    }); ;
                }
            }

            #endregion



            if (missingTransList.Any())
            {



                log.Info($"Show Missing Transactions");
                log.Info($"===============================================");
                Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Show Missing Transactions ");
                using (var textWriter = new StreamWriter($"{obj.RMConfig.GenerateEJFolderPath}FRG.EJFilterExceptionLogs_{DateTime.Now:MMddyyyyHHmmss}.csv"))
                {
                    var writer = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

                    writer.WriteField("Transaction Date");
                    writer.WriteField("POS Number");
                    writer.WriteField("Skip/Missing Sales Invoice Number");
                    writer.NextRecord();
                    foreach (var item in missingTransList.Where(x => x.IsDuplicate == "N"))
                    {
                        log.Info($"Register: {item.Register} , Transaction: {item.Transact} ");
                        Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Register: {item.Register} , Transaction: {item.Transact} ");

                        writer.WriteField(item.TranDate.ToString("MMMM dd, yyyy"));
                        writer.WriteField($"POS {item.Register}");
                        writer.WriteField(item.SalesInvoice);
                        writer.NextRecord();
                    }
                }

                log.Info($"===============================================");
                log.Info($"Generate Missing Transaction to Journal List Starts");
                Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Generate Missing Transaction to Journal List Starts");

                var getMissingRegisterList = missingTransList.Where(x => x.HasMissing == true).Select(x => x.Register).Distinct().ToList();

                if (getMissingRegisterList.Any())
                {
                    foreach (var item in getMissingRegisterList)
                    {
                        missingTransList.RemoveAll(x => x.Register == item && x.HasMissing == false);
                    }
                }


                ThreadManager threadManager = null;
                foreach (var register in missingTransList.Select(X => X.Register).Distinct())
                {
                    Console.WriteLine(register);
                    var hasMissing = missingTransList.FirstOrDefault(x => x.Register == register).HasMissing;
                    threadManager = new ThreadManager(missingTransList.Where(x => x.Register == register).ToList(), register, hasMissing, obj.RMConfig,db);

                    Thread newThread = new Thread(new ThreadStart(threadManager.Run));

                    newThread.Start();
                }


            }
            else
            {

                foreach (var item in registerIdList)
                {
                    //string fileName = $"{item.TranDate:yyMMdd}{item.ToString().PadLeft(2, '0')}.prn";
                    string fileName = $"{TranDate:yyMMdd}{item.ToString().PadLeft(2, '0')}.prn";
                    SqlParameter[] parameters2 =
                       {
                                new SqlParameter ("@TranDate",TranDate),
                                new SqlParameter ("@Register", item.ToString("00"))
                            };

                    var receiptDetailList = db.Database.SqlQuery<ReceiptDetailInfo>("exec SCHD_GET_RECEIPT_DETAIL @TranDate, @Register", parameters2).ToList();

                    if (receiptDetailList.Any())
                    {
                        log.Info($"Regenerate Receipt for {fileName}");
                        Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Create File {fileName} starts");
                        int readIndex = 0;
                        using (StreamWriter writer = new StreamWriter($"{obj.RMConfig.GenerateEJFolderPath}{fileName}"))
                        {
                            foreach (var itemLine in receiptDetailList)
                            {
                                writer.WriteLine(itemLine.ReceiptDetail);
                                readIndex++;
                            }
                        }
                        Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Create File {fileName} ends");
                    }
                }
            }

        }

        public ConfigurationVM GetConfiguration()
        {
            log.Info("GetConfiguration::Start");
            ConfigurationVM RMConfig = new ConfigurationVM();
            try
            {
                RMConfig.OriginalEJFolderPath = ConfigurationManager.AppSettings.Get("OriginalEJFolderPath");
                RMConfig.GenerateEJFolderPath = ConfigurationManager.AppSettings.Get("GenerateEJFolderPath");
                RMConfig.FTPUrl = ConfigurationManager.AppSettings.Get("FTPURL");
            }
            catch (Exception ex)
            {
                log.Error("GetConfiguration::Error::", ex);
            }
            log.Info("GetConfiguration::End");
            return RMConfig;
        }


    }
}
