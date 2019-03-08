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
using CrystalDecisions.Shared;

namespace MiniPayroll.frmReport
{
    public partial class frmEmpAttendence : Form
    {
        ReportDocument crpty = new ReportDocument();
        public frmEmpAttendence()
        {
            InitializeComponent();
        }

        private void frmEmpAttendence_Load(object sender, EventArgs e)
        {
            crpty.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\frmAttentdance.rpt");
            Connection con = new Connection();
            DataSet ds = new DataSet();
            con.dataGet("Select * from Employee");
            con.sda.Fill(ds, "Employee");
            con.dataGet("Select * from EmpAttendance");
            con.sda.Fill(ds, "EmpAttendance");
            crpty.SetDataSource(ds);
            crystalReportViewer1.ReportSource = crpty;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportOptions exportOption;
            DiskFileDestinationOptions diskfiledestinationOption = new DiskFileDestinationOptions();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf file|*.pdf";
           // sfd.Filter = "Excel|*.xls";
            if(sfd.ShowDialog()==DialogResult.OK)
            {
                diskfiledestinationOption.DiskFileName = sfd.FileName;
            }
            exportOption = crpty.ExportOptions;
            {
                exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                exportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                //exportOption.ExportFormatType = ExportFormatType.Excel;
                exportOption.ExportDestinationOptions = diskfiledestinationOption;

                exportOption.ExportFormatOptions = new PdfRtfWordFormatOptions();
                //exportOption.ExportFormatOptions = new ExcelFormatOptions();
            }
            crpty.Export();
        }
    }
}
