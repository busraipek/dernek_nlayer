using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BL_AddMember
    {
        private DataAccessLayer.Member member;
        public BL_AddMember()
        {
            member = new DataAccessLayer.Member();
        }
        public void AddMember(string ad,string soyad,string cins, DateTime dt, string kn, string kg,string uye, string ep,string sehir)
        {

            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");               
                if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            try
            {
                OleDbCommand komut = new OleDbCommand("insert into uye" +
                "(ad,soyad,cinsiyet,dogum_tarihi,kimlik_no,kan_grubu," +
                "uyelik_durumu,e_posta,sehir) values (@ad, @soyad, @cinsiyet, @dogum_tarihi, @kimlik_no, @kan_grubu, " +
                "@uyelik_durumu,@e_posta,@sehir)", connection);

                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@cinsiyet", cins);
                komut.Parameters.AddWithValue("@dogum_tarihi", dt);
                komut.Parameters.AddWithValue("@kimlik_no", kn);
                komut.Parameters.AddWithValue("@kan_grubu", kg);
                komut.Parameters.AddWithValue("@uyelik_durumu", uye);
                komut.Parameters.AddWithValue("@e_posta", ep);
                komut.Parameters.AddWithValue("@sehir", sehir);
                komut.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            }
            catch (Exception)
            {     
          }
             connection.Close();

        }
    }
}
