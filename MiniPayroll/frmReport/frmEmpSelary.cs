using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll.frmReport
{
    public partial class frmEmpSelary : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public frmEmpSelary()
        {
            InitializeComponent();
        }

        private void frmEmpSelary_Load(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\EmpSelary.rpt");
            Connection con = new Connection();
            DataSet dst = new DataSet();
            con.dataGet("select * from [Employee]");
            con.sda.Fill(dst, "Employee");
            con.dataGet("select * from [EmpSalary]");
            con.sda.Fill(dst, "EmpSalary");
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
