using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulbul_1249211_Ex_06
{
    public partial class FrmRptWorks : Form
    {
        public FrmRptWorks()
        {
            InitializeComponent();
        }

        private void FrmRptWorks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Labors", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Labors");
            da = new SqlDataAdapter("SELECT * FROm Works", con);
            da.Fill(ds, "Works");
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Path.GetFullPath("..\\..\\") + "RptWorks.rpt");
            cryRpt.SetDataSource(ds);

            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ShowParameterPanelButton = false;

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
