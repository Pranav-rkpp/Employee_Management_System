using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace Employee_Management_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        
        public bool isEmailValid(string email)
        {
            string pattern = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";
            Regex r = new Regex(pattern);
            return r.IsMatch(email);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_Reg_Username.Text.Trim() != "" && tbx_reg_SetPassword.Text.Trim() != "" && tbx_reg_cpassword.Text.Trim() != "" && tbx_reg_email.Text.Trim() != "" && tbx_reg_mblNo.Text.Trim() != "")
                {
                    string emailAddress = tbx_reg_email.Text.Trim();
                    bool isValid = isEmailValid(emailAddress);
                    if (isValid)
                    {

                        if (tbx_reg_SetPassword.Text.Trim().Length >= 8)
                        {
                            if (tbx_reg_SetPassword.Text.Trim() == tbx_reg_cpassword.Text.Trim())
                            {

                                SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
                                con.Open();
                                SqlCommand cmd = new SqlCommand("sp_register1", con);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
                                cmd.Parameters.Add(p1).Value = tbx_Reg_Username.Text.Trim();

                                SqlParameter p2 = new SqlParameter("@spassword", SqlDbType.VarChar);
                                cmd.Parameters.Add(p2).Value = tbx_reg_SetPassword.Text.Trim();

                                SqlParameter p3 = new SqlParameter("@cpassword", SqlDbType.VarChar);
                                cmd.Parameters.Add(p3).Value = tbx_reg_cpassword.Text.Trim();

                                SqlParameter p4 = new SqlParameter("@email", SqlDbType.VarChar);
                                cmd.Parameters.Add(p4).Value = tbx_reg_email.Text.Trim();

                                SqlParameter p5 = new SqlParameter("@mblnum", SqlDbType.VarChar);
                                cmd.Parameters.Add(p5).Value = tbx_reg_mblNo.Text.Trim();

                                int a = cmd.ExecuteNonQuery();

                                if (a > 0) MessageBox.Show("Registered Successfully...");
                                else
                                {
                                    MessageBox.Show("Registration Failed..");
                                    con.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Confirm password not match with set password...");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password must be atleast 8 character...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter valid email id..");
                    }
                }
                else
                {
                    MessageBox.Show("Fill all the box!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbx_Reg_Username.Clear();
            tbx_reg_SetPassword.Clear();
            tbx_reg_cpassword.Clear();
            tbx_reg_email.Clear();
            tbx_reg_mblNo.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else WindowState = FormWindowState.Normal;
        }
    }
}
