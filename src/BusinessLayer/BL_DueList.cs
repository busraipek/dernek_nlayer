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
    public class BL_DueList
    {
        public void GetDues(string[,] dues)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            {
                connection.Open();

                string query = "SELECT tarih, ucret FROM uye";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Due due = new Due()
                            {
                                ucret = (int)reader["ucret"],
                                tarih = (DateTime)reader["tarih"],

                        }; 
                            dues[i, 0] = due.ucret.ToString();
                            dues[i, 1] = due.tarih.ToString("dd/MM/yyyy");
                            i = i + 1;
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
