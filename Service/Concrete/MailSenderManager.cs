using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class MailSenderManager : IMailSenderService
    {
        public void SendMail(string body)
        {
            var fromAddress = new MailAddress("cabuk0539@zohomail.eu");
            var toAddress = new MailAddress("cabuk0539@gmail.com");
            const string subject = "Haber Ajansı | Kadir Çabuk Deneme Maili";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.zoho.eu",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "U8YdwLAFufvGrk!")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}
