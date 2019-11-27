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
    public partial class FrmAddWorks : Form
    {
        public FrmAddWorks()
        {
            InitializeComponent();
        }

        private void FrmAddWorks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Labors", con); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "LaborId";
            comboBox1.DisplayMember = "LaborName";
            comboBox1.DataSource = dt;
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(WorkId), 0) FROM Works", con);
            con.Open();
            int m = (int)cmd.ExecuteScalar();
            con.Close();
            textBox1.Text = (m + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Works VALUES(@i,@n,@p,@ri)", con);
            cmd.Parameters.AddWithValue("@i", textBox1.Text);
            cmd.Parameters.AddWithValue("@n", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@p", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@ri", comboBox1.SelectedValue);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Inserted");
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
