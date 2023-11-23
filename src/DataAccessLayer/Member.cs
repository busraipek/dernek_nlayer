using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Member
    {
        public int kimlik_no { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public char cinsiyet { get; set; }
        public DateTime dogum_tarihi { get; set; }
        public string kan_grubu { get; set; }
        public string uye_durumu { get; set; }
        public string e_posta { get; set; }
        public int plaka { get; set; }
    }
}
