using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MiniPayroll.Model;


namespace MiniPayroll
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connection con = new Connection();
            con.dataGet("select * from [User] where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if(dt.Rows.Count==1)
            {
                if(dt.Rows[0][3].ToString()== "Admin")
                {
                    this.Hide();
                    frmMain frm = new frmMain(dt.Rows[0][3].ToString());
                    frm.Show();
                }

               else if (dt.Rows[0][3].ToString() != "User")
                {
                    this.Hide();
                    frmMain frm = new frmMain(dt.Rows[0][3].ToString());
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Invaild userName and Password==!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User.frmChangePassword frm = new User.frmChangePassword();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckProductKeyDetails();
        }

        private void CheckProductKeyDetails()
        {
            ProductLisence productlisence= GetProductKeyDetails();
            if(productlisence.ProductKey==string.Empty)
            {
                int totaldaysleft = 0;

                if(productlisence.TrialExpiryDate==new DateTime(1900, 1, 1))
                {
                    UpdateTrialExpiryDate();
                    totaldaysleft = FindTotalTrialDaysLeft(DateTime.Now.Date.AddMonths(1), DateTime.Now.Date);
                }
                else
                {
                    totaldaysleft = FindTotalTrialDaysLeft(productlisence.TrialExpiryDate,DateTime.Now.Date);

                }
                ShowLicenseFrom(totaldaysleft);
            }
        }

        private void ShowLicenseFrom(int totaldaysleft)
        {
            LisenceForm lf = new LisenceForm();
            lf.TotalDaysLeft = totaldaysleft;
            lf.ShowDialog();
        }

        private int FindTotalTrialDaysLeft(DateTime trialExpiryDate, DateTime currentDate)

        {
            return Convert.ToInt32((trialExpiryDate - currentDate).TotalDays);
        }

        private void UpdateTrialExpiryDate()
        {
            string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {

                using (SqlCommand cmd = new SqlCommand("UPDATE ProductKey SET [TrialExpiryDate]=@TrialExpiryDate", conn))

                {
                    cmd.Parameters.AddWithValue("@TrialExpiryDate", DateTime.Now.Date.AddMonths(1));
                    

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private ProductLisence GetProductKeyDetails()
        {
            ProductLisence pl = new ProductLisence();
            string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                
                using (SqlCommand cmd=new SqlCommand("Select * from ProductKey", conn))
                {

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    pl.Name = reader["Name"].ToString();
                    pl.ProductKey = reader["ProductKey"].ToString();
                    pl.TrialExpiryDate = Convert.ToDateTime(reader["TrialExpiryDate"]);
                }
                

            }

                return pl;
        }
    }
}
