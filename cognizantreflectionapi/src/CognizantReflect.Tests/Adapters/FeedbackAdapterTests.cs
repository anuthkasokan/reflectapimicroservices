using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.FeedbackService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class FeedbackAdapterTests
    {
        private Mock<IOptions<ServiceSettings>> _mokconfig;
        private Mock<IServiceHelper<HttpWebRequest, BaseHttpResponse>> _mokserviceHelper;
        private Mock<ILogger<FeedbackAdapter>> _moklog;
        private Mock<IHttpContextAccessor> _mokhttpContextAccessor;
        private FeedbackAdapter _feedbackAdapter;

        [SetUp]
        public void SetUp()
        {
            _mokconfig = new Mock<IOptions<ServiceSettings>>();
            _mokserviceHelper = new Mock<IServiceHelper<HttpWebRequest, BaseHttpResponse>>();
            _moklog = new Mock<ILogger<FeedbackAdapter>>();
            _mokhttpContextAccessor = new Mock<IHttpContextAccessor>();
        }

        [Ignore("")]
        [Test]
        public void GetCutlturalObservationQuizTest()
        {
            //Arrange
            var nofification = new BlindSpotNotification();            
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            var context = new DefaultHttpContext();

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(context);
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "saveBlindSpotNotification"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.SendNotification(nofification);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }
    }
}
