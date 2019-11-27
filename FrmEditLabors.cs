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
    public partial class FrmEditLabors : Form
    {
        SqlConnection con;
        public FrmEditLabors()
        {
            InitializeComponent();
        }
        public Form1 FormOpened { get; set; }

        private void FrmEditLabors_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT LaborId FROM Labors", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "LaborId";
            comboBox1.DisplayMember = "LaborId";
            comboBox1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Labors where LaborId=@i", con);
            cmd.Parameters.AddWithValue("@i", comboBox1.SelectedValue);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr.GetString(1);
                textBox3.Text = dr[2].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(@"UPDATE Labors SET LaborName=@n,PayRate=@p where LaborId=@i", con);
            cmd.Parameters.AddWithValue("@i", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@n", textBox2.Text);
            cmd.Parameters.AddWithValue("@p", textBox3.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Updated");                
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(@"Delete FROM Labors WHERE LaborId=@i", con);
            cmd.Parameters.AddWithValue("@i", comboBox1.SelectedValue);            
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Deleted");
            }
            con.Close();
        }
    }
}
