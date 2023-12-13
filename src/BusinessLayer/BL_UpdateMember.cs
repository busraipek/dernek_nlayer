using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BL_UpdateMember
    {
        public void UpdateMember(string id, string kimlik, string uyelik, string ucret)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            try
            {
                string komut = "SELECT u.ad, u.soyad, u.e_posta, u.uyelik_durumu, a.tarih, a.ucret, ad.durum, a.id, u.kimlik_no, ad.odeme_tarihi " +
               "FROM aidat a, aidat_durum ad, uye u " +
               "WHERE a.id=ad.aidat_id AND ad.kimlik_no=u.kimlik_no and a.id= " + id + " and u.kimlik_no = '" + kimlik + "' ";
                using (OleDbCommand command = new OleDbCommand(komut, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string comm = "UPDATE aidat_durum set durum = '" + ucret + "' WHERE aidat_id= " + id + " and kimlik_no = '" + kimlik + "' ";
                            using (OleDbCommand comma = new OleDbCommand(comm, connection))
                            {

                                comma.ExecuteNonQuery();
                            }
                            string com = "UPDATE uye set uyelik_durumu = '" + uyelik + "' WHERE kimlik_no = '" + kimlik + "' ";
                            using (OleDbCommand co = new OleDbCommand(com, connection))
                            {
                                co.ExecuteNonQuery();

                            }
                        }
                    }
                }
            }

            catch
            {
                throw;
            }
        }
    }
}
