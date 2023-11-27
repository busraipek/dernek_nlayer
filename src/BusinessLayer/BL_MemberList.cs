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
        public List<Member> GetMember()
        {
            List<Member> members = new List<Member>();
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            { 
            try
            {
                connection.Open();
                    //Emp oemp = new Emp(1234, "Devesh Omar", "GZB");
                    //lEmp.Add(oemp);
                    //oemp = new Emp(1234, "ROLI", "GZB");
                    //lEmp.Add(oemp);

                    string query = "SELECT ad, soyad, cinsiyet, dogum_tarihi, kimlik_no, kan_grubu, uyelik_durumu, e_posta, sehir FROM uye";

                using (OleDbCommand komut = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = komut.ExecuteReader())
                    {
                        while (reader.HasRows)
                        {
                            Member member = new Member()
                            {
                                ad = reader["ad"].ToString(),
                                soyad = reader["soyad"].ToString(),
                                kimlik_no = reader["kimlik_no"].ToString(),
                                cinsiyet = reader["cinsiyet"].ToString(),
                                dogum_tarihi = (DateTime)reader["dogum_tarihi"],
                                kan_grubu = reader["kan_grubu"].ToString(),
                                uye_durumu = reader["uye_durumu"].ToString(),
                                e_posta = reader["e_posta"].ToString(),
                                sehir = reader["sehir"].ToString(),
                            };
                            members.Add(member);
                        }
                    }
                }

            }               
            catch
            {

            }
            return members;
        }
    }
}}
