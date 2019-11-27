using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulbul_1249211_Ex_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmViewLabors { MdiParent = this }.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmViewWorks { MdiParent = this }.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAddLabors { MdiParent = this }.Show();
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmAddWorks { MdiParent = this }.Show();
        }

        private void editDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmEditLabors { FormOpened = this }.ShowDialog();
        }

        private void editDeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmEditWorks { FormOpened = this }.ShowDialog();
        }

        private void masterDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmMasterDetails { MdiParent = this }.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmRptWorks { MdiParent = this }.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
