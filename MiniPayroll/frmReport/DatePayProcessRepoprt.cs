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
    public partial class DatePayProcessRepoprt : Form
    {
        ReportDocument crystal = new ReportDocument();
        public DatePayProcessRepoprt()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        private void button1_Click(object sender, EventArgs e)
        {
            crystal.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\datePayProcess.rpt");
            con.dataGet("select * from [SalaryProcess] where Cast(date as Date)between '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'");
            DataSet dst = new DataSet();
            con.sda.Fill(dst, "SalaryProcess");
            crystal.SetDataSource(dst);
            crystal.SetParameterValue("@fromDate", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            crystal.SetParameterValue("@toDate", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            crystalReportViewer1.ReportSource = crystal;


        }
    }
}
