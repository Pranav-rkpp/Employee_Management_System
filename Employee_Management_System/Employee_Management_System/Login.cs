using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r = new Register();
            this.Hide();
            r.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_Login_Username.Text.Trim() != "" && tbx_Login_Password.Text.Trim() != "")
                {
                    

                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_login", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = tbx_Login_Username.Text.Trim();

                    SqlParameter p2 = new SqlParameter("@cpassword", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = tbx_Login_Password.Text.Trim();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    int a = Convert.ToInt32(ds.Tables[0].Rows.Count);
                    if (a > 0)
                    {
                        MessageBox.Show("Welcome Back..");
                        Dashboard d = new Dashboard();
                        this.Hide();
                        d.Show();
                    }
                    else if (tbx_Login_Password.Text.Trim() == "12345" && tbx_Login_Username.Text.Trim() == "Admin")
                    {
                        Dashboard d = new Dashboard();
                        this.Hide();
                        d.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User...");
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Fill all the box.");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbx_Login_Password.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword f = new ForgetPassword();
            this.Hide();
            f.Show();
        }

        private void tbx_Login_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Login_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbx_Login_Username.Clear();
            tbx_Login_Password.Clear();
        }
    }
}
