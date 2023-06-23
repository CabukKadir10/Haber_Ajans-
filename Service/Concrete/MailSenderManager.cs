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
            var fromAddress = new MailAddress("GönderenMail@zohomail.eu");
            var toAddress = new MailAddress("AlıcıMail@gmail.com");
            const string subject = "Haber Ajansı | Reshoo Deneme Maili";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.zoho.eu",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "Password")
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
