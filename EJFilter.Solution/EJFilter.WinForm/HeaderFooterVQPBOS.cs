using EJFilter.Models.Entity;
using EJFilter.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJFilter.WinForm
{
    public partial class HeaderFooterVQPBOS : Form
    {
        int selectedRow;
        CompanyServices CompanySrv;
        BranchServices BranchSrv;
        StoreServices StoreSrv;
        ConfigTypeServices ConfigSrv;
        HeaderFooterVQPServices HeaderFooterSrv;
        List<HeaderFooterVQP> HeaderFooterList;
        HeaderFooterVQP HeaderFooterData;
        public HeaderFooterVQPBOS()
        {
            InitializeComponent();
            HeaderFooterSrv = new HeaderFooterVQPServices();
            HeaderFooterData = new HeaderFooterVQP();

            BranchSrv = new BranchServices();
            StoreSrv = new StoreServices();
            CompanySrv = new CompanyServices();
            ConfigSrv = new ConfigTypeServices();


            HeaderFooterList = new List<HeaderFooterVQP>();

            LoadData();
            LoadStoreCode();
            LoadBranchCode();
            LoadCompany();
            LoadConfigType();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            BranchCmb.SelectedValue = HeaderFooterList[selectedRow].BranchCode;
            StoreCmb.SelectedValue = HeaderFooterList[selectedRow].StoreCode;
            TypeCmb.SelectedValue = HeaderFooterList[selectedRow].Type;
            CompanyCmb.SelectedValue = HeaderFooterList[selectedRow].Company;
            Address1Txt.Text = HeaderFooterList[selectedRow].Address1;
            Address2Txt.Text = HeaderFooterList[selectedRow].Address2;
            Address3Txt.Text = HeaderFooterList[selectedRow].Address3;
            ZipLocTxt.Text = HeaderFooterList[selectedRow].Zip_Location;
            ZipCodeTxt.Text = HeaderFooterList[selectedRow].Zip_Code;
            VatRegTin_HTxt.Text = HeaderFooterList[selectedRow].VatRegTin_H;
            POSNoTxt.Text = HeaderFooterList[selectedRow].PosNo;
            SerialNoTxt.Text = HeaderFooterList[selectedRow].SerialNo;
            PermitNoTxt.Text = HeaderFooterList[selectedRow].PermitNo;
            MinNoTxt.Text = HeaderFooterList[selectedRow].MinNo;
            VatRegTin_FTxt.Text = HeaderFooterList[selectedRow].VatRegTin_F;
            AccrNoTxt.Text = HeaderFooterList[selectedRow].AccrNo;
            AccrNo2Txt.Text = HeaderFooterList[selectedRow].AccrNo2;
            DateFrom.Text = HeaderFooterList[selectedRow].DateFrom.ToString();
            DateTo.Text = HeaderFooterList[selectedRow].DateTo.ToString();

            HeaderFooterData = HeaderFooterList[selectedRow];


        }

        private void HeaderFooterVQPBOS_Load(object sender, EventArgs e)
        {
            ExportBtn.Visible = false;
        }
        private void LoadData()
        {
            var showDetail = HeaderFooterSrv.GetAll();

            dataGridView1.DataSource = showDetail;
            HeaderFooterList = showDetail;

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


        /*public void HeaderDisplay()
        {
            Company.Visible = true;
            CompanyTxt.Visible = true;
            Location.Visible = true;
            Address1Txt.Visible = true;
            ZipCode.Visible = true;
            ZipLocTxt.Visible = true;
            VatRegTinH.Visible = true;
            VatRegTin_HTxt.Visible = true;
            PosNo.Visible = true;
            POSNoTxt.Visible = true;
            SerialNo.Visible = true;
            SerialNoTxt.Visible = true;
            PermitNo.Visible = true;
            PermitNoTxt.Visible= true;
            MinNo.Visible = true;
            MinNoTxt.Visible = true;

            VatRegTinF.Visible = false;
            VatRegTin_FTxt.Visible = false;
            AccrNo.Visible = false;
            AccrNoTxt.Visible = false;
            AccrNo2Txt.Visible = false;
            Date.Visible = false;
            DateFrom.Visible = false;
            DateTo.Visible = false;

        }


        public void FooterDisplay()
        {
            Company.Visible = false;
            CompanyTxt.Visible = false;
            Location.Visible = false;
            Address1Txt.Visible = false;
            ZipCode.Visible = false;
            ZipLocTxt.Visible = false;
            VatRegTinH.Visible = false;
            VatRegTin_HTxt.Visible = false;
            PosNo.Visible = false;
            POSNoTxt.Visible = false;
            SerialNo.Visible = false;
            SerialNoTxt.Visible = false;
            PermitNo.Visible = false;
            PermitNoTxt.Visible = false;
            MinNo.Visible = false;
            MinNoTxt.Visible = false;

            VatRegTinF.Visible = true;
            VatRegTin_FTxt.Visible = true;
            AccrNo.Visible = true;
            AccrNoTxt.Visible = true;
            AccrNo2Txt.Visible = true;
            Date.Visible = true;
            DateFrom.Visible = true;
            DateTo.Visible = true;

        }*/


        private void ClearItems()
        {

            //CompanyTxt.Clear();
            Address1Txt.Clear();
            Address2Txt.Clear();
            Address3Txt.Clear();
            ZipLocTxt.Clear();
            ZipCodeTxt.Clear();
            VatRegTin_HTxt.Clear();
            POSNoTxt.Clear();
            SerialNoTxt.Clear();
            PermitNoTxt.Clear();
            MinNoTxt.Clear();
            VatRegTin_FTxt.Clear();
            AccrNoTxt.Clear();
            AccrNo2Txt.Clear();


        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            HeaderFooterData = new HeaderFooterVQP();

            HeaderFooterData.BranchCode = Convert.ToInt32(BranchCmb.SelectedValue);
            HeaderFooterData.StoreCode = Convert.ToInt32(StoreCmb.SelectedValue);
            HeaderFooterData.Type = TypeCmb.SelectedValue.ToString();
            HeaderFooterData.Company = CompanyCmb.SelectedValue.ToString();
            HeaderFooterData.Address1 = Address1Txt.Text;
            HeaderFooterData.Address2 = Address2Txt.Text;
            HeaderFooterData.Address3 = Address3Txt.Text;
            HeaderFooterData.Zip_Location = ZipLocTxt.Text;
            HeaderFooterData.Zip_Code = ZipCodeTxt.Text;
            HeaderFooterData.VatRegTin_H = VatRegTin_HTxt.Text;
            HeaderFooterData.PosNo = POSNoTxt.Text;
            HeaderFooterData.SerialNo = SerialNoTxt.Text;
            HeaderFooterData.PermitNo = PermitNoTxt.Text;
            HeaderFooterData.MinNo = MinNoTxt.Text;
            HeaderFooterData.VatRegTin_F = VatRegTin_FTxt.Text;
            HeaderFooterData.AccrNo = AccrNoTxt.Text;
            HeaderFooterData.AccrNo2 = AccrNo2Txt.Text;
            HeaderFooterData.DateFrom = Convert.ToDateTime(DateFrom.Value.ToShortDateString());
            HeaderFooterData.DateTo = Convert.ToDateTime(DateTo.Value.ToShortDateString());

            var result = HeaderFooterSrv.Add(HeaderFooterData);

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
            if (HeaderFooterData != null)
            {

                HeaderFooterData.BranchCode = Convert.ToInt32(BranchCmb.SelectedValue);
                HeaderFooterData.StoreCode = Convert.ToInt32(StoreCmb.SelectedValue);
                HeaderFooterData.Type = TypeCmb.SelectedValue.ToString();
                HeaderFooterData.Company = CompanyCmb.SelectedValue.ToString();
                HeaderFooterData.Address1 = Address1Txt.Text;
                HeaderFooterData.Address2 = Address2Txt.Text;
                HeaderFooterData.Address3 = Address3Txt.Text;
                HeaderFooterData.Zip_Location = ZipLocTxt.Text;
                HeaderFooterData.Zip_Code = ZipCodeTxt.Text;
                HeaderFooterData.VatRegTin_H = VatRegTin_HTxt.Text;
                HeaderFooterData.PosNo = POSNoTxt.Text;
                HeaderFooterData.SerialNo = SerialNoTxt.Text;
                HeaderFooterData.PermitNo = PermitNoTxt.Text;
                HeaderFooterData.MinNo = MinNoTxt.Text;
                HeaderFooterData.VatRegTin_F = VatRegTin_FTxt.Text;
                HeaderFooterData.AccrNo = AccrNoTxt.Text;
                HeaderFooterData.AccrNo2 = AccrNo2Txt.Text;
                HeaderFooterData.DateFrom = DateFrom.Value.AddDays(0);
                HeaderFooterData.DateTo = DateTo.Value.AddDays(0);



                var updateResult = HeaderFooterSrv.Update(HeaderFooterData);

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
            if (HeaderFooterData != null)
            {
                HeaderFooterData.BranchCode = Convert.ToInt32(BranchCmb.SelectedValue);
                HeaderFooterData.StoreCode = Convert.ToInt32(StoreCmb.SelectedValue);
                HeaderFooterData.Type = TypeCmb.SelectedValue.ToString();
                HeaderFooterData.Company = CompanyCmb.SelectedValue.ToString();
                HeaderFooterData.Address1 = Address1Txt.Text;
                HeaderFooterData.Address2 = Address2Txt.Text;
                HeaderFooterData.Address3 = Address3Txt.Text;
                HeaderFooterData.Zip_Location = ZipLocTxt.Text;
                HeaderFooterData.Zip_Code = ZipCodeTxt.Text;
                HeaderFooterData.VatRegTin_H = VatRegTin_HTxt.Text;
                HeaderFooterData.PosNo = POSNoTxt.Text;
                HeaderFooterData.SerialNo = SerialNoTxt.Text;
                HeaderFooterData.PermitNo = PermitNoTxt.Text;
                HeaderFooterData.MinNo = MinNoTxt.Text;
                HeaderFooterData.VatRegTin_F = VatRegTin_FTxt.Text;
                HeaderFooterData.AccrNo = AccrNoTxt.Text;
                HeaderFooterData.AccrNo2 = AccrNo2Txt.Text;
                HeaderFooterData.DateFrom = DateFrom.Value.AddDays(0);
                HeaderFooterData.DateTo = DateTo.Value.AddDays(0);

                var deleteResult = HeaderFooterSrv.Remove(HeaderFooterData);

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
                            columnNames += dataGridView1.Columns[i].HeaderText.ToString() + "";
                        }
                        outputCsv[0] += columnNames;

                        for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + "";
                            }

                        }

                        File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        MessageBox.Show("Exported to CSV", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }

    }
}
