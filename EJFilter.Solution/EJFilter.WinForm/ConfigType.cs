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
    public partial class ConfigType : Form
    {
        ConfigTypeServices ConfigSrv;
        List<ConfigTypes> ConfigTypeList;
        int selectedRow;
        ConfigTypes ConfigData;

        public ConfigType()
        {
            InitializeComponent();

            ConfigSrv = new ConfigTypeServices();
            ConfigData = new ConfigTypes();
            ConfigTypeList = new List<ConfigTypes>();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            ConfigNameTxt.Text = ConfigTypeList[selectedRow].ConfigName;
            ConfigTypeTxt.Text = ConfigTypeList[selectedRow].Type;
            ConfigData = ConfigTypeList[selectedRow];
        }
        private void ClearItems()
        {
            ConfigNameTxt.Clear();
            ConfigTypeTxt.Clear();

        }


        private void LoadData()
        {
            var showDetail = ConfigSrv.GetAll();

            dataGridView1.DataSource = showDetail;
            ConfigTypeList = showDetail;

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            ConfigData = new ConfigTypes();

            ConfigData.ConfigName = ConfigNameTxt.Text;
            ConfigData.Type = ConfigTypeTxt.Text;
     
            var result = ConfigSrv.Add(ConfigData);

            if (result.Success)
            {
                MessageBox.Show($"Created Config Type Successfully");
                LoadData();
                ClearItems();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (ConfigData != null)
            {
                ConfigData.ConfigName = ConfigNameTxt.Text;
                ConfigData.Type = ConfigTypeTxt.Text;

                var updateResult = ConfigSrv.Update(ConfigData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Updated Config Type Successfully");
                    LoadData();
                    ClearItems();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (ConfigData != null)
            {
                ConfigData.ConfigName = ConfigNameTxt.Text;
                ConfigData.Type = ConfigTypeTxt.Text;

                var deleteResult = ConfigSrv.Remove(ConfigData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Deleted Config Type Successfully");
                    LoadData();
                    ClearItems();
                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }
        }
    }
}
