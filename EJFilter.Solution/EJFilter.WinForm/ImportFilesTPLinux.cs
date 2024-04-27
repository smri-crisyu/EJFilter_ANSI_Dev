using EJFilter.Models.Entity;
using EJFilter.Service;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace EJFilter.WinForm
{
    public partial class ImportFilesTPLinux : Form
    {
        ImportTPFilesServices ImportTPFilesSrv;
        ImportTPFiles ImportTPFilesData;

        public ImportFilesTPLinux()
        {
            InitializeComponent();
            ImportTPFilesData = new ImportTPFiles();
            ImportTPFilesSrv = new ImportTPFilesServices();
           // ImportTPFilesList = new List<ImportTPFiles>();

        }
        private void RefreshBrowseFileName()
        {
            Filename.Text = "Filename";
        }
        private void BrowseFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Select Valid Document(*.csv)|*.csv";
            openFileDialog.FilterIndex = 1;
            try
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFileName(openFileDialog.FileName);
                        Filename.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UploadDocBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.IO.Path.GetFullPath(openFileDialog.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    DataTable csvData = new DataTable();
                    using (TextFieldParser csvReader = new TextFieldParser(filename))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            //Making empty value as null
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                                /*if (i == 19)
                                {
                                    string path = Filename.Text;
                                    fieldData[i] = File.ReadAllText(path);
                                }*/


                            }
                            csvData.Rows.Add(fieldData);

                        }
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EJContext"].ToString()))
                        {
                            conn.Open();
                            using (SqlBulkCopy s = new SqlBulkCopy(conn))
                            {
                                s.DestinationTableName = "TPLINUX_FILES";
                                foreach (var column in csvData.Columns)
                                {
                                    s.ColumnMappings.Add(column.ToString(), column.ToString());
                                }
                                
                                s.WriteToServer(csvData);
                                MessageBox.Show("Successfully Imported Data");
                            }
                            this.RefreshBrowseFileName();
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
