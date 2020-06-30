using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using ReflectionEmailService.Adapter.Interfaces;
using ReflectionEmailService.BusinessLogic;
using ReflectionEmailService.BusinessLogic.Interface;
using ReflectionEmailService.Controllers;
using ReflectionEmailService.Helpers.Interface;
using ReflectionEmailService.Models;

namespace ReflectionEmailService.Tests.BusinessLogic
{
    [TestFixture]
    class BusinessLogicTests
    {
        private Mock<IEmailTemplateAdapter> _mockEmailAdapter;
        private Mock<IHttpClientWrapper<UserDetails>> _mockUserDetails;
        private Mock<IEmail> _mockEmail;
        private IEmailServiceBusinessLogic _emailBusinessLogic;

        [SetUp]
        public void SetUp()
        {
           _mockEmailAdapter = new Mock<IEmailTemplateAdapter>();
           _mockUserDetails = new Mock<IHttpClientWrapper<UserDetails>>();
           _mockEmail = new Mock<IEmail>();
           _emailBusinessLogic = new EmailServiceBusinessLogic(_mockEmail.Object, _mockEmailAdapter.Object,_mockUserDetails.Object);
        }

        [Test]
        public void SendBlindSpotMail_ReturnsVoid()
        {
            var emailRequest = new EmailRequest
            {
                coworkers = new List<string>
                {
                    "xyz@gmail.com"
                }
            };
            _mockEmailAdapter.Setup(x => x.GetEmailTemplates(It.IsAny<string>())).Returns(
                new EmailTemplate
                {
                    body = "", footer = "", headerprefix = "", subject = "", type = "blindspot"
                });

            Assert.DoesNotThrow(()=>_emailBusinessLogic.SendBlindSpotMail(emailRequest));
        }

        [Test]
        public void SendMailToUser_ReturnsVoid()
        {
            var emailRequest = new EmailRequest
            {
                mailto = "user@gmail.com",mailtext = "xyz"
            };
            _mockEmailAdapter.Setup(x => x.GetEmailTemplates(It.IsAny<string>())).Returns(
                new EmailTemplate
                {
                    body = "",
                    footer = "",
                    headerprefix = "",
                    subject = "",
                    type = "blindspot"
                });

            Assert.DoesNotThrow(() => _emailBusinessLogic.SendMailToUser(emailRequest));
        }

        [Test]
        public void SendMailToAdmin_ReturnsVoid()
        {
            _mockUserDetails.Setup(u => u.GetData(It.IsAny<string>())).Returns(
                new List<UserDetails>
                {
                    new UserDetails
                    {
                        emailid = "admin@gmail.com"
                    }
                });
            var emailRequest = new EmailRequest
            {
                mailto = "admin@gmail.com",
                mailtext = "xyz"
            };
            _mockEmailAdapter.Setup(x => x.GetEmailTemplates(It.IsAny<string>())).Returns(
                new EmailTemplate
                {
                    body = "",
                    footer = "",
                    headerprefix = "",
                    subject = "",
                    type = "blindspot"
                });

            Assert.DoesNotThrow(() => _emailBusinessLogic.SendMailToAdmin(emailRequest));
        }

        [Test]
        public void GetEmailTemplate_ReturnsVoid()
        {
            _mockEmailAdapter.Setup(m => m.GetEmailTemplates(It.IsAny<string>())).Returns(
                new EmailTemplate
                {
                    headerprefix = "hi"
                });

            var actual = _emailBusinessLogic.GetEmailTemplate("");
            Assert.AreEqual("hi",actual.headerprefix);
        }

        [Test]
        public void UpdateEmailTemplate_ReturnsVoid()
        {
            Assert.DoesNotThrow(() => _emailBusinessLogic.UpdateEmailTemplate(new EmailTemplate()));
        }
    }
}
