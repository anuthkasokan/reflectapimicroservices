using CognizantReflect.Api.Helpers.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReflectionEmailService.Adapter.Interfaces;
using ReflectionEmailService.Models;

namespace ReflectionEmailService.Adapter
{
    internal class EmailTemplateAdapter : IEmailTemplateAdapter
    {
        private readonly IMongoClientHelper<EmailTemplate> _emailTemplate;
        private readonly IMongoClientHelper<EmailRequest> _emailRequest;
        private readonly string _emailTemplateCollection;
        private readonly string _emailRequestCollection;

        public EmailTemplateAdapter(IMongoClientHelper<EmailTemplate> emailTemplate, IMongoClientHelper<EmailRequest> emailRequest, IOptions<envSettings> options)
        {
            _emailTemplate = emailTemplate;
            _emailRequest = emailRequest;
            _emailTemplateCollection = options.Value.emailTemplateCollection;
            _emailRequestCollection = options.Value.emailRequestCollection;
        }

        public EmailTemplate GetEmailTemplates(string type)
        {
            var result = _emailTemplate.GetRecords(_emailTemplateCollection, type);
            var template= new EmailTemplate
            {
                body = result.GetValue("body").ToString(),
                headerprefix = result.GetValue("headerprefix").ToString(),
                footer = result.GetValue("footer").ToString(),
                subject = result.GetValue("subject").ToString()
            };
            return template;
        }
        
        public void InsertEmailRequest(EmailRequest emailRequest)
        {
            _emailRequest.InsertOne(emailRequest, _emailRequestCollection);
        }

        public void UpdateEmailTemplate(EmailTemplate template)
        {
           var update = Builders<EmailTemplate>.Update.Set(f=>f.body,template.body).Set(f=>f.footer,template.footer)
               .Set(f=>f.headerprefix,template.headerprefix).Set(f=>f.subject,template.subject);
           var filter = Builders<EmailTemplate>.Filter.Eq(c => c.type, template.type);

           _emailTemplate.UpdateOne(update,filter,_emailTemplateCollection);
        }
    }

}
