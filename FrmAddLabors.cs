using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulbul_1249211_Ex_06
{
    public partial class FrmAddLabors : Form
    {
        public FrmAddLabors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con= new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Labors VALUES(@i,@n,@p)", con);
            cmd.Parameters.AddWithValue("@i", textBox1.Text);
            cmd.Parameters.AddWithValue("@n", textBox2.Text);
            cmd.Parameters.AddWithValue("@p", textBox3.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Inserted");
            }
            con.Close();
        }

        private void FrmAddLabors_Load(object sender, EventArgs e)
        {

        }
    }
}
