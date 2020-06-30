using ReflectionEmailService.Models;

namespace ReflectionEmailService.BusinessLogic.Interface
{
    public interface IEmailServiceBusinessLogic
    {
        void SendBlindSpotMail(EmailRequest emailRequest);
        public void SendMailToUser(EmailRequest emailRequest);
        public void SendMailToAdmin(EmailRequest emailRequest);
        EmailTemplate GetEmailTemplate(string type);
        void UpdateEmailTemplate(EmailTemplate template);
    }
}
