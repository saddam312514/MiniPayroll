using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace MiniPayroll.frmReport
{
    public partial class frmEmpReport : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public frmEmpReport()
        {
            InitializeComponent();
        }

        private void frmEmpReport_Load(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\Empolyee.rpt");
            Connection con = new Connection();
            DataSet dst = new DataSet();
            con.dataGet("select * from Employee");
            con.sda.Fill(dst, "Employee");
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
