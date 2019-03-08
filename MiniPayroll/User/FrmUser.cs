using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll.User
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(txtName.Text.Length>0)
                {
                    txtUserName.Focus();
                }
                else
                {
                    txtName.Focus();
                }
            }
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtName;
            button2.Enabled = false;
            button3.Enabled = false;
            LoadData();

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUserName.Text.Length > 0)
                {
                    textBox3.Focus();
                }
                else
                {
                    txtUserName.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Length > 0)
                {
                    textBox5.Focus();
                }
                else
                {
                    textBox3.Focus();
                }
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    textBox4.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
        }
       private void clearData()
        {
            txtName.Text = "";
            txtUserName.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            button2.Enabled = false;
            button3.Enabled = false;

        }
        private bool Validation()
        {
            bool result = false;

            if(string.IsNullOrEmpty(txtName.Text))

            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name is Requer");
            }

            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUserName, "User Name Required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Password Required");
            }
            else if (textBox3.Text.Length < 4)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Password Minimum 4 Character Required");
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Email Required");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBox1, "Select Role");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }

            return result;
        }
        private bool IfUserNameExits(string userName)
        {
            Connection con = new Connection();
            con.dataGet("select 1 from [User] where UserName='" + userName + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if(dt.Rows.Count>0)
            
                return true;
                else
                return false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Validation())
            {
                if(IfUserNameExits(txtUserName.Text))
                {
                    MessageBox.Show("User Name Already Exit");
                }
                else
                {
                    Connection con = new Connection();
                    con.dataSend("INSERT INTO [User](Name, Email, UserName, Password, Role, Dob, Adress)VALUES('" + txtName.Text + "','" + textBox5.Text + "','" + txtUserName.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox4.Text + "')");
                    MessageBox.Show("Insert successfully");
                    clearData();
                    LoadData();
                }
            }
        }
        private void LoadData()
        {
            try
            {
                Connection con = new Connection();
                con.dataGet("Select * from [User]");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells["dgSno"].Value = n + 1;
                    dataGridView1.Rows[n].Cells["dgName"].Value = row["Name"].ToString();
                    //dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["Dob"].ToString());
                    dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                    dataGridView1.Rows[n].Cells["dgUserName"].Value = row["UserName"].ToString();
                    dataGridView1.Rows[n].Cells["dgRole"].Value = row["Role"].ToString();
                    dataGridView1.Rows[n].Cells["dgAddress"].Value = row["Adress"].ToString();
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textName.Text = dataGridView1.SelectedRows[0].Cells["dgName"].Value.ToString();
            txtUserName.Text = dataGridView1.SelectedRows[0].Cells["dgUserName"].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells["dgEmail"].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells["dgAddress"].Value.ToString();
           // data.Text = dataGridView1.SelectedRows[0].Cells["dgDob"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["dgRole"].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dailogrEsult = MessageBox.Show("Are you sure Update", "Update", MessageBoxButtons.YesNo);
            if(dailogrEsult==DialogResult.Yes)
            {
                Connection con = new Connection();
                con.dataSend("UPDATE    [User] SET Name ='" + textName.Text + "', Email ='" + textBox5.Text + "', Password ='" + textBox3.Text + "', Role ='" + comboBox1.Text + "', Dob ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', Adress = '" + textBox4.Text + "' where UserName='" + txtUserName.Text + "'");
                MessageBox.Show("Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dailogrEsult = MessageBox.Show("Are you sure Delete", "Delete", MessageBoxButtons.YesNo);
            if (dailogrEsult == DialogResult.Yes)
            {

                Connection con = new Connection();
                con.dataSend("Delete from [User]  where UserName='" + txtUserName.Text + "'");
                MessageBox.Show("Delete Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }

            }
    }
}
