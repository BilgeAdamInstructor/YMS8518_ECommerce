using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ECommerce.Helper
{
    public class MailHelper
    {
        public class SMTP
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Server { get; set; }
            public int Port { get; set; }
        }

        public class OutgoingEmail
        {
            public int Id { get; set; }
            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
        }

        public static void Send(EventHandler<System.ComponentModel.AsyncCompletedEventArgs> sendCompletedCallback, SMTP smtp, OutgoingEmail outgoingEmail)
        {
            SmtpClient smtpClient = new SmtpClient(smtp.Server, smtp.Port)
            {
                EnableSsl = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtp.Email, smtp.Password)
            };

            MailAddress fromMailAddress = new MailAddress(smtp.Email, "Bilge Adam", Encoding.UTF8);
            MailAddress toMailAddress = new MailAddress(outgoingEmail.To);

            MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress)
            {
                IsBodyHtml = true,
                Body = outgoingEmail.Body,
                Subject = outgoingEmail.Subject,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8
            };
            smtpClient.SendCompleted += new SendCompletedEventHandler((sender, args) => sendCompletedCallback?.Invoke(null, args));
            smtpClient.SendAsync(mailMessage, outgoingEmail.Id);
        }
    }
}