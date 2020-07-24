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
        private Mock<HttpContext> _mockHttpContext;
        private FeedbackAdapter _feedbackAdapter;

        [SetUp]
        public void SetUp()
        {
            _mokconfig = new Mock<IOptions<ServiceSettings>>();
            _mokserviceHelper = new Mock<IServiceHelper<HttpWebRequest, BaseHttpResponse>>();
            _moklog = new Mock<ILogger<FeedbackAdapter>>();
            _mokhttpContextAccessor = new Mock<IHttpContextAccessor>();
            _mockHttpContext = new Mock<HttpContext>();
        }

        [Test]
        public void SendNotificationTest()
        {
            //Arrange
            var nofification = new BlindSpotNotification();            
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
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

        [Test]
        public void SaveFeedbackQuestionTest()
        {
            //Arrange
            var feedBack = new Feedback();
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "saveFeedbackQuestion"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.SaveFeedbackQuestion(feedBack);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }

        [Test]
        public void SaveFeedbackReplyTest()
        {
            //Arrange
            var feedBackreply = new FeedbackReply();
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "saveFeedbackReply"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.SaveFeedbackReply(feedBackreply);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }

        [Test]
        public void UpdateOrAddFeedbacksByAdminTest()
        {
            //Arrange
            var feedBacks = new List<Feedback>();
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "updateOrAddFeedbacksByAdmin"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.UpdateOrAddFeedbacksByAdmin(feedBacks);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }

        [Test]
        public void UpdateFeedbackStatusTest()
        {
            //Arrange
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "updateFeedbackStatus"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.UpdateFeedbackStatus(1);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }

        [Test]
        public void SaveBlindSpotNotificatonTest()
        {
            //Arrange
            var nofification = new BlindSpotNotification();
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "saveBlindSpotNotification"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.SaveBlindSpotNotification(nofification);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }

        [Test]
        public void DeleteFeedbackTest()
        {
            //Arrange
   
            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );
            var settings = new ServiceSettings { FeedbackServiceUrl = "http://localhost:8080/Feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.FeedbackServiceUrl + "DeleteFeedback"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            _feedbackAdapter.DeleteFeedback(1);

            //Assert
            _mokserviceHelper.Verify(s => s.CreateWebRequest(It.IsAny<ServiceRequest>()));
            _mokserviceHelper.Verify(s => s.HandleRequest(serviceResponse));
        }

        [Test]
        public void GetFeedbackDetailsForAdminTest()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "[{id:1,'userid':'sample'}]"
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getFeedbackDetailsForAdmin"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _feedbackAdapter.GetFeedbackDetailsForAdmin();

            //Assert
            Assert.AreEqual("sample", actual[0].userid);
        }

        [Test]
        public void GetNotificationListForUserTest()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "[{id:1,'userid':'sample'}]"
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getNotificationListForUser"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _feedbackAdapter.GetNotificationListForUser("sample",1,1);

            //Assert
            Assert.AreEqual("sample", actual[0].userid);
        }

        [Test]
        public void GetNotificationsCountTest()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "1"
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getNotificationsCount"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _feedbackAdapter.GetNotificationsCount("sample");

            //Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GetAdminCommentsTest()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "[{id:1,'userid':'sample'}]"
            };
            Mock<HttpRequest> request = new Mock<HttpRequest>();
            request.Setup(x => x.Headers).Returns(new HeaderDictionary());
            _mockHttpContext.Setup(x => x.Request).Returns(request.Object);

            Mock<IAuthenticationService> auth = new Mock<IAuthenticationService>();
            Mock<IServiceProvider> service = new Mock<IServiceProvider>();
            service.Setup(x => x.GetService(It.IsAny<Type>())
            ).Returns(auth.Object
                );

            _mockHttpContext.Setup(x => x.RequestServices).Returns(
                service.Object);

            _mokhttpContextAccessor.Setup(_ => _.HttpContext).Returns(
_mockHttpContext.Object
                );

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/feedback/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getAdminComments"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _feedbackAdapter = new FeedbackAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _feedbackAdapter.GetAdminComments("sample");

            //Assert
            Assert.AreEqual("sample", actual[0].userid);
        }
    }
}
