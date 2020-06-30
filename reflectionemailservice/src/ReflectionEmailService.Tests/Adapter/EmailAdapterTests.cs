using System;
using System.Collections.Generic;
using System.Text;
using CognizantReflect.Api.Helpers.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using ReflectionEmailService.Adapter;
using ReflectionEmailService.Adapter.Interfaces;
using ReflectionEmailService.Models;

namespace ReflectionEmailService.Tests.Adapter
{
    [TestFixture]
    class EmailAdapterTests
    {
        private Mock<IMongoClientHelper<EmailTemplate>> _mockEmailTemplate = new Mock<IMongoClientHelper<EmailTemplate>>();
        private Mock<IMongoClientHelper<EmailRequest>> _mockEmailRequest = new Mock<IMongoClientHelper<EmailRequest>>();
        private Mock<IOptions<envSettings>> _mockOptions = new Mock<IOptions<envSettings>>();
        private IEmailTemplateAdapter _emailTemplateAdapter;

        [SetUp]
        public void SetUp()
        {
            _mockOptions.Setup(x => x.Value).Returns(new envSettings
            {
                emailRequestCollection = "emailrequest",
                emailTemplateCollection = "emailtemplate"
            });
            _emailTemplateAdapter = new EmailTemplateAdapter(_mockEmailTemplate.Object,_mockEmailRequest.Object,_mockOptions.Object);

        }

        [Test]
        public void GetEmailTemplates_ReturnsTemplate()
        {

            Dictionary<string, string> collection = new Dictionary<string, string>
            {
                {"body", "body"}, {"headerprefix", "hi"}, {"footer", "footer"}, {"subject", "hi"}
            };

            _mockEmailTemplate.Setup(p=>p.GetRecords(It.IsAny<string>(),It.IsAny<string>()))
                .Returns(new BsonDocument(collection));

            var actual = _emailTemplateAdapter.GetEmailTemplates("");
             Assert.AreEqual("hi",actual.headerprefix);
        }

        [Test]
        public void InsertEmailRequest_ReturnsVoid()
        {

            _mockEmailRequest.Setup(x => x.InsertOne(It.IsAny<EmailRequest>(), It.IsAny<string>()));

            Assert.DoesNotThrow(() =>_emailTemplateAdapter.InsertEmailRequest(new EmailRequest()));
        }

        [Test]
        public void UpdateEmailTemplate_ReturnsVoid()
        {
            _mockEmailTemplate.Setup(x => x.UpdateOne(It.IsAny<UpdateDefinition<EmailTemplate>>()
                ,It.IsAny<FilterDefinition<EmailTemplate>>(), It.IsAny<string>()));

            Assert.DoesNotThrow(() => _emailTemplateAdapter.UpdateEmailTemplate(new EmailTemplate()));
        }
    }
}
