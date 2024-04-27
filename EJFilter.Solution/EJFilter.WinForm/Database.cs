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
    public partial class Database : Form
    {
        DBCredentialsServices DBCredentialsSrv;
        List<DBCredentials> DBCredentialsList;
        int selectedRow;
        DBCredentials DBCredentialsData;

        public Database()
        {
            InitializeComponent();
            DBCredentialsSrv = new DBCredentialsServices();
            DBCredentialsData = new DBCredentials();
            DBCredentialsList = new List<DBCredentials>();
            LoadDBCredentials();
        }

        private void DBPwdTxt_TextChanged(object sender, EventArgs e)
        { 
            DBPwdTxt.ForeColor = Color.Black;
            DBPwdTxt.UseSystemPasswordChar = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            DBNameTxt.Text = DBCredentialsList[selectedRow].DBName.ToString();
            DBUserTxt.Text = DBCredentialsList[selectedRow].DBUser.ToString();
            DBPwdTxt.Text = DBCredentialsList[selectedRow].DBPassword.ToString();

            DBCredentialsData = DBCredentialsList[selectedRow];
        }

        public void LoadDBCredentials()
        {
            var showDetail = DBCredentialsSrv.GetAll();

            dataGridView1.DataSource = showDetail;
            DBCredentialsList = showDetail;
        }

        public void ClearItems()
        {
            DBNameTxt.Clear();
            DBUserTxt.Clear();
            DBPwdTxt.Clear();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            DBCredentialsData = new DBCredentials();

            DBCredentialsData.DBName = DBNameTxt.Text;
            DBCredentialsData.DBUser = DBUserTxt.Text;
            DBCredentialsData.DBPassword = DBPwdTxt.Text;

            var result = DBCredentialsSrv.Add(DBCredentialsData);

            if (result.Success)
            {
                MessageBox.Show($"Successfully Created");
                LoadDBCredentials();
                ClearItems();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (DBCredentialsData != null)
            {

                DBCredentialsData.DBName = DBNameTxt.Text;
                DBCredentialsData.DBUser = DBUser.Text;
                DBCredentialsData.DBPassword = DBPwdTxt.Text;

                var updateResult = DBCredentialsSrv.Update(DBCredentialsData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Successfully Updated");
                    LoadDBCredentials();
                    ClearItems();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (DBCredentialsData != null)
            {
                DBCredentialsData.DBName = DBNameTxt.Text;
                DBCredentialsData.DBUser = DBUser.Text;
                DBCredentialsData.DBPassword = DBPwdTxt.Text;


                var deleteResult = DBCredentialsSrv.Remove(DBCredentialsData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Successfully Deleted");
                    LoadDBCredentials();
                    ClearItems();

                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }
        }

   

    }
}
