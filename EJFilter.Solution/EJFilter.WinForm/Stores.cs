using EJFilter.Models.Entity;
using EJFilter.Models.Interface;
using EJFilter.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJFilter.WinForm
{
    public partial class Form1 : Form
    {
        StoreServices storeSrv;
        List<MasterStore> masterStoresList;
        int selectedRow;
        MasterStore storeData;

        public Form1()
        {
            InitializeComponent();
            storeSrv = new StoreServices();
            storeData = new MasterStore();
            masterStoresList = new List<MasterStore>();
            LoadStoreData();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            storeData = new MasterStore();
            
            storeData.StoreCode = Convert.ToInt32(StoreCodeTxt.Text);
            storeData.StoreName = StoreNameTxt.Text;

            var result = storeSrv.Add(storeData);

            if (result.Success)
            {
                MessageBox.Show($"Created Store Successfully" );
                LoadStoreData();
            }
            else
                MessageBox.Show(result.ReturnMessage);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;

            StoreCodeTxt.Text = masterStoresList[selectedRow].StoreCode.ToString();
            StoreNameTxt.Text = masterStoresList[selectedRow].StoreName;
            storeData = masterStoresList[selectedRow];        

        }
         

        //    if (masterStoresList.Count > 0)
        //    {
        //        StoreCodeTxt.Text = masterStoresList[selectedRow].StoreCode.ToString();
        //        StoreNameTxt.Text = masterStoresList[selectedRow].StoreName;

        //        storeData = masterStoresList[selectedRow];
        //    }

        //}

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (storeData != null)
            {
                storeData.StoreName = StoreNameTxt.Text;

                var updateResult = storeSrv.Update(storeData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Updated Store Successfully");
                    LoadStoreData();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (storeData != null)
            {
                storeData.StoreName = StoreNameTxt.Text;

                var deleteResult = storeSrv.Remove(storeData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Deleted Store Successfully");
                    LoadStoreData();
                    
                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }

        }

        private void LoadStoreData()
        {
            var showDetail = storeSrv.GetAll();
            
            dataGridView1.DataSource = showDetail;
        }

    }
}
