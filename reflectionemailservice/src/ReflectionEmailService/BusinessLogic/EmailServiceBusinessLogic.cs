using Newtonsoft.Json;
using ReflectionEmailService.Adapter.Interfaces;
using ReflectionEmailService.BusinessLogic.Interface;
using ReflectionEmailService.Helpers.Interface;
using ReflectionEmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionEmailService.BusinessLogic
{
    internal class EmailServiceBusinessLogic : IEmailServiceBusinessLogic
    {
        private readonly IEmail _email;
        private string _subject;
        private readonly IEmailTemplateAdapter _mailTemplateAdapter;
        private readonly IHttpClientWrapper<UserDetails> _httpClientWrapper;

        public EmailServiceBusinessLogic(IEmail email, IEmailTemplateAdapter mailTemplateAdapter, IHttpClientWrapper<UserDetails> httpClientWrapper)
        {
            _email = email;
            _mailTemplateAdapter = mailTemplateAdapter;
            _httpClientWrapper = httpClientWrapper;
        }
        public void SendBlindSpotMail(EmailRequest emailRequest)
        {

            EmailTemplate mailtemplete = _mailTemplateAdapter.GetEmailTemplates(emailRequest.type);
            foreach (var coworker in emailRequest.coworkers)
            {
                try
                {
                    var mailBody = CreatMailBody(coworker, mailtemplete);
                    emailRequest.subject = _subject;
                    emailRequest.emailbody = mailBody;
                    _email.SendEmail(coworker, mailBody, _subject);
                    emailRequest.status = "Success";
                    _mailTemplateAdapter.InsertEmailRequest(emailRequest);
                }
                catch (Exception)
                {
                    emailRequest.status = "Failed";
                    emailRequest.mailto = coworker;
                    _mailTemplateAdapter.InsertEmailRequest(emailRequest);
                }
            }
        }

        public void SendMailToUser(EmailRequest emailRequest)
        {
            try
            {
                EmailTemplate mailtemplete = _mailTemplateAdapter.GetEmailTemplates(emailRequest.type);
                var mailBody = CreatMailBody(emailRequest.mailto, mailtemplete, emailRequest.mailtext);
                emailRequest.subject = _subject;
                emailRequest.emailbody = mailBody;
                _email.SendEmail(emailRequest.mailto, mailBody, _subject);
                emailRequest.status = "Success";
                _mailTemplateAdapter.InsertEmailRequest(emailRequest);
            }
            catch (Exception)
            {
                emailRequest.status = "Failed";
                _mailTemplateAdapter.InsertEmailRequest(emailRequest);
            }
        }

        public void SendMailToAdmin(EmailRequest emailRequest)
        {
            var userDetails = _httpClientWrapper.GetData("getAdminUsers");            

            EmailTemplate mailtemplete = _mailTemplateAdapter.GetEmailTemplates(emailRequest.type);
            foreach (var admin in userDetails)
            {
                try
                {
                    var mailBody = CreatMailBody(admin.emailid, mailtemplete);
                    emailRequest.subject = _subject;
                    emailRequest.emailbody = mailBody;
                    _email.SendEmail(admin.emailid, mailBody, _subject);
                    emailRequest.status = "Success";
                    _mailTemplateAdapter.InsertEmailRequest(emailRequest);
                }
                catch (Exception)
                {
                    emailRequest.status = "Failed";
                    emailRequest.mailto = admin.emailid;
                    _mailTemplateAdapter.InsertEmailRequest(emailRequest);
                }
            }
        }

        

        private string CreatMailBody(string mailto, EmailTemplate mailtemplete, string mailtext = "")
        {
            _subject = mailtemplete.subject;
            StringBuilder emailBody = new StringBuilder();
            emailBody.Append("<b>" + mailtemplete.headerprefix + " " + mailto.Split("@").FirstOrDefault() + ",</b>");
            emailBody.Append("<br/><br/>");
            emailBody.Append(mailtemplete.body);
            emailBody.Append("<br/><br/>");
            emailBody.Append("<b>" + mailtext + "<b>");
            if (mailtext != "")
                emailBody.Append("<br/><br/>");

            emailBody.Append("<b>" + mailtemplete.footer + "</b>");
            emailBody.Append("<br/>");
            emailBody.Append("<b>Admin<b>");
            emailBody.Append("<br/>");
            emailBody.Append("<b>Cognizant Reflect</b>");
            return emailBody.ToString();
        }

        public EmailTemplate GetEmailTemplate(string type)
        {
            return _mailTemplateAdapter.GetEmailTemplates(type);
        }

        public void UpdateEmailTemplate(EmailTemplate template)
        {
             _mailTemplateAdapter.UpdateEmailTemplate(template);
        }
    }
}
