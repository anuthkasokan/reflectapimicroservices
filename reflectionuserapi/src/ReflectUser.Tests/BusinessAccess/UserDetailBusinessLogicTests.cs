using Moq;
using NUnit.Framework;
using ReflectUser.API.Adapters.Interfaces;
using ReflectUser.API.BusinessAccess;
using ReflectUser.API.Models;
using System.Collections.Generic;

namespace ReflectUser.Tests.BusinessAccess
{
    [TestFixture]
    public class UserDetailBusinessLogicTests
    {
        private Mock<IAdapter> _mokadapter;

        [SetUp]
        public void SetUp()
        {
            _mokadapter = new Mock<IAdapter>();
        }

        [Test]
        public void GetAllUserDetailsForuseridZero()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokadapter.Setup(a => a.GetAllUserDetails()).Returns(response);

            //act
            var userAdapter = new UserDetailBusinessLogic(_mokadapter.Object);
            var detail = userAdapter.GetUserDetails();

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetUserDetailsForuseridNotZero()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokadapter.Setup(a => a.GetUserDetailsById("1")).Returns(response);

            //act
            var userAdapter = new UserDetailBusinessLogic(_mokadapter.Object);
            var detail = userAdapter.GetUserDetails("1");

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetUserDetailsWhereDBReturnsNullSouldCallInsertMethod()
        {
            //arrange
            var response = new List<UserDetails>();
            _mokadapter.Setup(a => a.GetUserDetailsById("1")).Returns(response);
            _mokadapter.Setup(a => a.LastInsertedId()).Returns(0);
            _mokadapter.Setup(a => a.InsertUserDetail(It.IsAny<UserDetails>()));

            //act
            var userAdapter = new UserDetailBusinessLogic(_mokadapter.Object);
            var detail = userAdapter.GetUserDetails("1", "email");

            //assert
            Assert.IsInstanceOf<UserDetails>(detail);
            _mokadapter.Verify(a => a.InsertUserDetail(It.IsAny<UserDetails>()), Times.Once);
        }

        [Test]
        public void GetUserDetailsWhereDBReturnsData()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokadapter.Setup(a => a.GetUserDetailsById("1")).Returns(response);

            //act
            var userAdapter = new UserDetailBusinessLogic(_mokadapter.Object);
            var detail = userAdapter.GetUserDetails("1", "email");

            //assert
            Assert.IsInstanceOf<UserDetails>(detail);
        }

        [Test]
        public void GetUsersByroleReturnsData()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokadapter.Setup(a => a.GetUserDetailsByRole(It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailBusinessLogic(_mokadapter.Object);
            var detail = userAdapter.GetUsersByRole("Admin");

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void FillUserData()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            _mokadapter.Setup(a => a.FillUserData());

            //act
            var userAdapter = new UserDetailBusinessLogic(_mokadapter.Object);
            userAdapter.FillUserData();

            //assert
            _mokadapter.Verify(a => a.FillUserData(), Times.Once); 
        }
    }
}
