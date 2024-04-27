using EJFilter.Models.Entity;
using EJFilter.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJFilter.WinForm
{
    public partial class Branch : Form
    {
        BranchServices BranchSrv;
        StoreServices StoreSrv;
        List<MasterBranch> masterBranchList;
        int selectedRow;
        MasterBranch BranchData;
       // private string BranchData;
        public Branch()
        {
            InitializeComponent();

            BranchSrv = new BranchServices();

            StoreSrv = new StoreServices();
            BranchData = new MasterBranch();
            masterBranchList = new List<MasterBranch>();
            LoadBranchData();
            LoadStoreCode();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            BranchCodeTxt.Text = masterBranchList[selectedRow].BranchCode.ToString();
            BranchNameTxt.Text = masterBranchList[selectedRow].BranchName;
            StoreCodeCmb.SelectedValue = masterBranchList[selectedRow].StoreCode;
            BranchData = masterBranchList[selectedRow];
        }

        private void LoadBranchData()
        {
            var showDetail = BranchSrv.GetAll();

            dataGridView1.DataSource = showDetail;
            masterBranchList = showDetail;

        }
        private void ClearBranchItems()
        {
            BranchCodeTxt.Clear();
            BranchNameTxt.Clear();
            
        }

        private void LoadStoreCode()
        {

            StoreCodeCmb.DataSource = StoreSrv.GetAll();
            StoreCodeCmb.DisplayMember = "StoreName";
            StoreCodeCmb.ValueMember = "StoreCode";

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            BranchData = new MasterBranch();

            BranchData.BranchCode = Convert.ToInt32(BranchCodeTxt.Text);
            BranchData.BranchName = BranchNameTxt.Text;
            BranchData.StoreCode = Convert.ToInt32(StoreCodeCmb.SelectedValue);

            var result = BranchSrv.Add(BranchData);

            if (result.Success)
            {
                MessageBox.Show($"Created Branch Successfully");
                LoadBranchData();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (BranchData != null)
            {
                BranchData.BranchName = BranchNameTxt.Text;               
                BranchData.StoreCode = Convert.ToInt32(StoreCodeCmb.SelectedValue);

                var updateResult = BranchSrv.Update(BranchData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Updated Branch Successfully");
                    LoadBranchData();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (BranchData != null)
            {
                BranchData.BranchName = BranchNameTxt.Text;

                var deleteResult = BranchSrv.Remove(BranchData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Deleted Branch Successfully");
                    LoadBranchData();
                    ClearBranchItems();
                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }

        }

        private void Branch_Load(object sender, EventArgs e)
        {

        }
    }
}
