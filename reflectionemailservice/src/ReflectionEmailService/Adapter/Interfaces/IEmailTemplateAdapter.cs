using System.Runtime.CompilerServices;
using ReflectionEmailService.Models;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("ReflectionEmailService.Tests")]
namespace ReflectionEmailService.Adapter.Interfaces
{
    internal interface IEmailTemplateAdapter
    {
        EmailTemplate GetEmailTemplates(string type);
        void InsertEmailRequest(EmailRequest emailRequest);
        void UpdateEmailTemplate(EmailTemplate template);

    }
}
