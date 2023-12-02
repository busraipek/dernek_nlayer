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
        public void UpdateMember(string member,string due)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            {
                connection.Open();

                string query = "UPDATE uye SET uyelik_durumu = 42 WHERE e_name =’sam’"; 
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            City city = new City()
                            {
                                sehir = reader["sehir"].ToString(),
                            };

                           // cities.Add(city.sehir.ToString());
                        }
                    }
                }
            }

        }
    }
}
