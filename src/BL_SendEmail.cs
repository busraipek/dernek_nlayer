using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

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

