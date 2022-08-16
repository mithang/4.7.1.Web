using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediHubSC.Web.Helper;
using MimeKit;
using MailKit.Security;

namespace MediHub.Touchee.Core.Emails
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress
            ("MediHub",
                "cs@medihub.com.vn"
            ));
            mimeMessage.To.Add(new MailboxAddress
            ("KH",
                email
            ));
            mimeMessage.Subject = subject; 
            mimeMessage.Body = new TextPart("html")
            {
                Text = message

            };
            
            // mimeMessage = message;
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
               
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("mail.medihub.com.vn", 465, SecureSocketOptions.Auto);
                client.Authenticate(
                    "cs@medihub.com.vn",
                    "302levansy"
                );

                await client.SendAsync(mimeMessage);

                await client.DisconnectAsync(true);
            }

            await Task.FromResult(0);
        }
    }
}
