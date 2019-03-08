using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll
{
    public partial class frmMain : Form
    {
        public frmMain( string status)
        {
            InitializeComponent();
            label2.Text = status;
        }

        private void userRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.FrmUser frm = new User.FrmUser();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
        bool close = true;
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.frmChangePassword frm = new User.frmChangePassword();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employe.frmEmploye frm = new Employe.frmEmploye();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void empSelaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employe.frmEmpSalary frm = new Employe.frmEmpSalary();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void empAttentdaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employe.frmEmpAttentdanse frm = new Employe.frmEmpAttentdanse();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void empAttentdanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employe.frmAttendanceView frm = new Employe.frmAttendanceView();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void selaryProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employe.frmSelaryProcess frm = new Employe.frmSelaryProcess();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void userReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport.frmUserReport frm = new frmReport.frmUserReport();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void empSelaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReport.frmEmpSelary frm = new frmReport.frmEmpSelary();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void empAtttendaceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport.frmEmpAttendence frm = new frmReport.frmEmpAttendence();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void paySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport.frmpaySlip frm = new frmReport.frmpaySlip();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = DateTime.Now.ToLongTimeString();
            label4.Text = DateTime.Now.ToLongDateString();

        }

        private void registiorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LisenceForm frm = new LisenceForm();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           About. AboutMe frm = new About. AboutMe();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport.frmEmpReport frm = new frmReport.frmEmpReport();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void empAttenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export.empAttendance frm = new Export.empAttendance();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void dateWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport.DatePayProcessRepoprt frm = new frmReport.DatePayProcessRepoprt();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
