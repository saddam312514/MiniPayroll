using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPayroll.Employe
{
    public partial class frmEmploye : Form
    {
        string fileName;




        public frmEmploye()
        {
            InitializeComponent();
        }
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (ifEmployeeExists(txtName.Text, txtMobile.Text, txtPanNo.Text))
                {
                    MessageBox.Show("Employee Already Exists");
                }
                else
                {
                    con.dataSend(@"INSERT INTO Employee (Name, Mobile, Email, PANNo, Dob, BankDetails, Adress, FileName, ImageData)
                                VALUES ('" + txtName.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "','" + txtPanNo.Text + "','" + txtDate.Value.ToString("MM/dd/yyyy") + "','" + txtBankDetails.Text + "','" + TxtAdress.Text + "','" + fileName + "','" + ConvertImageToBinary(pictureBox1.Image) + "')");
                    MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadData();

                }
            }
        }
        private void ClearData()
        {
            txtName.Clear();
            txtId.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtPanNo.Clear();
            txtDate.Value = DateTime.Now;
            txtBankDetails.Clear();
            TxtAdress.Clear();
            pictureBox1.Image = null;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    label1.Text = fileName;
                    pictureBox1.Image = Image.FromFile(fileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtName.Text.Length>0)
                {
                    txtMobile.Focus();
                }
                else
                {
                    txtName.Focus();
                }
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtEmail.Text.Length > 0)
                {
                    txtPanNo.Focus();
                }
                else
                {
                    txtEmail.Focus();
                }
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMobile.Text.Length > 0)
                {
                    txtEmail.Focus();
                }
                else
                {
                    txtMobile.Focus();
                }
            }
        }

        private void txtPanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPanNo.Text.Length > 0)
                {
                    txtDate.Focus();
                }
                else
                {
                    txtPanNo.Focus();
                }
            }
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBankDetails.Focus();
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar)& (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
            
        }
        private bool Validation()
        {
            bool result = false;
            if(string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name is Requer");

            }
            else if (string.IsNullOrEmpty(txtMobile.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMobile, "Mobile No Required");
            }
            else if (string.IsNullOrEmpty(txtPanNo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPanNo, "PAN No. Required");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmail, "Email Required");
            }
            else if (string.IsNullOrEmpty(TxtAdress.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(TxtAdress, "Address Required");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }


            return result;
        }
        Connection con = new Connection();
        private bool ifEmployeeExists(string name,string mobile,string panNo)
        {
           
            con.dataGet("select 1 from Employee where Name='" + name + "' And Mobile='" + mobile + "' And PANNo='" + panNo + "'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
        private void LoadData()
        {
            con.dataGet("Select * from Employee");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["dgEmpId"].Value = row["EmpId"].ToString();
                dataGridView1.Rows[n].Cells["dgName"].Value = row["Name"].ToString();
                dataGridView1.Rows[n].Cells["dgDob"].Value = Convert.ToDateTime(row["Dob"].ToString()).ToString("dd/MM/yyyy");
                dataGridView1.Rows[n].Cells["dgEmail"].Value = row["Email"].ToString();
                dataGridView1.Rows[n].Cells["dgMobile"].Value = row["Mobile"].ToString();
                dataGridView1.Rows[n].Cells["dgPan"].Value = row["PANNo"].ToString();
                dataGridView1.Rows[n].Cells["dgBank"].Value = row["BankDetails"].ToString();
                dataGridView1.Rows[n].Cells["dgAddress"].Value = row["Adress"].ToString();
                dataGridView1.Rows[n].Cells["dgFileName"].Value = row["FileName"].ToString();
                dataGridView1.Rows[n].Cells["dgImageData"].Value = row["ImageData"].ToString();
            }
        }

        private void frmEmploye_Load(object sender, EventArgs e)
        {
            LoadData();
           
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                txtId.Text = dataGridView1.SelectedRows[0].Cells["dgEmpId"].Value.ToString();
                txtName.Text = dataGridView1.SelectedRows[0].Cells["dgName"].Value.ToString();
                txtMobile.Text = dataGridView1.SelectedRows[0].Cells["dgMobile"].Value.ToString();
                txtEmail.Text = dataGridView1.SelectedRows[0].Cells["dgEmail"].Value.ToString();
                txtPanNo.Text = dataGridView1.SelectedRows[0].Cells["dgPan"].Value.ToString();
                //txtDate.Text = dataGridView1.SelectedRows[0].Cells["dgDob"].Value.ToString();
                txtBankDetails.Text = dataGridView1.SelectedRows[0].Cells["dgBank"].Value.ToString();
                TxtAdress.Text = dataGridView1.SelectedRows[0].Cells["dgAddress"].Value.ToString();
                label1.Text = dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString();
                 pictureBox1.Image = Image.FromFile(dataGridView1.SelectedRows[0].Cells["dgFileName"].Value.ToString());
                button3.Enabled = false;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Update", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("UPDATE Employee SET Email = '" + txtEmail.Text + "', BankDetails = '" + txtBankDetails.Text + "', adress ='" + TxtAdress.Text + "', FileName ='" + fileName + "', ImageData ='" + ConvertImageToBinary(pictureBox1.Image) + "' Where EmpId = '" + txtId.Text + "'");
                MessageBox.Show("Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Delete", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("Delete From Employee Where EmpId = '" + txtId.Text + "'");
                MessageBox.Show("Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
    }
}
