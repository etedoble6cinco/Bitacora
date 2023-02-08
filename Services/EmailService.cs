using BitacoraAPP.Models;
using System.Net;
using System.Net.Mail;

namespace BitacoraAPP.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailFileAsyncService(EmailConfiguration emailConfiguration);
       
    }
    public class EmailService : IEmailService
    {
        public async Task<bool>SendEmailFileAsyncService(EmailConfiguration emailConfiguration)
        {
            //string to = "oanaya@smimx.net";
            // string to2 = "aplumeda@smimx.net";
            string to = emailConfiguration.to;
            string from = emailConfiguration.from;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from, emailConfiguration.EmailHeader);
            message.Subject = emailConfiguration.EmailSubject;
            message.To.Add(to);
         
            message.IsBodyHtml = true;
                        
            SmtpClient client = new SmtpClient(emailConfiguration.SmtpServer, emailConfiguration.Port);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, emailConfiguration.Password);
            message.Attachments.Add(new Attachment(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Excel", emailConfiguration.EmailFileLocation)));
            try
            {
               await client.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

        }
    }
}
