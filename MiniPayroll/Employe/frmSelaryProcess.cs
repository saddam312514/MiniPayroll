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
    public partial class frmSelaryProcess : Form
    {
        public frmSelaryProcess()
        {
            InitializeComponent();
        }

        float salary = 0;
        float workingDays = 0;
        float present = 0;
        float lop = 0;
        float perDay = 0;
        float netSalary = 0;
        Connection con = new Connection();

        private void button1_Click(object sender, EventArgs e)
        {
            con.dataGet("Select * from EmpAttendance Where EmpId='"+txtEmpId.Text+"' And Year = '" + cmbYear.Text + "' and Month = '" + cmbMonth.Text + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    con.dataGet(@"SELECT ES.Selary, EA.WorkingDays, EA.PresentDays, EA.LopDays FROM EmpAttendance EA INNER JOIN EmpSalary ES ON EA.EmpId = ES.EmpId 
                              Where EA.Year = '" + cmbYear.Text + "' and EA.Month = '" + cmbMonth.Text + "' and  EA.EmpId = '" + dt.Rows[0]["EmpId"].ToString() + "'");
                    DataTable dt1 = new DataTable();
                    con.sda.Fill(dt1);
                    salary = float.Parse(dt1.Rows[0]["Selary"].ToString());
                    workingDays = float.Parse(dt1.Rows[0]["WorkingDays"].ToString());
                    present = float.Parse(dt1.Rows[0]["PresentDays"].ToString());
                    lop = float.Parse(dt1.Rows[0]["LopDays"].ToString());
                    perDay = (salary / 12) / workingDays;
                    netSalary = (perDay * present) - (perDay * lop);
                    con.dataSend("INSERT INTO SalaryProcess (EmpId, Year, Month,date, NetSalary) VALUES ('" + dt.Rows[0]["EmpId"].ToString() + "','" + cmbYear.Text + "','" + cmbMonth.Text + "','"+processDate.Value.ToString("MM/dd/yyyy")+"','" + netSalary + "')");
                    MessageBox.Show("Salary Generated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //LoadData();
                }
            }
        }
        void LoadData()

        {
            try
            {
                con.dataGet("Select SalaryProcess.*, Employee.Name from Employee Inner Join SalaryProcess on Employee.EmpId = SalaryProcess.EmpId ");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpId"].Value = row["EmpId"].ToString();
                        dataGridView1.Rows[n].Cells["dgName"].Value = row["Name"].ToString();
                        dataGridView1.Rows[n].Cells["dgYear"].Value = row["Year"].ToString();
                        dataGridView1.Rows[n].Cells["dgMonth"].Value = row["Month"].ToString();
                        dataGridView1.Rows[n].Cells["dgDate"].Value = row["date"].ToString();
                        dataGridView1.Rows[n].Cells["dgSalary"].Value = row["NetSalary"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

                con.dataGet("Select SalaryProcess.*, Employee.Name from Employee Inner Join SalaryProcess on Employee.EmpId = SalaryProcess.EmpId Where SalaryProcess.EmpId='"+txtEmpId.Text+"' and   SalaryProcess.Year = '" + cmbYear.Text + "' and SalaryProcess.Month = '" + cmbMonth.Text + "'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["dgEmpId"].Value = row["EmpId"].ToString();
                        dataGridView1.Rows[n].Cells["dgName"].Value = row["Name"].ToString();
                        dataGridView1.Rows[n].Cells["dgYear"].Value = row["Year"].ToString();
                        dataGridView1.Rows[n].Cells["dgMonth"].Value = row["Month"].ToString();
                        dataGridView1.Rows[n].Cells["dgSalary"].Value = row["NetSalary"].ToString();
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
