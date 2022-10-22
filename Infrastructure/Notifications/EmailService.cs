using Application.Interfaces;
using Application.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Notifications
{
    public class EmailService : IEmailService
    {
        private readonly Configuration configuration;
        public EmailService(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public void SendEmail(string emailTo, string body, string subject)
        {
            EmailModel emailModel = null;
            try
            {
                emailModel = new EmailModel();
                emailModel.Body = body;
                emailModel.From = configuration.SmtpServer.SenderEmailAddress;
                emailModel.FromName = configuration.SmtpServer.SenderEmailAddress;
                emailModel.IsBodyHtml = true;
                emailModel.Password = configuration.SmtpServer.Password;
                emailModel.Port = configuration.SmtpServer.Port;
                emailModel.SmtpClient = configuration.SmtpServer.Url;
                emailModel.Ssl = configuration.SmtpServer.UseSSL;
                emailModel.Subject = subject;
                emailModel.To = emailTo;
                emailModel.Username = configuration.SmtpServer.Username;
                this.SendEmail(emailModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void SendEmail(EmailModel emailModel)
        {
            try
            {
                if(emailModel != null)
                {
                    using (var message = new MailMessage())
                    {
                        message.To.Add(new MailAddress(emailModel.To));
                        message.From = new MailAddress(emailModel.From, emailModel.FromName);
                        message.Subject = emailModel.Subject;
                        message.Body = emailModel.Body;
                        message.IsBodyHtml = emailModel.IsBodyHtml;
                        using (var client = new SmtpClient(emailModel.SmtpClient))
                        {
                            client.Port = emailModel.Port;
                            client.Credentials = new NetworkCredential(emailModel.Username, emailModel.Password);
                            client.EnableSsl = emailModel.Ssl;
                            client.Send(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
