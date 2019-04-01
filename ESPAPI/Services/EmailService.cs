using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Logging;
namespace ESPAPI.Services
{
    //public class SendEmailService : ISendEmailService
    public  class SendEmailService
    {
        private readonly IConfiguration _configuration;
        //private ILoggerFactory _factory;
        //private ILogger _logger;
        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            //_factory = factory;
            //_logger = factory.CreateLogger(typeof(SendEmailService));

        }

        //public SendEmailService()
        //{
        //}

        public async Task SendEmail(string email, string subject, string message, string ccemail)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = _configuration["Email:Email"],
                        Password = _configuration["Email:Password"]
                    };

                    client.Credentials = credential;
                    client.Host = _configuration["Email:Host"];
                    client.Port = int.Parse(_configuration["Email:Port"]);
                    client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(email));
                        if (ccemail != "")
                        {
                            emailMessage.CC.Add(new MailAddress(ccemail));
                        }

                        emailMessage.From = new MailAddress(_configuration["Email:Email"]);
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                        emailMessage.IsBodyHtml = true;
                        client.Send(emailMessage);
                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error happened in [SendEmail] : " + ex);
            }

        }

        public async Task SendEmailWithAttachment(string email, string subject, string message, string fileName)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = _configuration["Email:Email"],
                        Password = _configuration["Email:Password"]
                    };

                    client.Credentials = credential;
                    client.Host = _configuration["Email:Host"];
                    client.Port = int.Parse(_configuration["Email:Port"]);
                    client.EnableSsl = true;

                    using (var emailMessage = new MailMessage())
                    {
                        emailMessage.To.Add(new MailAddress(email));
                        emailMessage.CC.Add(new MailAddress("harshada@vaspsolutions.com"));
                        emailMessage.From = new MailAddress(_configuration["Email:Email"]);
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                        emailMessage.IsBodyHtml = true;
                        emailMessage.Attachments.Add(new Attachment(fileName));
                        client.Send(emailMessage);
                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
               // _logger.LogError("Error happened in [SendEmailWithAttachment] : " + ex);
            }

        }

        public Task SendEmail(string email, string message)
        {
            throw new NotImplementedException();
        }
    }
}
