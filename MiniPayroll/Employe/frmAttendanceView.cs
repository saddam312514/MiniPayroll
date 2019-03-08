using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll.Employe
{
    public partial class frmAttendanceView : Form
    {
        public frmAttendanceView()
        {
            InitializeComponent();
        }

        private void cmbEmpId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEmpId.SelectedIndex==0)
            {
                txtSearch.Visible = false;
            }
            if(cmbEmpId.SelectedIndex!=0)
            {
                txtSearch.Visible = true;
                txtSearch.Clear();
            }

        }
        private DataGridView dgview;
        private DataGridViewTextBoxColumn dgviewcol1;
        private DataGridViewTextBoxColumn dgviewcol2;
        void Search()
        {
            dgview = new DataGridView();
            dgviewcol1 = new DataGridViewTextBoxColumn();
            dgviewcol2 = new DataGridViewTextBoxColumn();
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgviewcol1, this.dgviewcol2 });
            this.dgview.Name = "dgview";
            dgview.Visible = false;
            this.dgviewcol1.Visible = false;
            this.dgviewcol2.Visible = false;
            this.dgview.AllowUserToAddRows = false;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.dgview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgview_KeyDown);

            this.Controls.Add(dgview);
            this.dgview.ReadOnly = true;
            dgview.BringToFront();
        }

        void Search(int LX, int LY, int DW, int DH, string ColName, String ColSize)
        {
            this.dgview.Location = new System.Drawing.Point(LX, LY);
            this.dgview.Size = new System.Drawing.Size(DW, DH);

            string[] ClSize = ColSize.Split(',');
            //Size
            for (int i = 0; i < ClSize.Length; i++)
            {
                if (int.Parse(ClSize[i]) != 0)
                {
                    dgview.Columns[i].Width = int.Parse(ClSize[i]);
                }
                else
                {
                    dgview.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            //Name 
            string[] ClName = ColName.Split(',');

            for (int i = 0; i < ClName.Length; i++)
            {
                this.dgview.Columns[i].HeaderText = ClName[i];
                this.dgview.Columns[i].Visible = true;
            }
        }
        bool change = true;
        private void employee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = false;
                txtSearch.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                this.dgview.Visible = false;
                cmbYear.Focus();
                change = true;
            }
        }

        private void frmAttendanceView_Load(object sender, EventArgs e)
        {
            Search();
            txtSearch.Visible = false;
            cmbEmpId.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length!=0)
            {
                if (txtSearch.Text.Length != 0)
                {
                    if (cmbEmpId.SelectedIndex == 1)
                    {
                        this.dgview.Visible = true;
                        dgview.BringToFront();
                        Search(120, 90, 400, 200, "Emp Id,Emp Name", "100,0");
                        this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.employee_MouseDoubleClick);
                        Connection con = new Connection();
                        con.dataGet("Select Top(10) EmpId,Name From Employee WHERE EmpId Like '" + txtSearch.Text + "%'");
                        DataTable dt = new DataTable();
                        con.sda.Fill(dt);
                        dgview.Rows.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            int n = dgview.Rows.Add();
                            dgview.Rows[n].Cells[0].Value = row["EmpId"].ToString();
                            dgview.Rows[n].Cells[1].Value = row["Name"].ToString();
                        }
                    }
                }
            }
        }
        Connection con = new Connection();
        void LoadData(string condition)
        {

            try
            {
                con.dataGet("Select EmpAttendance.*,Employee.Name from Employee Inner Join EmpAttendance On Employee.EmpId = EmpAttendance.EmpId " + condition + "");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["dgEmpId"].Value = row["EmpId"].ToString();
                    dataGridView1.Rows[n].Cells["dgEmpName"].Value = row["Name"].ToString();
                    dataGridView1.Rows[n].Cells["dgYear"].Value = row["Year"].ToString();
                    dataGridView1.Rows[n].Cells["dgMonth"].Value = row["Month"].ToString();
                    dataGridView1.Rows[n].Cells["dgTotDays"].Value = row["TotalDays"].ToString();
                    dataGridView1.Rows[n].Cells["dgWorkingDays"].Value = row["WorkingDays"].ToString();
                    dataGridView1.Rows[n].Cells["dgPresent"].Value = row["PresentDays"].ToString();
                    dataGridView1.Rows[n].Cells["dgAbsent"].Value = row["AbsentDays"].ToString();
                    dataGridView1.Rows[n].Cells["dgLop"].Value = row["LopDays"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (dgview.Rows.Count>0)
                {
                    txtSearch.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    dgview.Visible = false;
                    cmbYear.Focus();
                }
                else
                {
                    this.dgview.Visible = false;
                }
                    
     
    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbEmpId.SelectedIndex==0)
            {
                LoadData("Where EmpAttendance.Year='" + cmbYear.Text + "' and EmpAttendance.Month='" + cmbMont.Text + "'");

            }
            if(cmbEmpId.SelectedIndex==1)
            {
                LoadData("Where EmpAttendance.EmpId='" + txtSearch.Text + "' and EmpAttendance.Year='" + cmbYear.Text + "' and EmpAttendance.Month='" + cmbMont.Text + "' ");

            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
