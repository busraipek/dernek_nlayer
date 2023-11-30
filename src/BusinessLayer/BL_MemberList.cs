using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BL_MemberList
    {
        public void GetMember(string[,] membersArray)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            {
                try
                {
                    connection.Open();
                    string query = "SELECT u.ad, u.soyad, u.e_posta, a.tarih, a.ucret, ad.durum FROM aidat AS a INNER JOIN aidat_durum AS ad ON a.id = ad.aidat_id INNER JOIN uye AS u ON ad.kimlik_no = u.kimlik_no";
                    using (OleDbCommand komut = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = komut.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                DuesStatus member = new DuesStatus()
                                {
                                    ad = reader["ad"].ToString(),
                                    soyad = reader["soyad"].ToString(),
                                    e_posta = reader["e_posta"].ToString(),
                                    tarih = (DateTime)reader["tarih"],
                                    ucret = (int)reader["ucret"],
                                    durum = reader["durum"].ToString(),
                                };
                                membersArray[i, 0] = member.ad;
                                membersArray[i, 1] = member.soyad;
                                membersArray[i, 2] = member.tarih.ToString("dd/MM/yyyy"); // DateTime'i string'e dönüştür
                                membersArray[i, 3] = member.durum;
                                membersArray[i, 4] = member.ucret.ToString() ;
                                membersArray[i, 5] = member.e_posta;
                                i = i + 1;
                            }
                            reader.Close();
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}

