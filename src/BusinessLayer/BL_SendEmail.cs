using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.OleDb;


namespace BusinessLayer
{
    public class BL_SendEmail
    {
            private DataAccessLayer.Sender sender;
            public BL_SendEmail()
            {
                sender = new DataAccessLayer.Sender();
            }
            public void SendMail(string baslik, string konu)
            {
            //OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=C:\\Users\\90505\\Desktop\\Database4.accdb");
            //{
            //    connection.Open();

            //    string query = "SELECT sehir FROM sehir";
            //    using (OleDbCommand command = new OleDbCommand(query, connection))
            //    {
            //        using (OleDbDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                City city = new City()
            //                {
            //                    sehir = reader["sehir"].ToString(),
            //                };

            //                cities.Add(city.sehir.ToString());
            //            }
            //        }
            //    }
            //}

            SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(sender.senderEmail, sender.senderpassword);
                smtp.Host = sender.smtphost;
                smtp.Port = sender.smtpport;
                smtp.EnableSsl = true;
                sender.baslik = baslik;
                sender.konu = konu;
                MailMessage message = new MailMessage(sender.senderEmail, "aysegulkubraipek@gmail.com", baslik, konu);
                smtp.Send(message);
            }
        }
    }

