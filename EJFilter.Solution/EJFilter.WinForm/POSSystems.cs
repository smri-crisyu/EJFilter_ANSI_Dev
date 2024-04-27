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
    public partial class POSSystems : Form
    {
        POSServices POSSystemsSrv;
        List<POSSystem> POSSystemsList;
        int selectedRow;
        POSSystem POSSystemsData;
        public POSSystems()
        {
            InitializeComponent();
            POSSystemsSrv = new POSServices();
            POSSystemsData = new POSSystem();
            POSSystemsList = new List<POSSystem>();
            LoadPOSSystems();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            POSTypeTxt.Text = POSSystemsList[selectedRow].POSType.ToString();

            POSSystemsData = POSSystemsList[selectedRow];
        }
        public void LoadPOSSystems()
        {
            var showDetail = POSSystemsSrv.GetAll();

            dataGridView1.DataSource = showDetail;
            POSSystemsList = showDetail;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            POSSystemsData = new POSSystem();

            POSSystemsData.POSType = POSTypeTxt.Text;

            var result = POSSystemsSrv.Add(POSSystemsData);
           
            if (result.Success)
            {
                MessageBox.Show($"Successfully Created");
                LoadPOSSystems();
            }
            else
                MessageBox.Show(result.ReturnMessage);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (POSSystemsData != null)
            {
                POSSystemsData.POSType = POSTypeTxt.Text;

                var updateResult = POSSystemsSrv.Update(POSSystemsData);

                if (updateResult.Success)
                {
                    MessageBox.Show($"Successfully Updated");
                    LoadPOSSystems();
                }
                else
                    MessageBox.Show(updateResult.ReturnMessage);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (POSSystemsData != null)
            {
                POSSystemsData.POSType = POSTypeTxt.Text;

                var deleteResult = POSSystemsSrv.Remove(POSSystemsData);

                if (deleteResult.Success)
                {
                    MessageBox.Show($"Successfully Deleted");
                    LoadPOSSystems();

                }
                else
                    MessageBox.Show(deleteResult.ReturnMessage);

            }
        }
    }
}
