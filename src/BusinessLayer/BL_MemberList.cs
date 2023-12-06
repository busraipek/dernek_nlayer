﻿using System;
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
        public void GetMember(string[,] membersArray,int durum)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            {
                string query;
                try
                {
                    connection.Open();
                    if (durum == 0)
                    {
                    query = "SELECT u.ad, u.soyad, u.e_posta, u.uyelik_durumu, a.tarih, a.ucret, ad.durum, ad.aidat_id, u.kimlik_no " +
               "FROM aidat a, aidat_durum ad, uye u " +
               "WHERE a.id=ad.aidat_id AND ad.kimlik_no=u.kimlik_no";
                    }
                    else
                    {
                    query = "SELECT u.ad, u.soyad, u.e_posta, u.uyelik_durumu, a.tarih, a.ucret, ad.durum, ad.aidat_id, u.kimlik_no" +
                                   "FROM aidat a, aidat_durum ad, uye u " +
                                   "WHERE a.id=ad.aidat_id AND ad.kimlik_no=u.kimlik_no AND ad.durum = 'Ödenmedi'";
                    }


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
                                    ucret = (int)reader["ucret"],
                                    e_posta = reader["e_posta"].ToString(),
                                    tarih = (DateTime)reader["tarih"],
                                    uyelik_durumu = reader["uyelik_durumu"].ToString(),
                                    durum = reader["durum"].ToString(),
                                    aidat_id = reader["aidat_id"].ToString(),
                                    kimlik_no = reader["kimlik_no"].ToString(),
                                };
                                membersArray[i, 0] = member.ad;
                                membersArray[i, 1] = member.soyad;
                                membersArray[i, 2] = member.ucret.ToString() ;
                                membersArray[i, 3] = member.tarih.ToString("dd/MM/yyyy"); // DateTime'i string'e dönüştür
                                membersArray[i, 4] = member.durum;
                                membersArray[i, 5] = member.uyelik_durumu;
                                membersArray[i, 6] = member.e_posta;
                                membersArray[i, 7] = member.aidat_id;
                                membersArray[i, 8] = member.kimlik_no;
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

