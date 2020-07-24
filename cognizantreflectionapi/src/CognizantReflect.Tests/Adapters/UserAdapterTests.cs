using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.FeedbackService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class UserAdapterTests
    {
        private Mock<IOptions<ServiceSettings>> _mokconfig;
        private Mock<IServiceHelper<HttpWebRequest, BaseHttpResponse>> _mokserviceHelper;
        private Mock<ILogger<UserAdapter>> _moklog;
        private Mock<IHttpContextAccessor> _mokhttpContextAccessor;
        private Mock<HttpContext> _mockHttpContext;
        private UserAdapter _userAdapter;

        [SetUp]
        public void SetUp()
        {
            _mokconfig = new Mock<IOptions<ServiceSettings>>();
            _mokserviceHelper = new Mock<IServiceHelper<HttpWebRequest, BaseHttpResponse>>();
            _moklog = new Mock<ILogger<UserAdapter>>();
            _mokhttpContextAccessor = new Mock<IHttpContextAccessor>();
            _mockHttpContext = new Mock<HttpContext>();
        }


        [Test]
        public void GetUserListReturnsUserList()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "[{Id:1,'UserId':'sample'}]"
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

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/users/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getUser"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _userAdapter = new UserAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _userAdapter.GetUserList();

            //Assert
            Assert.AreEqual("sample", actual[0].UserId);
        }

        [Test]
        public void GetloggedUser_ReturnsUserDetail()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "{Id:1,'UserId':'sample'}"
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

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/users/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getUser"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _userAdapter = new UserAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _userAdapter.GetloggedUser("anuth","anuth");

            //Assert
            Assert.AreEqual("sample", actual.UserId);
        }

        [Test]
        public void GetUsersByRoleReturnsUserList()
        {
            //Arrange

            var baseHttpResponse = new BaseHttpResponse
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "[{Id:1,'UserId':'sample'}]"
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

            var settings = new ServiceSettings { UserServiceUrl = "http://localhost:8080/users/" };
            var serviceResponse = (HttpWebRequest)WebRequest.Create(new Uri(settings.UserServiceUrl + "getUsersByRole"));
            _mokconfig.Setup(s => s.Value).Returns(settings);
            _mokserviceHelper.Setup(s => s.CreateWebRequest(It.IsAny<ServiceRequest>())).Returns(serviceResponse);
            _mokserviceHelper.Setup(s => s.HandleRequest(serviceResponse)).Returns(baseHttpResponse);

            //Act
            _userAdapter = new UserAdapter(_mokserviceHelper.Object, _mokconfig.Object, _moklog.Object, _mokhttpContextAccessor.Object);
            var actual = _userAdapter.GetUsersByRole("admin");

            //Assert
            Assert.AreEqual("sample", actual[0].UserId);
        }
    }
}
