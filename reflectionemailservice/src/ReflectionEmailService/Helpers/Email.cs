using Microsoft.Extensions.Options;
using ReflectionEmailService.Helpers.Interface;
using ReflectionEmailService.Models;
using System.Net;
using System.Net.Mail;

namespace ReflectionEmailService.Helpers
{
    internal class Email : IEmail
    {
        private IOptions<envSettings> _options;
        public Email(IOptions<envSettings> options)
        {
            _options = options;
        }
        public void SendEmail(string mailto, string emailBody, string subject)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = _options.Value.smtpPort;
            smtp.Host = _options.Value.smtpHost;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_options.Value.mailCredUsername, _options.Value.mailCredPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(CreateMailMessage(mailto, emailBody, subject));
        }
        private MailMessage CreateMailMessage(string mailto, string emailBody, string subject)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_options.Value.mailCredUsername);
            message.To.Add(new MailAddress(mailto));
            message.Subject = subject;
            message.Body = emailBody;
            message.IsBodyHtml = true; //to make message body as html 
            return message;
        }
    }
}
