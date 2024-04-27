using EJFilter.Models;
using EJFilter.Models.Entity;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EJFilter.Scheduler
{

    public class ThreadManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static List<string> allLinesText;
        private static List<int> rowIndexList;
        private static List<string> rowFieldList;
        private static List<string> rowSIList;
        private static List<HistMain> missingTransList;
        private string RegisterNum;
        private ConfigurationVM RMConfig;
        private DateTime TranDate;
        private bool hasMissing;
        private EJFilterContextDB db;

        public ThreadManager(List<HistMain> missingList, string registerNum, bool HasMissing, ConfigurationVM rmConfig, EJFilterContextDB _db)
        {
            missingTransList = missingList;
            RegisterNum = registerNum;
            TranDate = Convert.ToDateTime("07/22/2022");
            RMConfig = rmConfig;
            hasMissing = HasMissing;
            db = _db;
        }

        public void Run()
        {
            //using (var db = new EJFilterContextDB())
            //{
            db.Database.CommandTimeout = 0;
            Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Generate Missing Transaction to Journal List Ends");
            log.Info($"Generate Missing Transaction to Journal List Ends");

            log.Info($"Regenerate Receipt File Starts");
            Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Regenerate Receipt File Starts");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            string fileName = $"{TranDate:yyMMdd}{RegisterNum.PadLeft(2, '0').Trim()}.prn";
            string filePath = RMConfig.OriginalEJFolderPath;
            List<CustomReadingInfo> readingList = new List<CustomReadingInfo>();

            if (File.Exists($"{filePath}{fileName}"))
            {
                #region ========== Read Original Receipt File 23043002==========
                allLinesText = File.ReadAllLines($"{filePath}{fileName}").ToList();
                rowIndexList = new List<int>();
                rowFieldList = new List<string>();
                rowSIList = new List<string>();

                var lastTransNumber = "";
                int index = 0;
                string CashierCode = "";

                List<string> rowField = new List<string>();

                #region ======== Read All SI# ========
                foreach (var salesInvoice in allLinesText)
                {
                    if (salesInvoice.Contains("SI# "))
                        rowSIList.Add(salesInvoice.Split('#')[1]);
                }


                var resultGroup = rowSIList.GroupBy(n => n)
                        .Select(c => new { Key = c.Key, total = c.Count() });

                if (resultGroup.Any(x => x.total > 1))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"==============================================================");
                    Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Has Duplicate Transaction");

                    foreach (var items in resultGroup.Where(x => x.total > 1))
                    {
                        Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Transaction #{items.Key.Replace("1C", "")}");
                    }
                }


                #endregion


                #region ======== Read X-Reading =========
                foreach (var items in allLinesText)
                {
                    if (items.Contains("X-READING"))
                        rowIndexList.Add(index);

                    index++;
                }

                int rowIndex = 1;
                // get previous information of x-reading
                foreach (var rowNumber in rowIndexList)
                {
                    lastTransNumber = "";
                    for (int j = rowNumber; j > 0; j--)
                    {
                        if (allLinesText[j].Contains("Trans#"))
                        {
                            //Console.WriteLine("-------------------");
                            //Console.WriteLine("Last Transaction: " + allLinesText[j]);
                            //Console.WriteLine("-------------------");
                            lastTransNumber = allLinesText[j].Split('#')[1];
                            CashierCode = allLinesText[j + 1].Substring(34, 8);
                            break;

                        }
                    }

                    for (int i = rowNumber - 8; i < rowNumber; i++)
                    {
                        //  Console.WriteLine(allLinesText[i]);
                        readingList.Add(new CustomReadingInfo
                        {
                            RowField = allLinesText[i],
                            LastTransact = Regex.Replace(lastTransNumber, @"\s", ""),
                            LastXReading = rowIndex == rowIndexList.Count ? true : false,
                            ReadingType = "X",
                            CashierCode = CashierCode,
                        }); ;

                        rowFieldList.Add(allLinesText[i]);
                    }

                    for (int i = rowNumber; i < allLinesText.Count; i++)
                    {
                        if (allLinesText[i] == "******************************************")
                        {
                            //  Console.WriteLine(allLinesText[i]);
                            readingList.Add(new CustomReadingInfo
                            {
                                RowField = allLinesText[i],
                                LastTransact = Regex.Replace(lastTransNumber, @"\s", ""),
                                LastXReading = rowIndex == rowIndexList.Count ? true : false,
                                ReadingType = "X",
                                CashierCode = CashierCode,
                            });
                            rowFieldList.Add(allLinesText[i]);
                            //  Console.WriteLine(allLinesText[i + 1]);
                            readingList.Add(new CustomReadingInfo
                            {
                                RowField = allLinesText[i + 1],
                                LastTransact = Regex.Replace(lastTransNumber, @"\s", ""),
                                LastXReading = rowIndex == rowIndexList.Count ? true : false,
                                ReadingType = "X",
                                CashierCode = CashierCode,
                            });

                            rowFieldList.Add(allLinesText[i + 1]);
                            break;
                        }
                        else
                        {
                            //  Console.WriteLine(allLinesText[i]);
                            readingList.Add(new CustomReadingInfo
                            {
                                RowField = allLinesText[i],
                                LastTransact = Regex.Replace(lastTransNumber, @"\s", ""),
                                LastXReading = rowIndex == rowIndexList.Count ? true : false,
                                ReadingType = "X",
                                CashierCode = CashierCode,
                            });

                            rowFieldList.Add(allLinesText[i]);
                        }
                    }
                    rowIndex++;
                    // Console.WriteLine("===============================================");

                }
                #endregion

                #region ======== Read Z-Reading ========

                //Console.WriteLine("===================== Z-Reading ==========================");

                index = 0;
                rowIndexList = new List<int>();
                rowIndex = 1;
                foreach (var items in allLinesText)
                {
                    if (items.Contains("Z-READING"))
                        rowIndexList.Add(index);

                    index++;
                }

                foreach (var rowNumber in rowIndexList)
                {
                    for (int i = rowNumber - 9; i < rowNumber; i++)
                    {
                        //  Console.WriteLine(allLinesText[i]);
                        readingList.Add(new CustomReadingInfo
                        {
                            RowField = allLinesText[i],
                            LastTransact = "",
                            LastXReading = false,
                            ReadingType = "Z"
                        });

                        rowFieldList.Add(allLinesText[i]);
                    }

                    for (int i = rowNumber; i < allLinesText.Count; i++)
                    {
                        if (allLinesText[i] == "******************************************")
                        {
                            // Console.WriteLine(allLinesText[i]);
                            readingList.Add(new CustomReadingInfo
                            {
                                RowField = allLinesText[i],
                                LastTransact = "",
                                LastXReading = false,
                                ReadingType = "Z"
                            });

                            rowFieldList.Add(allLinesText[i]);

                            //  Console.WriteLine(allLinesText[i + 1]);
                            readingList.Add(new CustomReadingInfo
                            {
                                RowField = allLinesText[i + 1],
                                LastTransact = "",
                                LastXReading = false,
                                ReadingType = "Z"
                            });

                            rowFieldList.Add(allLinesText[i + 1]);
                            break;
                        }
                        else
                        {
                            //  Console.WriteLine(allLinesText[i]);
                            readingList.Add(new CustomReadingInfo
                            {
                                RowField = allLinesText[i],
                                LastTransact = "",
                                LastXReading = false,
                                ReadingType = "Z"
                            });

                            rowFieldList.Add(allLinesText[i]);
                        }
                    }
                    rowIndex++;
                }

                #endregion

                #endregion

            }

            var generateResult = db.Database.SqlQuery<int>($"exec RPT_RECEIPT_SCHEDULER '{TranDate}','{RegisterNum}'").ToList();


            if (generateResult.FirstOrDefault() == 1 && hasMissing)
            {
                var receiptDetailList = db.Database.SqlQuery<ReceiptDetailInfo>($"exec SCHD_GET_RECEIPT_DETAIL '{TranDate}', '{RegisterNum.Trim()}'").ToList();

                if (receiptDetailList.Any())
                {
                    log.Info($"Regenerate Receipt for {fileName}");
                    Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Create File {fileName} starts");
                    int readIndex = 0;
                    using (StreamWriter writer = new StreamWriter($"{RMConfig.GenerateEJFolderPath}{fileName}"))
                    {
                        foreach (var itemLine in receiptDetailList)
                        {

                            if (readingList.Any(x => x.LastTransact == itemLine.Transact))
                            {
                                foreach (var lastTransaction in receiptDetailList.Where(x => x.Transact == itemLine.Transact))
                                    writer.WriteLine(lastTransaction.ReceiptDetail);

                                if (readIndex < receiptDetailList.Count - 1)
                                {
                                    if (receiptDetailList[readIndex + 1].Cashier == itemLine.Cashier)
                                    {
                                        foreach (var item1 in readingList.Where(x => x.LastTransact == itemLine.Transact))
                                        {
                                            item1.LastTransact = receiptDetailList[readIndex + 1].Transact;
                                        }
                                    }
                                }

                                writer.WriteLine("");
                                writer.WriteLine("");
                                writer.WriteLine("");

                                foreach (var receiptDtl in readingList.Where(x => x.LastTransact == itemLine.Transact))
                                    writer.WriteLine(receiptDtl.RowField);

                                writer.WriteLine("");
                                writer.WriteLine("");
                                writer.WriteLine("");
                            }
                            else
                                writer.WriteLine(itemLine.ReceiptDetail);

                            readIndex++;
                        }

                        foreach (var receiptDtl in readingList.Where(x => x.ReadingType == "Z"))
                            writer.WriteLine(receiptDtl.RowField);
                    }

                    // System.IO.File.WriteAllLines($"C:\\GeneratedVOQBPS\\{fileName}", receiptDetailList);

                    Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Create File {fileName} ends");
                }


                stopwatch.Stop();
                log.Info($"Time Taken : {stopwatch.Elapsed.Hours} hr: {stopwatch.Elapsed.Minutes} min: {stopwatch.Elapsed.Seconds} sec: {stopwatch.Elapsed.Milliseconds} ms");
                log.Info($"Regenerate Receipt File End - Execute Time: {stopwatch.ElapsedMilliseconds}");

            }
            else
            {
                var receiptDetailList = db.Database.SqlQuery<ReceiptDetailInfo>($"exec SCHD_GET_RECEIPT_DETAIL '{TranDate}', '{RegisterNum.Trim()}'").ToList();

                if (receiptDetailList.Any())
                {
                    log.Info($"Regenerate Receipt for {fileName}");
                    Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Create File {fileName} starts");
                    int readIndex = 0;
                    using (StreamWriter writer = new StreamWriter($"{RMConfig.GenerateEJFolderPath}{fileName}"))
                    {
                        foreach (var itemLine in receiptDetailList)
                        {

                            if (readingList.Any(x => x.LastTransact == itemLine.Transact))
                            {
                                foreach (var lastTransaction in receiptDetailList.Where(x => x.Transact == itemLine.Transact))
                                    writer.WriteLine(lastTransaction.ReceiptDetail);

                                if (readIndex < receiptDetailList.Count - 1)
                                {
                                    if (receiptDetailList[readIndex + 1].Cashier == itemLine.Cashier)
                                    {
                                        foreach (var item1 in readingList.Where(x => x.LastTransact == itemLine.Transact))
                                        {
                                            item1.LastTransact = receiptDetailList[readIndex + 1].Transact;
                                        }
                                    }
                                }

                                writer.WriteLine("");
                                writer.WriteLine("");
                                writer.WriteLine("");

                                foreach (var receiptDtl in readingList.Where(x => x.LastTransact == itemLine.Transact))
                                    writer.WriteLine(receiptDtl.RowField);

                                writer.WriteLine("");
                                writer.WriteLine("");
                                writer.WriteLine("");
                            }
                            else
                                writer.WriteLine(itemLine.ReceiptDetail);

                            readIndex++;
                        }

                        foreach (var receiptDtl in readingList.Where(x => x.ReadingType == "Z"))
                            writer.WriteLine(receiptDtl.RowField);
                    }

                    // System.IO.File.WriteAllLines($"C:\\GeneratedVOQBPS\\{fileName}", receiptDetailList);

                    Console.WriteLine($"{DateTime.Now:MM/dd/yyyy HH:mm:ss:ms} - Create File {fileName} ends");
                }


                stopwatch.Stop();
                log.Info($"Time Taken : {stopwatch.Elapsed.Hours} hr: {stopwatch.Elapsed.Minutes} min: {stopwatch.Elapsed.Seconds} sec: {stopwatch.Elapsed.Milliseconds} ms");
                log.Info($"Regenerate Receipt File End - Execute Time: {stopwatch.ElapsedMilliseconds}");
            }
            //}


        }
    }
}
