using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll.Export
{
    public partial class empAttendance : Form
    {
        public empAttendance()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<EmpAttendance> list = ((DataParametr)e.Argument).EmpattendList;
                string fileName = ((DataParametr)e.Argument).FileName;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)excel.ActiveSheet;
                excel.Visible = false;
                int index = 1;
                int proccess = list.Count;



                ws.Cells[1, 1] = "Emp Id";
                ws.Cells[1, 2] = "Year";
                ws.Cells[1, 3] = "Month";
                ws.Cells[1, 4] = "Total Days";
                ws.Cells[1, 5] = "Working day";
                ws.Cells[1, 6] = "Present day";
                ws.Cells[1, 7] = "Absence Day";
                ws.Cells[1, 8] = "Lop Day";
                foreach (EmpAttendance p in list)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(index++ * 100 / proccess);

                        ws.Cells[index, 1] = p.EmpId.ToString();
                        ws.Cells[index, 2] = p.Year.ToString();
                        ws.Cells[index, 3] = p.Month.ToString();
                        ws.Cells[index, 4] = p.TotalDays.ToString();
                        ws.Cells[index, 5] = p.WorkingDays.ToString();
                        ws.Cells[index, 6] = p.PresentDays.ToString();
                        ws.Cells[index, 7] = p.AbsentDays.ToString();
                        ws.Cells[index, 8] = p.LopDays.ToString();

                    }
                }

                ws.SaveAs(fileName, XlFileFormat.xlWorkbookDefault, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                excel.Quit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            labelStatus.Text = string.Format("Procesing--{0}", e.ProgressPercentage);
            progressBar.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error==null)
            {
                Thread.Sleep(100);
                labelStatus.Text = "Your Data hasbeen Export ";
            }

        }
        struct DataParametr
        {
            public List<EmpAttendance> EmpattendList;
            public string FileName { get; set; }
            
        }
        DataParametr _inputParameter;
        private void empAttendance_Load(object sender, EventArgs e)
        {
            using (miniPayrollEntities db = new miniPayrollEntities())
            {
                empAttendanceBindingSource.DataSource = db.EmpAttendances.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel workbook|*.xls" })
            {
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    _inputParameter.FileName = sfd.FileName;
                    _inputParameter.EmpattendList = empAttendanceBindingSource.DataSource as List<EmpAttendance>;
                    progressBar.Minimum = 0;
                    progressBar.Value = 0;
                    backgroundWorker1.RunWorkerAsync(_inputParameter);
                }
            }
        }
    }
}
