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
        private BusinessLayer.BL_UpdateMember pl_updatemember;
        public PL_DuesStatusOfMembers()
        {
            pl_memberlist = new BusinessLayer.BL_MemberList();
            pl_sendmail = new BusinessLayer.BL_SendEmail();
            pl_updatemember = new BusinessLayer.BL_UpdateMember();
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
                string[,] membersArray = new string[100, 9];
                pl_memberlist.GetMember(membersArray, 0);
                for (int i = 0; i < membersArray.GetLength(0); i++)
                {
                    if (membersArray[i, 0] != null)
                    {
                        dataGridView1.Rows.Add(
                            membersArray[i, 0],
                            membersArray[i, 1],
                            membersArray[i, 2] + " TL",
                            membersArray[i, 3],
                            membersArray[i, 4],
                            membersArray[i, 5],
                            membersArray[i, 6],
                            membersArray[i, 7],
                            membersArray[i, 8]
                        );
                    }
                    else
                        break;

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
                    string[,] membersArray = new string[100, 9];
                    pl_memberlist.GetMember(membersArray, 1);
                    for (int i = 0; i < membersArray.GetLength(0); i++)
                    {
                        if (membersArray[i, 0] != null)
                        {
                            dataGridView1.Rows.Add(
                            membersArray[i, 0],
                            membersArray[i, 1],
                            membersArray[i, 2] + " TL",
                            membersArray[i, 3],
                            membersArray[i, 4],
                            membersArray[i, 5],
                            membersArray[i, 6],
                            membersArray[i, 7],
                            membersArray[i, 8]
                        );
                        }
                        else
                            break;
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

                    string[,] membersArray = new string[100, 9];
                    pl_memberlist.GetMember(membersArray, 0);

                    for (int i = 0; i < membersArray.GetLength(0); i++)
                    {
                        if (membersArray[i, 0] != null)
                        {
                            dataGridView1.Rows.Add(
                            membersArray[i, 0],
                            membersArray[i, 1],
                            membersArray[i, 2] + " TL",
                            membersArray[i, 3],
                            membersArray[i, 4],
                            membersArray[i, 5],
                            membersArray[i, 6],
                            membersArray[i, 7],
                            membersArray[i, 8]
                        );
                    }
                    else
                        break;
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
                label3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLE BUTONU
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string kimlik = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                string[,] membersArray = new string[100, 9];
                pl_updatemember.UpdateMember(membersArray, id, kimlik, comboBox2.Text, comboBox1.Text);
                for (int i = 0; i < membersArray.GetLength(0); i++)
                {
                    if (membersArray[i, 4] != null)
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(
                        membersArray[i, 0],
                        membersArray[i, 1],
                        membersArray[i, 2] + " TL",
                        membersArray[i, 3],
                        membersArray[i, 4],
                        membersArray[i, 5],
                        membersArray[i, 6],
                        membersArray[i, 7],
                        membersArray[i, 8]
                    );
                    }
                    else
                        break;
                    MessageBox.Show("güncellendi");
                }
            }
            catch
            {
                MessageBox.Show("Aidat listesi hazırlanırken bir hata oluştu. ");
            }

        }
    }
    }

