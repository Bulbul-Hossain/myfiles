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
    public partial class FrmEditWorks : Form
    {
        SqlConnection con;
        public FrmEditWorks()
        {
            InitializeComponent();
        }
        public Form1 FormOpened { get; set; }

        private void FrmEditWorks_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT WorkId FROM Works", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.ValueMember = "WorkId";
            comboBox2.DisplayMember = "WorkId";
            comboBox2.DataSource = dt;
            da = new SqlDataAdapter("SELECT LaborId FROM Labors", con);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            comboBox1.ValueMember = "LaborId";
            comboBox1.DisplayMember = "LaborId";
            comboBox1.DataSource = dt1;
            if (con.State == ConnectionState.Open) con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(@"UPDATE Works SET StartDate=@sd,EndDate=@ed where WorkId=@i", con);
            cmd.Parameters.AddWithValue("@i", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@sd", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ed", dateTimePicker2.Value);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Updated");
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Works where WorkId=@i", con);
            cmd.Parameters.AddWithValue("@i", comboBox2.SelectedValue);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dateTimePicker1.Value = dr.GetDateTime(1);
                dateTimePicker2.Value = dr.GetDateTime(2);
                comboBox1.SelectedValue = dr[3];
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Works Where WorkId=@i", con);
            cmd.Parameters.AddWithValue("@i", comboBox2.SelectedValue);            
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Deleted");
            }
            con.Close();
        }
    }
}
