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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            bRANCHToolStripMenuItem.Font = new Font("Henry Sans", 10);
            sTORESToolStripMenuItem.Font = new Font("Henry Sans", 10);
            cONFIGSETTINGSToolStripMenuItem.Font = new Font("Henry Sans", 10);
            configTypeToolStripMenuItem.Font = new Font("Henry Sans", 10);
            headerAndFooterToolStripMenuItem.Font = new Font("Henry Sans", 10);
            headerAndFooterToolStripMenuItem1.Font = new Font("Henry Sans", 10);
            vQPBOSToolStripMenuItem.Font = new Font("Henry Sans", 10);
            tPLINUXToolStripMenuItem.Font = new Font("Henry Sans", 10);
            companytoolStripMenuItem1.Font = new Font("Henry Sans", 10);

            this.vQPBOSToolStripMenuItem.Visible = false; //hide VQPBOS


        }

        private void bRANCHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Branch f = new Branch();
            f.ShowDialog();
        }

        private void sTORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void configTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ConfigType f = new ConfigType();
            f.ShowDialog();
        }
        private void cONFIGSETTINGSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void headerAndFooterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeaderFooterVQPBOS f = new HeaderFooterVQPBOS();
            f.ShowDialog();
        }

        private void headerAndFooterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HeaderFooterTPLinux f = new HeaderFooterTPLinux();
            f.ShowDialog();
        }

        private void companytoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Company f = new Company();
            f.ShowDialog();
        }

        private void pOSSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POSSystems f = new POSSystems();
            f.ShowDialog();
        }

        private void telnetServersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelnetServers f = new TelnetServers();
            f.ShowDialog();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database f = new Database();
            f.ShowDialog(this);
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
