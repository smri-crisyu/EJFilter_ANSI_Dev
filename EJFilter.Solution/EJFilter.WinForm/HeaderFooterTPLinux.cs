using EJFilter.Models.Entity;
using EJFilter.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJFilter.WinForm
{
    public partial class HeaderFooterTPLinux : Form
    {
        int selectedRow;
        CompanyServices CompanySrv;
        BranchServices BranchSrv;
        StoreServices StoreSrv;
        ConfigTypeServices ConfigSrv;
        POSServices POSSrv;

        HeaderFooterTPServices HeaderFooterSrv;
        HeaderFooterFormatServices HeaderFooterFormatSrv;

        List<HeaderFooterTP> HeaderFooterTPList;

        HeaderFooterTP HeaderFooterTPData;
        HeaderFooterTPFormat HeaderFooterFormatData;

        public HeaderFooterTPLinux()
        {
            InitializeComponent();
            HeaderFooterSrv = new HeaderFooterTPServices();
            HeaderFooterTPData = new HeaderFooterTP();
            HeaderFooterFormatData = new HeaderFooterTPFormat(); 

            CompanySrv = new CompanyServices();
            BranchSrv = new BranchServices();
            StoreSrv = new StoreServices();
            ConfigSrv = new ConfigTypeServices();

            HeaderFooterTPList = new List<HeaderFooterTP>();

            LoadData();
            LoadStoreCode();
            LoadBranchCode();
            LoadCompany();
            LoadConfigType();
        }
        private void LoadData()
        {
            var showDetail = HeaderFooterSrv.GetAll();
            //var showDetails = HeaderFooterFormatSrv.GetAll();

            //List<HeaderFooterTPFormat> headerFooterTPFormats = new List<HeaderFooterTPFormat>();

            dataGridView1.DataSource = showDetail;
            HeaderFooterTPList = showDetail;
            //headerFooterTPFormats.AddRange(showDetails);
        }

        private void LoadStoreCode()
        {
            StoreCmb.DataSource = StoreSrv.GetAll();
            StoreCmb.DisplayMember = "StoreName";
            StoreCmb.ValueMember = "StoreCode";

        }

        private void LoadBranchCode()
        {
            BranchCmb.DataSource = BranchSrv.GetAll();
            BranchCmb.DisplayMember = "BranchName";
            BranchCmb.ValueMember = "BranchCode";

        }

        private void LoadCompany()
        {
            CompanyCmb.DataSource = CompanySrv.GetAll();
            CompanyCmb.DisplayMember = "CompanyName";
            CompanyCmb.ValueMember = "CompanyName";

        }
        private void LoadConfigType()
        {
            TypeCmb.DataSource = ConfigSrv.GetAll();
            TypeCmb.DisplayMember = "ConfigName";
            TypeCmb.ValueMember = "Type";

        }

        private void ClearItems()
        {
            Address1Txt.Clear();
            Address2Txt.Clear();
            Address3Txt.Clear();
            ZipLocTxt.Clear();
            ZipCodeTxt.Clear();
            VatRegTin_HTxt.Clear();
            SerialNoTxt.Clear();
            MinNoTxt.Clear();
            PTUNoTxt.Clear();
            VatRegTin_FTxt.Clear();
            AccrNoTxt.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            BranchCmb.SelectedValue = HeaderFooterTPList[selectedRow].BranchCode;
            StoreCmb.SelectedValue = HeaderFooterTPList[selectedRow].StoreCode;
            TypeCmb.SelectedValue = HeaderFooterTPList[selectedRow].Type;
            CompanyCmb.SelectedValue = HeaderFooterTPList[selectedRow].Company;
            Address1Txt.Text = HeaderFooterTPList[selectedRow].Address1;
            Address2Txt.Text = HeaderFooterTPList[selectedRow].Address2;
            Address3Txt.Text = HeaderFooterTPList[selectedRow].Address3;
            ZipLocTxt.Text = HeaderFooterTPList[selectedRow].ZipLocation;
            ZipCodeTxt.Text = HeaderFooterTPList[selectedRow].ZipCode;
            VatRegTin_HTxt.Text = HeaderFooterTPList[selectedRow].VatRegTin_H;
            SerialNoTxt.Text = HeaderFooterTPList[selectedRow].SerialNo;
            MinNoTxt.Text = HeaderFooterTPList[selectedRow].MinNo;
            PTUNoTxt.Text = HeaderFooterTPList[selectedRow].PTUNo;
            VatRegTin_FTxt.Text = HeaderFooterTPList[selectedRow].VatRegTin_F;
            AccrNoTxt.Text = HeaderFooterTPList[selectedRow].AccrNo;
            DateFrom.Text = HeaderFooterTPList[selectedRow].DateFrom.ToString();
            DateTo.Text = HeaderFooterTPList[selectedRow].DateTo.ToString();

            HeaderFooterTPData = HeaderFooterTPList[selectedRow];
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            HeaderFooterTPData = new HeaderFooterTP();


            HeaderFooterTPData.BranchCode = Convert.ToInt32(BranchCmb.SelectedValue);
            HeaderFooterTPData.StoreCode = Convert.ToInt32(StoreCmb.SelectedValue);
            HeaderFooterTPData.Type = TypeCmb.SelectedValue.ToString();
            HeaderFooterTPData.Company = CompanyCmb.SelectedValue.ToString();
            HeaderFooterTPData.Address1 = Address1Txt.Text;
            HeaderFooterTPData.Address2 = Address2Txt.Text;
            HeaderFooterTPData.Address3 = Address3Txt.Text;
            HeaderFooterTPData.ZipLocation = ZipLocTxt.Text;
            HeaderFooterTPData.ZipCode = ZipCodeTxt.Text;
            HeaderFooterTPData.VatRegTin_H = VatRegTin_HTxt.Text;
            HeaderFooterTPData.SerialNo = SerialNoTxt.Text;
            HeaderFooterTPData.MinNo = MinNoTxt.Text;
            HeaderFooterTPData.PTUNo = PTUNoTxt.Text;
            HeaderFooterTPData.VatRegTin_F = VatRegTin_FTxt.Text;
            HeaderFooterTPData.AccrNo = AccrNoTxt.Text;
            HeaderFooterTPData.AccrNo2 = AccrNo2Txt.Text;
            HeaderFooterTPData.DateFrom = Convert.ToDateTime(DateFrom.Value.ToShortDateString());
            HeaderFooterTPData.DateTo = Convert.ToDateTime(DateTo.Value.ToShortDateString());


            var result = HeaderFooterSrv.Add(HeaderFooterTPData);

            if (result.Success)
            {
                MessageBox.Show($"Successfully Created");
                LoadData();
                ClearItems();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            if (HeaderFooterTPData != null)
            {

                HeaderFooterTPData.BranchCode = Convert.ToInt32(BranchCmb.SelectedValue);
                HeaderFooterTPData.StoreCode = Convert.ToInt32(StoreCmb.SelectedValue);
                HeaderFooterTPData.Type = TypeCmb.SelectedValue.ToString();
                HeaderFooterTPData.Company = CompanyCmb.SelectedValue.ToString();
                HeaderFooterTPData.Address1 = Address1Txt.Text;
                HeaderFooterTPData.Address2 = Address2Txt.Text;
                HeaderFooterTPData.Address3 = Address3Txt.Text;
                HeaderFooterTPData.ZipLocation = ZipLocTxt.Text;
                HeaderFooterTPData.ZipCode = ZipCodeTxt.Text;
                HeaderFooterTPData.VatRegTin_H = VatRegTin_HTxt.Text;
                HeaderFooterTPData.SerialNo = SerialNoTxt.Text;
                HeaderFooterTPData.MinNo = MinNoTxt.Text;
                HeaderFooterTPData.PTUNo = PTUNoTxt.Text;
                HeaderFooterTPData.VatRegTin_F = VatRegTin_FTxt.Text;
                HeaderFooterTPData.AccrNo = AccrNoTxt.Text;
                HeaderFooterTPData.AccrNo2 = AccrNo2Txt.Text;
                HeaderFooterTPData.DateFrom = DateFrom.Value.AddDays(0);
                HeaderFooterTPData.DateTo = DateTo.Value.AddDays(0);


                var updateResult = HeaderFooterSrv.Update(HeaderFooterTPData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Successfully Updated");
                    LoadData();
                    ClearItems();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (HeaderFooterTPData != null)
            {

                HeaderFooterTPData.BranchCode = Convert.ToInt32(BranchCmb.SelectedValue);
                HeaderFooterTPData.StoreCode = Convert.ToInt32(StoreCmb.SelectedValue);
                HeaderFooterTPData.Type = TypeCmb.SelectedValue.ToString();
                HeaderFooterTPData.Company = CompanyCmb.SelectedValue.ToString();
                HeaderFooterTPData.Address1 = Address1Txt.Text;
                HeaderFooterTPData.Address2 = Address2Txt.Text;
                HeaderFooterTPData.Address3 = Address3Txt.Text;
                HeaderFooterTPData.ZipLocation = ZipLocTxt.Text;
                HeaderFooterTPData.ZipCode = ZipCodeTxt.Text;
                HeaderFooterTPData.VatRegTin_H = VatRegTin_HTxt.Text;
                HeaderFooterTPData.SerialNo = SerialNoTxt.Text;
                HeaderFooterTPData.MinNo = MinNoTxt.Text;
                HeaderFooterTPData.PTUNo = PTUNoTxt.Text;
                HeaderFooterTPData.VatRegTin_F = VatRegTin_FTxt.Text;
                HeaderFooterTPData.AccrNo = AccrNoTxt.Text;
                HeaderFooterTPData.AccrNo2 = AccrNo2Txt.Text;
                HeaderFooterTPData.DateFrom = DateFrom.Value.AddDays(0);
                HeaderFooterTPData.DateTo = DateTo.Value.AddDays(0);

                var deleteResult = HeaderFooterSrv.Remove(HeaderFooterTPData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Successfully Deleted");
                    LoadData();
                    ClearItems();
                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {        
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "TPLINUX.csv";
            bool fileError = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }

                if (!fileError)
                {
                    try
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string columnNames = "";
                        string[] outputCsv = new string[dataGridView1.Rows.Count + 1];

                        for (int i = 0; i < columnCount; i++)
                        {
                            columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                        }
                        outputCsv[0] += columnNames;

                        for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                        {
                            if(i == 16)
                            { 
                                string.Format("\t {0:#} ", outputCsv);
                            }
                            for (int j = 0; j < columnCount; j++)
                            {                          
                                outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";                              
                            }
                        }

                        File.WriteAllLines(sfd.FileName, outputCsv);
                        MessageBox.Show("Exported to CSV", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImportFilesTPLinux f = new ImportFilesTPLinux();
            f.ShowDialog();
        }

        private void HeaderFooterTPLinux_Load(object sender, EventArgs e)
        {
           ExportBtn.Visible = false;
        }
    }
}
      
