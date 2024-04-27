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
    public partial class Company : Form
    {
        CompanyServices CompanySrv;
        List<MasterCompany> masterCompanyList;
        int selectedRow;
        MasterCompany CompanyData;
  

        public Company()
        {
            InitializeComponent();

           CompanySrv = new CompanyServices();
           CompanyData = new MasterCompany();
           masterCompanyList = new List<MasterCompany>();
           LoadCompanyData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            CompanyCodeTxt.Text = masterCompanyList[selectedRow].CompanyCode.ToString();
            CompanyNameTxt.Text = masterCompanyList[selectedRow].CompanyName;

            CompanyData = masterCompanyList[selectedRow];
        }

        private void LoadCompanyData()
        {
            var showDetail = CompanySrv.GetAll();

            dataGridView1.DataSource = showDetail;
            masterCompanyList = showDetail;

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            CompanyData = new MasterCompany();

           CompanyData.CompanyCode = Convert.ToInt32(CompanyCodeTxt.Text);
           CompanyData.CompanyName = CompanyNameTxt.Text;

            var result = CompanySrv.Add(CompanyData);

            if (result.Success)
            {
                MessageBox.Show($"Company Successfully Created");
                LoadCompanyData();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CompanyData != null)
            {
                CompanyData.CompanyCode = Convert.ToInt32(CompanyCodeTxt.Text);
                CompanyData.CompanyName = CompanyNameTxt.Text;

                var updateResult = CompanySrv.Update(CompanyData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Company Successfully Updated");
                    LoadCompanyData();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (CompanyData != null)
            {
                CompanyData.CompanyCode = Convert.ToInt32(CompanyCodeTxt.Text);
                CompanyData.CompanyName = CompanyNameTxt.Text;

                var deleteResult = CompanySrv.Remove(CompanyData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Company Successfully Deleted");
                    LoadCompanyData();
                   
                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }
        }
    }
}
