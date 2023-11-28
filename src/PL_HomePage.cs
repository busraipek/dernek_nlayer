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
    public partial class PL_HomePage : Form
    {
        BusinessLayer.BL_SendEmail pl_sendemail;
        BusinessLayer.BL_MemberList pl_memberlist;

        public PL_HomePage()
        {
            InitializeComponent();
            pl_sendemail = new BL_SendEmail();
            pl_memberlist = new BL_MemberList();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {          
                string[,] membersArray = new string[100,9];
                pl_memberlist.GetMember(membersArray);

                        for (int i = 0; i < membersArray.GetLength(0); i++)
                        {
                            dataGridView1.Rows.Add(
                                membersArray[i, 0],
                                membersArray[i, 1],
                                membersArray[i, 2],
                                membersArray[i, 3],
                                membersArray[i, 4],
                                membersArray[i, 5],
                                membersArray[i, 6],
                                membersArray[i, 7],
                                membersArray[i, 8]
                            );
                        }
                }
            catch
            {
                MessageBox.Show("Kişi listesi oluşturulamadı");
            }
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL_AddMember PL_AddMember = new PL_AddMember();
            PL_AddMember.StartPosition = FormStartPosition.CenterScreen;
            PL_AddMember.Show();
        }

        private void üyelikDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           List<string> cinsiyet = new List<string> { "Kadın", "Erkek" };
            foreach (string veri in cinsiyet)
            {
                toolStripComboBox1.Items.Add(veri);
            }
            toolStripComboBox1.Text = cinsiyet[0];
        }
    }
}
