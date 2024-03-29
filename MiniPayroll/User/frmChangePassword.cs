﻿using System;
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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox2.Focus();
                }
                else
                {
                    textBox1.Focus();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text.Length > 0)
                {
                    textBox3.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Length > 0)
                {
                    textBox4.Focus();
                }
                else
                {
                    textBox3.Focus();
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text.Length > 0)
                {
                    button1.Focus();
                }
                else
                {
                    textBox4.Focus();
                }
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Change Password", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Connection con = new Connection();
                con.dataGet("Select 1 from [User] where UserName = '" + textBox1.Text + "' and Password='" + textBox2.Text + "'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        if (textBox3.Text.Length > 3)
                        {
                            con.dataSend("Update [User] Set Password='" + textBox3.Text + "' where UserName='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'");
                            MessageBox.Show("Password changed Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox3, "Please enter minimum 4 Character Password");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox3, "Password Mismatch");
                        errorProvider1.SetError(textBox4, "Password Mismatch");
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Please Check UserName and Password");
                    errorProvider1.SetError(textBox2, "Please Check UserName and Password");
                }
            }

        }
        }
    }

