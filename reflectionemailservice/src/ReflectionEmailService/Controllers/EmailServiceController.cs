using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionEmailService.BusinessLogic.Interface;
using ReflectionEmailService.Models;


namespace ReflectionEmailService.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        private readonly IEmailServiceBusinessLogic _emailServiceBusinessLogic;
        public EmailServiceController(IEmailServiceBusinessLogic emailServiceBusinessLogic)
        {
            _emailServiceBusinessLogic = emailServiceBusinessLogic;
        }
        // POST: <EmailServiceController>
        [HttpPost]
        [Route("[action]")]
        public void sendBlindSpotMail([FromBody] EmailRequest emailRequest)
        {
            _emailServiceBusinessLogic.SendBlindSpotMail(emailRequest);
        }
        [HttpPost]
        [Route("[action]")]
        public void sendMailToUser([FromBody] EmailRequest emailRequest)
        {
            _emailServiceBusinessLogic.SendMailToUser(emailRequest);
        }
        [HttpPost]
        [Route("[action]")]
        public void sendMailToAdmin([FromBody] EmailRequest emailRequest)
        {
            _emailServiceBusinessLogic.SendMailToAdmin(emailRequest);
        }

        [HttpGet("getEmailTemplate/{type}", Name = "GetEmailService")]
        public EmailTemplate GetEmailTemplate(string type)
        {
            return _emailServiceBusinessLogic.GetEmailTemplate(type);
        }

        [HttpPost]
        [Route("[action]")]
        public void saveEmailTemplate([FromBody] EmailTemplate template)
        {
            _emailServiceBusinessLogic.UpdateEmailTemplate(template);
        }
    }
}
