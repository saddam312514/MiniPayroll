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

    public partial class frmpaySlip : Form
    {
        ReportDocument crpty = new ReportDocument();

        public frmpaySlip()
        {
            InitializeComponent();
        }

        float selary = 0;
        float workingDays = 0;
        float present = 0;
        float lop = 0;
        float perDay = 0;
        float income = 0;
        float deductions = 0;
        float netSalry = 0;
        Connection con = new Connection();

        private void frmpaySlip_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                con.dataGet(" select * from Payslip where Year='"+comboBox1.Text+"' and Month='"+comboBox2.Text+"' and EmpId='"+textBox1.Text+"'");
                DataTable  dt = new DataTable();
                con.sda.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    selary = float.Parse(dt.Rows[0]["Selary"].ToString());
                    workingDays = float.Parse(dt.Rows[0]["WorkingDays"].ToString());
                    present = float.Parse(dt.Rows[0]["PresentDays"].ToString());
                    lop = float.Parse(dt.Rows[0]["LopDays"].ToString());
                    perDay = (selary / 12) / workingDays;
                    income = perDay * present;
                    deductions = perDay * lop;
                    netSalry = income - deductions;
                    con.dataGet(" select * from Payslip where Year='" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and EmpId='" + textBox1.Text + "'");

                    DataSet dst = new DataSet();
                    con.sda.Fill(dst, "PaySlip");
                    crpty.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\PaySlip.rpt");
                    crpty.SetDataSource(dst);
                    crpty.SetParameterValue("@Income", income);
                    crpty.SetParameterValue("@deduction", deductions);
                   
                    crpty.SetParameterValue("@Selary", netSalry);
                    crystalReportViewer1.ReportSource = crpty;



                }
                else
                {
                    crystalReportViewer1.ReportSource = null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(textBox1.Text);
            textBox1.Text = (empId - 1).ToString() ;

            con.dataGet(" select * from Payslip where Year='" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and EmpId='" + textBox1.Text + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                selary = float.Parse(dt.Rows[0]["Selary"].ToString());
                workingDays = float.Parse(dt.Rows[0]["WorkingDays"].ToString());
                present = float.Parse(dt.Rows[0]["PresentDays"].ToString());
                lop = float.Parse(dt.Rows[0]["LopDays"].ToString());
                perDay = (selary / 12) / workingDays;
                income = perDay * present;
                deductions = perDay * lop;
                netSalry = income - deductions;
                con.dataGet(" select * from Payslip where Year='" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and EmpId='" + textBox1.Text + "'");

                DataSet dst = new DataSet();
                con.sda.Fill(dst, "PaySlip");
                crpty.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\PaySlip.rpt");
                crpty.SetDataSource(dst);
                crpty.SetParameterValue("@Income", income);
                crpty.SetParameterValue("@deduction", deductions);

                crpty.SetParameterValue("@Selary", netSalry);
                crystalReportViewer1.ReportSource = crpty;



            }
            else
            {
                crystalReportViewer1.ReportSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(textBox1.Text);
            textBox1.Text = (empId + 1).ToString();

            con.dataGet(" select * from Payslip where Year='" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and EmpId='" + textBox1.Text + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                selary = float.Parse(dt.Rows[0]["Selary"].ToString());
                workingDays = float.Parse(dt.Rows[0]["WorkingDays"].ToString());
                present = float.Parse(dt.Rows[0]["PresentDays"].ToString());
                lop = float.Parse(dt.Rows[0]["LopDays"].ToString());
                perDay = (selary / 12) / workingDays;
                income = perDay * present;
                deductions = perDay * lop;
                netSalry = income - deductions;
                con.dataGet(" select * from Payslip where Year='" + comboBox1.Text + "' and Month='" + comboBox2.Text + "' and EmpId='" + textBox1.Text + "'");

                DataSet dst = new DataSet();
                con.sda.Fill(dst, "PaySlip");
                crpty.Load(@"C:\Users\sd\documents\visual studio 2015\Projects\MiniPayroll\MiniPayroll\Report\PaySlip.rpt");
                crpty.SetDataSource(dst);
                crpty.SetParameterValue("@Income", income);
                crpty.SetParameterValue("@deduction", deductions);

                crpty.SetParameterValue("@Selary", netSalry);
                crystalReportViewer1.ReportSource = crpty;



            }
            else
            {
                crystalReportViewer1.ReportSource = null;
            }
        }
    }
}
