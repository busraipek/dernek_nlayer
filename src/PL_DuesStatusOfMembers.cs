using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class PL_DuesStatusOfMembers : Form
    {
        private BusinessLayer.BL_SendEmail pl_sendmail;
        private BusinessLayer.BL_MemberList pl_memberlist;
        public PL_DuesStatusOfMembers()
        {
            pl_memberlist = new BusinessLayer.BL_MemberList();
            pl_sendmail = new BusinessLayer.BL_SendEmail();
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                richTextBox1.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Enabled = false;
                richTextBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> postalist = new List<string>();
                pl_sendmail.SendMail(postalist,textBox1.Text, richTextBox1.Text);
                MessageBox.Show("Mail gönderildi.");
            }
            catch
            {
                MessageBox.Show("Mail gönderilemedi.");
            }
        }

        private void PL_DuesStatusOfMembers_Load(object sender, EventArgs e)
        {
            try
            {
                string[,] membersArray = new string[5, 7];
                pl_memberlist.GetMember(membersArray, 0);
                for (int i = 0; i < membersArray.GetLength(0); i++)
                {
                    dataGridView1.Rows.Add(
                        membersArray[i, 0],
                        membersArray[i, 1],
                        membersArray[i, 2],
                        membersArray[i, 3],
                        membersArray[i, 4],
                        membersArray[i, 5],
                        membersArray[i, 6]
                    );
                }
            }
            catch
            {
                MessageBox.Show("kişi listesi olmadı");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                try
                {
                    dataGridView1.Rows.Clear();
                    string[,] membersArray = new string[5, 7];
                    pl_memberlist.GetMember(membersArray, 1);
                    for (int i = 0; i < membersArray.GetLength(0); i++)
                    {
                        dataGridView1.Rows.Add(
                            membersArray[i, 0],
                            membersArray[i, 1],
                            membersArray[i, 2],
                            membersArray[i, 3],
                            membersArray[i, 4],
                            membersArray[i, 5],
                            membersArray[i, 6]
                        );
                    }
                }
                catch
                {
                    MessageBox.Show("kişi listesi olmadı");
                }
            }
            else if (checkBox2.Checked == false)
            {
                try
                {
                    dataGridView1.Rows.Clear();

                    string[,] membersArray = new string[5, 7];
                    pl_memberlist.GetMember(membersArray, 0);
                    for (int i = 0; i < membersArray.GetLength(0); i++)
                    {
                        dataGridView1.Rows.Add(
                            membersArray[i, 0],
                            membersArray[i, 1],
                            membersArray[i, 2],
                            membersArray[i, 3],
                            membersArray[i, 4],
                            membersArray[i, 5],
                            membersArray[i, 6]
                        );
                    }
                }
                catch
                {
                    MessageBox.Show("kişi listesi olmadı");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                label3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + " TL";
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLE BUTONU

        }
    }
    }

