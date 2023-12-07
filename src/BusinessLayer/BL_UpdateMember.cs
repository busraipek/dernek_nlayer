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
                string komut = "SELECT u.ad, u.soyad, u.e_posta, u.uyelik_durumu, a.tarih, a.ucret, ad.durum, a.id, u.kimlik_no  " +
               "FROM aidat a, aidat_durum ad, uye u " +
               "WHERE a.id=ad.aidat_id AND ad.kimlik_no=u.kimlik_no and a.id= " + id + " and u.kimlik_no = '" + kimlik + "' ";
                using (OleDbCommand command = new OleDbCommand(komut, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //DuesStatus member = new DuesStatus()
                            //{
                            //    tarih = (DateTime)reader["tarih"],
                            //    ucret = Convert.ToInt32(reader["ucret"]),
                            //};
                            //membersArray[i, 4] = member.tarih.ToString();
                            //membersArray[i, 7] = member.ucret.ToString();
                            string comm = "UPDATE aidat_durum set durum = '" + ucret + "' WHERE aidat_id= " + id + " and kimlik_no = '" + kimlik + "' ";
                            using (OleDbCommand comma = new OleDbCommand(comm, connection))
                            {
                                //using (OleDbDataReader read = comma.ExecuteReader())
                                //{
                                comma.ExecuteNonQuery();

                                //while (read.Read())
                                //{
                                //    DuesStatus mem = new DuesStatus()
                                //    {
                                //        durum = ucret,
                                //        aidat_id = read["id"].ToString(),
                                //    };
                                //    membersArray[i, 4] = mem.durum;
                                //    membersArray[i, 7] = mem.aidat_id;
                                //}
                            }
                            string com = "UPDATE uye set uyelik_durumu = '" + uyelik + "' WHERE kimlik_no = '" + kimlik + "' ";
                            using (OleDbCommand co = new OleDbCommand(com, connection))
                            {
                                co.ExecuteNonQuery();
                                //using (OleDbDataReader read = co.ExecuteReader())
                                //{
                                //while (read.Read())
                                //{
                                //    DuesStatus membr = new DuesStatus()
                                //    {
                                //        ad = read["ad"].ToString(),
                                //        soyad = read["soyad"].ToString(),
                                //        e_posta = read["e_posta"].ToString(),
                                //        uyelik_durumu = uyelik,
                                //        kimlik_no = read["kimlik_no"].ToString(),
                                //    };
                                //    membersArray[i, 0] = membr.ad;
                                //    membersArray[i, 1] = membr.soyad;
                                //    membersArray[i, 5] = membr.uyelik_durumu;
                                //    membersArray[i, 6] = membr.e_posta;
                                //    membersArray[i, 8] = membr.kimlik_no;
                            }
                            //DuesStatus member = new DuesStatus()
                            //{
                            //    tarih = (DateTime)reader["tarih"],
                            //    ucret = Convert.ToInt32(reader["ucret"]),
                            //    durum = reader["durum"].ToString(),
                            //    aidat_id = reader["id"].ToString(),
                            //    ad = reader["ad"].ToString(),
                            //    soyad = reader["soyad"].ToString(),
                            //    e_posta = reader["e_posta"].ToString(),
                            //    uyelik_durumu = reader["uyelik_durumu"].ToString(),
                            //   kimlik_no = reader["kimlik_no"].ToString(),
                            //};
                            //membersArray[i, 0] = member.ad;
                            //membersArray[i, 1] = member.soyad;
                            //membersArray[i, 2] = member.ucret.ToString();
                            //membersArray[i, 3] = member.tarih.ToString("dd/MM/yyyy");
                            //membersArray[i, 4] = member.durum;
                            //membersArray[i, 5] = member.uyelik_durumu;
                            //membersArray[i, 6] = member.e_posta;
                            //membersArray[i, 7] = member.aidat_id;
                            //membersArray[i, 8] = member.kimlik_no;
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
