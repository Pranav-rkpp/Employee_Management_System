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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                MessageBox.Show("Logout Successfully...");
                Login l = new Login();
                this.Hide();
                l.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_emp_register", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = tbx_emp_ID.Text.Trim();

                SqlParameter p2 = new SqlParameter("@emp_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = tbx_emp_name.Text.Trim();

                SqlParameter p3 = new SqlParameter("@emp_salary", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = tbx_emp_salary.Text.Trim();

                SqlParameter p4 = new SqlParameter("@emp_department", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = cbx_emp_dept.SelectedItem.ToString();

                SqlParameter p5 = new SqlParameter("@emp_role", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = cbx_emp_role.SelectedItem.ToString();

                int a = cmd.ExecuteNonQuery();

                if (a > 0) MessageBox.Show("Employee detail added Successfully...");
                else
                {
                    MessageBox.Show("!!!Failed..");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you want to Delete Employee?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = tbx_emp_search.Text.Trim();

                int a = cmd.ExecuteNonQuery();

                if (a > 0) MessageBox.Show("Employee detail deleted Successfully...");
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_search", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@searchdata", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = tbx_emp_search.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-LNB2K9V\\SQLEXPRESS;Initial Catalog=employeemanagement;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = tbx_emp_ID.Text.Trim();

                SqlParameter p2 = new SqlParameter("@emp_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = tbx_emp_name.Text.Trim();

                SqlParameter p3 = new SqlParameter("@emp_salary", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = tbx_emp_salary.Text.Trim();

                SqlParameter p4 = new SqlParameter("@emp_department", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = cbx_emp_dept.SelectedItem.ToString();

                SqlParameter p5 = new SqlParameter("@emp_role", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = cbx_emp_role.SelectedItem.ToString();

                int a = cmd.ExecuteNonQuery();

                if (a > 0) MessageBox.Show("Employee detail updated Successfully...");
                else
                {
                    MessageBox.Show("!!!Updation Failed..");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Bitmap b = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(b, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(b, 120, 120);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tbx_emp_ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tbx_emp_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbx_emp_salary.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cbx_emp_dept.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cbx_emp_role.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
