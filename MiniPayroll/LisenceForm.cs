using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll
{
    public partial class LisenceForm : Form
    {
        public int TotalDaysLeft { get; set; }
        public LisenceForm()
        {
            InitializeComponent();
        }

        private void LisenceForm_Load(object sender, EventArgs e)
        {
            TrialDaysLeftLabel.Text = "You Have"    +TotalDaysLeft+   "Days Left in you trial priod";
            if(TotalDaysLeft > 0)
            {
                ExitBtn.Text = "ContiNue Trial";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValidated())
            {
                try
                {
                    EnterNameAndProductKeyToDB();
                    MessageBox.Show(" Product key successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch(ApplicationException ex)
                {
                    MessageBox.Show("Error" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EnterNameAndProductKeyToDB()
        {
            string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {

                using (SqlCommand cmd = new SqlCommand("UPDATE ProductKey SET [Name]=@Name,[ProductKey]=@ProductKey", conn))

                {
                    cmd.Parameters.AddWithValue("@Name",textBox1.Text);
                    cmd.Parameters.AddWithValue("@ProductKey",maskedTextBox1.Text);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool IsValidated()
        {


            if(textBox1.Text.Trim()==string.Empty)
            {
                MessageBox.Show("Name Is Require", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }

            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("ProductKey Should be long 25 Character", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return false;
            }

            else
            {
                bool isValid = CheckIsProductKeyValid(maskedTextBox1.Text);

                if (!isValid)
                {
                    MessageBox.Show("Product Key Is not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                    return false;
                }  
            }
            return true;
        }

        private bool CheckIsProductKeyValid(string productkey)
        {

            //"Z45JA-6VE4T-DI6T4-KQB8U-OR4AL"
            string part1 = productkey.Substring(3, 2); //JA
            string part2 = productkey.Substring(7, 2); //VE
            string part3 = productkey.Substring(12, 2); //DI
            string part4 = productkey.Substring(19, 2); //QB
            string part5 = productkey.Substring(27, 2); // AL

            productkey = part1 + part2 + part3 + part4 + part5;



            if (productkey!="JAVEDIQBAL")
            {
                return false;
            }
            return true;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            if (TotalDaysLeft == 0)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void LisenceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApplication();
        }
    }
}
