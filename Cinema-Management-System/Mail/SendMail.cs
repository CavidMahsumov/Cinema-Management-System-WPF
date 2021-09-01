using Cinema_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Mail
{
   public  class SendMail
    {
        public static void SendMail1( string mail)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("zormail44@gmail.com", "CavidMahsumov"),
                EnableSsl = true,
            };
            if (!mail.Contains("@gmail.com"))
            {
                mail = "mehsumovcavid@gmail.com";
                smtpClient.Send($"zormail44@gmail.com", mail, "Cinema Management System", "Hello");
            }
        }
    }
}
