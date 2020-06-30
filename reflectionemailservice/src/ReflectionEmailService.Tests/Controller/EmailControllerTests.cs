using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using ReflectionEmailService.BusinessLogic.Interface;
using ReflectionEmailService.Controllers;
using ReflectionEmailService.Models;

namespace ReflectionEmailService.Tests.Controller
{
    [TestFixture]
    public class EmailControllerTests
    {
        private Mock<IEmailServiceBusinessLogic> _mockEmailBusiness;
        private EmailServiceController _emailServiceController;

        [SetUp]
        public void SetUp()
        {
            _mockEmailBusiness = new Mock<IEmailServiceBusinessLogic>();
            _emailServiceController = new EmailServiceController(_mockEmailBusiness.Object);
        }



        [Test]
        public void sendBlindSpotMail_ReturnsVoid()
        {
            _mockEmailBusiness.Setup(x => x.SendBlindSpotMail(It.IsAny<EmailRequest>()));

            Assert.DoesNotThrow(()=>_emailServiceController.sendBlindSpotMail(new EmailRequest()));
        }

        [Test]
        public void sendMailToUser_ReturnsVoid()
        {
            _mockEmailBusiness.Setup(x => x.SendMailToUser(It.IsAny<EmailRequest>()));

            Assert.DoesNotThrow(() => _emailServiceController.sendMailToUser(new EmailRequest()));
        }

        [Test]
        public void sendMailToAdmin_ReturnsVoid()
        {
            _mockEmailBusiness.Setup(x => x.SendMailToAdmin(It.IsAny<EmailRequest>()));

            Assert.DoesNotThrow(() => _emailServiceController.sendMailToAdmin(new EmailRequest()));
        }

        [Test]
        public void GetEmailTemplate_ReturnsEmailTemplate()
        {
            _mockEmailBusiness.Setup(x => x.GetEmailTemplate(It.IsAny<string>())).Returns(new EmailTemplate
            {
                headerprefix = "Hi"
            });

            var actual = _emailServiceController.GetEmailTemplate("");
            Assert.AreEqual("Hi",actual.headerprefix);
        }

        [Test]
        public void saveEmailTemplate_ReturnsVoid()
        {
            _mockEmailBusiness.Setup(x => x.UpdateEmailTemplate(It.IsAny<EmailTemplate>()));

            Assert.DoesNotThrow(() => _emailServiceController.saveEmailTemplate(new EmailTemplate()));
        }
    }
}
