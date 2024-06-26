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

namespace Employee_Management_System
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_register_tb1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = tbx_cp_uname.Text.Trim();

            SqlParameter p2 = new SqlParameter("@spassword", SqlDbType.VarChar);
            cmd.Parameters.Add(p2).Value = tbx_cp_spwd.Text.Trim();

            SqlParameter p3 = new SqlParameter("@cpassword", SqlDbType.VarChar);
            cmd.Parameters.Add(p3).Value = tbx_cp_cpwd.Text.Trim();

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Password Updation Successfully...");
                Login l = new Login();
                this.Hide();
                l.Show();
            }
            else
            {
                MessageBox.Show("Password Updation Failed..");
                tbx_cp_uname.Clear();
                tbx_cp_spwd.Clear();
                tbx_cp_cpwd.Clear();
            }
        }
    }
}
