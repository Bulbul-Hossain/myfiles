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
    public partial class FrmViewWorks : Form
    {
        public FrmViewWorks()
        {
            InitializeComponent();
        }

        private void FrmViewWorks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Works", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            if (con.State == ConnectionState.Open) con.Close();
        }
    }
}
