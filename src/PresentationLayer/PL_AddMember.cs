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
    public partial class PL_AddMember : Form
    {
        private BusinessLayer.BL_CityList pl_citylist;
        
        public PL_AddMember()
        {
            pl_citylist = new BL_CityList();
            InitializeComponent();
        }
        private void PL_AddMember_Load(object sender, EventArgs e)
        {
            try
            {            
            List<string> cinsiyet = new List<string> { "Kadın", "Erkek" };
            foreach (string veri in cinsiyet)
            {
                cb_cinsiyet.Items.Add(veri);
            }
            
            List<string> kangrubu = new List<string> { "0-", "0+", "A-", "A+", "B-", "B+", "AB-", "AB+" };
            foreach (string veri in kangrubu)
            {
                cb_kangrubu.Items.Add(veri);
            }
            
            List<string> uyelik = new List<string> { "Aktif", "Pasif" };
            foreach (string veri in uyelik)
            {
                cb_uyelikdurumu.Items.Add(veri);
            }
                cb_uyelikdurumu.Text = uyelik[0];
                cb_kangrubu.Text = kangrubu[0];
                cb_cinsiyet.Text = cinsiyet[0];
                cb_cinsiyet.DropDownStyle = ComboBoxStyle.DropDownList;
                cb_kangrubu.DropDownStyle = ComboBoxStyle.DropDownList;
                cb_uyelikdurumu.DropDownStyle = ComboBoxStyle.DropDownList;
                cb_sehir.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch
            {
                MessageBox.Show("Form yüklenirken bir hata oluştu.");
                this.Close();
            }
            try
            {
                foreach (var sehir in pl_citylist.GetCities())
                {
                    cb_sehir.Items.Add(sehir.sehir);
                }
                cb_sehir.Text = cb_sehir.Items[0].ToString();
            }
            catch
            {
                MessageBox.Show("şehir listesi oluşturulamadı");
            }
        }
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);
        }
        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
            && !char.IsSeparator(e.KeyChar);

        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
