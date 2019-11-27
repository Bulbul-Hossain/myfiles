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
    public partial class FrmViewLabors : Form
    {
        public FrmViewLabors()
        {
            InitializeComponent();
        }

        private void FrmViewLabors_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Labors", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            if (con.State == ConnectionState.Open) con.Close();
        }
    }
}
