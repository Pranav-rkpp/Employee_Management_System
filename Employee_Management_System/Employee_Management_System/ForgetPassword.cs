using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class ForgetPassword : Form
    {
        string randomcode;
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody, to;
            Random random = new Random();
            randomcode = (random.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (tbx_fgp_email.Text).ToString();
            from = "rkpranav11@gmail.com";
            pass = "uojv punu gsyj lddm";
            messageBody = "Your OTP Code : " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Employee Managemen Verification";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP Sended Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (randomcode == (tbx_fgp_otp.Text.Trim()).ToString())
            {
                MessageBox.Show("OTP Verified Succesfully");
                ChangePassword c = new ChangePassword();
                c.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid OTP");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbx_fgp_otp_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_fgp_email_TextChanged(object sender, EventArgs e)
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
    }
}
