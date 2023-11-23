using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BL_CityList
    {

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\dernek_db.accdb");
            OleDbCommand komut = new OleDbCommand("SELECT * FROM sehir", connection);
            {
                connection.Open();

                string query = "SELECT sehir, plaka FROM sehir";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            City city = new City()
                            {
                                sehir = reader["sehir"].ToString(),
                                plaka = Convert.ToInt32(reader["plaka"])
                            };

                            cities.Add(city);
                        }
                    }
                }
            }
            return cities;
        }
    }
}
