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
    public partial class frmEmpAttentdanse : Form
    {
        public frmEmpAttentdanse()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
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

        //Two Column
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpId.Text.Length > 0)
            {
                this.dgview.Visible = true;
                dgview.BringToFront();
                Search(90, 70, 400, 200, "Emp Id,Emp Name", "100,0");
                this.dgview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.employee_MouseDoubleClick);
                Connection con = new Connection();
                con.dataGet("Select Top(10) EmpId,Name From Employee WHERE EmpId Like '" + txtEmpId.Text + "%'");
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
            else
            {
                dgview.Visible = false;
            }
        }
        bool change = true;
        private void employee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (change)
            {
                change = false;
                txtEmpId.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgview.SelectedRows[0].Cells[1].Value.ToString();
                this.dgview.Visible = false;
                cmbYear.Focus();
                change = true;
            }
        }

        private void Dgview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void frmEmpAttentdanse_Load(object sender, EventArgs e)
        {
            Search();
            this.ActiveControl = txtEmpId;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void txtEmpId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(dgview.Rows.Count>0)
                {
                    txtEmpId.Text = dgview.SelectedRows[0].Cells[0].Value.ToString();
                    txtName.Text= dgview.SelectedRows[0].Cells[1].Value.ToString();
                    this.dgview.Visible = false;
                    cmbYear.Focus();

                }
                else
                {
                    this.dgview.Visible = false;
                }
            }
        }

        private void cmbYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbYear.SelectedIndex != -1)
                {
                    cmbMonth.Focus();
                }
                else
                {
                    cmbYear.Focus();
                }
            }
        }

        private void cmbMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbMonth.SelectedIndex != -1)
                {
                    txtTotalDays.Focus();
                }
                else
                {
                    cmbMonth.Focus();
                }
            }
        }

        private void txtworkDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtworkDays.Text.Length > 0)
                {
                    txtPreDays.Focus();
                }
                else
                {
                    txtworkDays.Focus();
                }
            }
        }

        private void txtTotalDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTotalDays.Text.Length > 0)
                {
                    txtworkDays.Focus();
                }
                else
                {
                    txtTotalDays.Focus();
                }
            }
        }

        private void txtPreDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtabsenceDays.Focus();
            }
        }

        private void txtabsenceDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtlopDays.Focus();
            }
        }

        private void txtlopDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void txtTotalDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        Connection con = new Connection();
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (cmbMonth.SelectedIndex != -1)
                {
                    con.dataGet("Select * from EmpAttendance where EmpId='" + txtEmpId.Text + "' and Year='" + cmbYear.Text + "' and Month='" + cmbMonth.Text + "'");
                    DataTable dt = new DataTable();
                    con.sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtTotalDays.Text = dt.Rows[0]["TotalDays"].ToString();
                        txtworkDays.Text = dt.Rows[0]["WorkingDays"].ToString();
                        txtPreDays.Text = dt.Rows[0]["PresentDays"].ToString();
                        txtabsenceDays.Text = dt.Rows[0]["AbsentDays"].ToString();
                        txtlopDays.Text = dt.Rows[0]["LopDays"].ToString();
                        button1.Enabled = false;
                        button2.Enabled = true;
                        button3.Enabled = true;
                    }
                    else
                    {
                        txtTotalDays.Text = "";
                        txtworkDays.Text = "";
                        txtPreDays.Text = "";
                        txtabsenceDays.Text = "";
                        txtlopDays.Text = "";
                        button1.Enabled = true;
                        button2.Enabled = false;
                        button3.Enabled = false;
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtEmpId.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmpId, "Emp Id Required");
            }
            else if (string.IsNullOrEmpty(cmbYear.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbYear, "Select Year");
            }
            else if (string.IsNullOrEmpty(cmbMonth.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbMonth, "Select Month");
            }
            else if (string.IsNullOrEmpty(txtTotalDays.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTotalDays, "Total Days Requried");
            }
            else if (string.IsNullOrEmpty(txtworkDays.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtworkDays, "Working Days Required");
            }
            else if (string.IsNullOrEmpty(txtPreDays.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPreDays, "Present Days Required");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Validation())
            {
                con.dataSend(@"INSERT INTO EmpAttendance
                      (EmpId, Year, Month, TotalDays, WorkingDays, PresentDays, AbsentDays, LopDays) VALUES ('" + txtEmpId.Text + "','" + cmbYear.Text + "','" + cmbMonth.Text + "','" + txtTotalDays.Text + "','" + txtworkDays.Text + "','" + txtPreDays.Text + "','" + txtabsenceDays.Text + "','" + txtlopDays.Text + "')");
                MessageBox.Show("Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
            }
        }
        private void ClearData()
        {
            txtEmpId.Clear();
            txtName.Clear();
            cmbYear.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            txtTotalDays.Clear();
            txtworkDays.Clear();
            txtPreDays.Clear();
            txtabsenceDays.Clear();
            txtlopDays.Clear();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure to Update", "Update", MessageBoxButtons.YesNo);
            if(dialogResult==DialogResult.Yes)
            {
                con.dataSend("UPDATE  EmpAttendance SET  TotalDays ='" + txtTotalDays.Text + "', WorkingDays ='" + txtworkDays.Text + "', PresentDays ='" + txtPreDays.Text + "', AbsentDays ='" + txtabsenceDays.Text + "', LopDays = '" + txtlopDays.Text + "' where EmpId='" + txtEmpId.Text + "' and Year='" + cmbYear.Text + "' and Month='" + cmbMonth.Text + "'");
                MessageBox.Show("Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure to Update", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("Delete From  EmpAttendance  where EmpId='" + txtEmpId.Text + "' and Year='" + cmbYear.Text + "' and Month='" + cmbMonth.Text + "'");
                MessageBox.Show("Delete Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Employe.frmAttendanceView frm = new Employe.frmAttendanceView();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
