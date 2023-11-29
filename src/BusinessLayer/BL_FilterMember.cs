﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BL_FilterMember
    {
        public void FilterMember(string[,] membersArray, string filter, string text)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            {
                string query;
                try
                {
                    connection.Open();
                    if (filter == "ad")
                        query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye where ad ='" + text + "'";
                    else if (filter == "soyad")
                        query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye where soyad ='" + text + "'";
                    else if (filter == "uyelik_durumu")
                        query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye where uyelik_durumu ='" + text + "'";
                    else if (filter == "sehir")
                        query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye where sehir='" + text + "'";
                    else if (filter == "kan_grubu")
                        query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye where kan_grubu ='" + text + "'";
                    else
                        query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye";


                    using (OleDbCommand komut = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = komut.ExecuteReader())
                        {
                            int i = 0;
                            while (reader.Read())
                            {
                                Member member = new Member()
                                {
                                    ad = reader["ad"].ToString(),
                                    soyad = reader["soyad"].ToString(),
                                    cinsiyet = reader["cinsiyet"].ToString(),
                                    dogum_tarihi = (DateTime)reader["dogum_tarihi"],
                                    kimlik_no = reader["kimlik_no"].ToString(),
                                    kan_grubu = reader["kan_grubu"].ToString(),
                                    uyelik_durumu = reader["uyelik_durumu"].ToString(),
                                    e_posta = reader["e_posta"].ToString(),
                                    sehir = reader["sehir"].ToString(),
                                };
                                membersArray[i, 0] = member.ad;
                                membersArray[i, 1] = member.soyad;
                                membersArray[i, 2] = member.cinsiyet;
                                membersArray[i, 3] = member.dogum_tarihi.ToString();
                                membersArray[i, 4] = member.kimlik_no;
                                membersArray[i, 5] = member.kan_grubu;
                                membersArray[i, 6] = member.uyelik_durumu;
                                membersArray[i, 7] = member.e_posta;
                                membersArray[i, 8] = member.sehir;
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