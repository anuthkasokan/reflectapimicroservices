using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ReflectUser.API.BusinessAccess.Interfaces;
using ReflectUser.API.Controllers;
using ReflectUser.API.Models;
using System.Collections.Generic;

namespace ReflectUser.Tests.Controllers
{
    [TestFixture]
    public class UserDetailsControllerTests
    {
        private Mock<IUserDetailBusinessLogic> _mokuserDetailLogic;
        private Mock<ILogger<UserDetailsController>> _moklogger;

        [SetUp]
        public void SetUp()
        {
            _mokuserDetailLogic = new Mock<IUserDetailBusinessLogic>();
            _moklogger = new Mock<ILogger<UserDetailsController>>();
        }

        [Test]
        public void GetAllUsersTest()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokuserDetailLogic.Setup(a => a.GetUserDetails("")).Returns(response);

            //act
            var userController = new UserDetailsController(_moklogger.Object,_mokuserDetailLogic.Object);
            var detail = userController.GetUserById();

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetUserByidTest()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokuserDetailLogic.Setup(a => a.GetUserDetails(It.IsAny<string>())).Returns(response);

            //act
            var userController = new UserDetailsController(_moklogger.Object, _mokuserDetailLogic.Object);
            var detail = userController.GetUserById("id");

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }
        
        [Test]
        public void GetLoggedUserTest()
        {
            //arrange
            var response = new UserDetails { id = 1, emailid = "emailid", role = "admin", updatetimestamp = "date", userid = "11233" };
            _mokuserDetailLogic.Setup(a => a.GetUserDetails(It.IsAny<string>(), It.IsAny<string>())).Returns(response);

            //act
            var userController = new UserDetailsController(_moklogger.Object, _mokuserDetailLogic.Object);
            var detail = userController.GetLoggedUser("id","emailid");

            //assert
            Assert.IsInstanceOf<UserDetails>(detail);
        }

        
        [Test]
        public void GetUsersByroleTest()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokuserDetailLogic.Setup(a => a.GetUsersByRole(It.IsAny<string>())).Returns(response);

            //act
            var userController = new UserDetailsController(_moklogger.Object, _mokuserDetailLogic.Object);
            var detail = userController.GetUsersByRole("role");

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }
    }
}
