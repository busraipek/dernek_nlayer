using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        BusinessLayer.BL_SendEmail pl_sendemail;

        public Form1()
        {
            InitializeComponent();
            pl_sendemail = new BL_SendEmail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            pl_sendemail.SendMail(textBox1.Text, textBox2.Text);
                MessageBox.Show("Mail gönderildi.");
            }
            catch
            {
                MessageBox.Show("Mail gönderilemedi.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PL_AddMember PL_AddMember = new PL_AddMember();           
            PL_AddMember.StartPosition = FormStartPosition.CenterScreen;
            PL_AddMember.Show();
        }
    }
}
