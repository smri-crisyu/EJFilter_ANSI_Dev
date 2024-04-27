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
    public partial class TelnetServers : Form
    {
        TelnetServerServices TelnetServerSrv;
        List<TelnetServer> TelnetServerList;
        int selectedRow;
        TelnetServer TelnetServersData;
        public TelnetServers()
        {
            InitializeComponent();

            TelnetServerSrv = new TelnetServerServices();
            TelnetServersData = new TelnetServer();
            TelnetServerList = new List<TelnetServer>();
            LoadTelnetServer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            ServerNameTxt.Text = TelnetServerList[selectedRow].ServerName.ToString();

            TelnetServersData = TelnetServerList[selectedRow];
        }
        public void LoadTelnetServer()
        {
            var showDetail = TelnetServerSrv.GetAll();

            dataGridView1.DataSource = showDetail;
            TelnetServerList = showDetail;

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            TelnetServersData = new TelnetServer();

            TelnetServersData.ServerName = ServerNameTxt.Text;

            var result = TelnetServerSrv.Add(TelnetServersData);

            if (result.Success)
            {
                MessageBox.Show($"Successfully Created");
                LoadTelnetServer();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (TelnetServersData != null)
            {

                TelnetServersData.ServerName = ServerNameTxt.Text;

                var updateResult = TelnetServerSrv.Update(TelnetServersData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Successfully Updated");
                    LoadTelnetServer();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (TelnetServersData != null)
            {
                TelnetServersData.ServerName = ServerNameTxt.Text;

                var deleteResult = TelnetServerSrv.Remove(TelnetServersData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Successfully Deleted");
                    LoadTelnetServer();

                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }
        }
    }
}
