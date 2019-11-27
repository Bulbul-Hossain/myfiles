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

namespace Bulbul_1249211_Ex_06
{
    public partial class FrmMasterDetails : Form
    {
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        public FrmMasterDetails()
        {
            InitializeComponent();
        }

        private void FrmMasterDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Labors", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Labors");
            da = new SqlDataAdapter("SELECT * FROm Works", con);
            da.Fill(ds, "Works");
            DataRelation rel = new DataRelation("LAB_WORK", ds.Tables["Labors"].Columns["LaborId"], ds.Tables["Works"].Columns["LaborId"]);
            ds.Relations.Add(rel);
            bs1.DataMember = "Labors";
            bs1.DataSource = ds;
            bs2.DataMember = "LAB_WORK";
            bs2.DataSource = bs1;
            dataGridView1.DataSource = bs1;
            dataGridView2.DataSource = bs2;


        }
    }
}
