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
    public partial class PL_CurrentDue : Form
    {
        private BusinessLayer.BL_DueList pl_duelist;
        public PL_CurrentDue()
        {
            pl_duelist = new BusinessLayer.BL_DueList();
            InitializeComponent();
        }

        private void PL_CurrentDue_Load(object sender, EventArgs e)
        {
            try
            {
                string[,] membersArray = new string[4, 2];
                pl_duelist.GetDues(membersArray);
                for (int i = 0; i < membersArray.GetLength(0); i++)
                {
                    dataGridView1.Rows.Add(
                        membersArray[i, 0]+ " TL",
                        membersArray[i, 1]
                   );
                }
            }
            catch
            {
                MessageBox.Show("Aidat listesi hazırlanırken bir hata oluştu. ");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                dateTimePicker1.Enabled = true;

            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }
    }
}
