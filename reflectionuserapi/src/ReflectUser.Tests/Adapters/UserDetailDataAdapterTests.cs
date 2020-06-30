using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using ReflectUser.API.Adapters;
using ReflectUser.API.Helpers.Interfaces;
using ReflectUser.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReflectUser.Tests.Adapters
{
    [TestFixture]
    public class UserDetailDataAdapterTests
    {
        private Mock<IMongoClientHelper<UserDetails>> _mokuserDetails;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private readonly string _userDetailsCollection = "";

        [SetUp]
        public void SetUp()
        {
            _mokuserDetails = new Mock<IMongoClientHelper<UserDetails>>();
            _settings = new Mock<IOptions<MongoDbSettings>>();
        }

        [Test]
        public void GetUserDetailsByIdReturnsValidData()
        {
            //arrange
            string userid = "1";
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserDataById(It.IsAny<FilterDefinition<UserDetails>>(),It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var detail = userAdapter.GetUserDetailsById(userid);

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
            Assert.AreEqual(response.FirstOrDefault().emailid, detail.FirstOrDefault().emailid);
        }

        [Test]
        public void GetUserDetailsByIdReturnsDataByemailid()
        {
            //arrange
            string userid = "1";
            var response = new List<UserDetails>();
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserDataById(It.IsAny<FilterDefinition<UserDetails>>(), It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var detail = userAdapter.GetUserDetailsById(userid);

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetUserDetailsByRoleMongoreturnsNull()
        {
            //arrange
            string role = "Admin";
            var response = new List<UserDetails>();
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserDataById(It.IsAny<FilterDefinition<UserDetails>>(), It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var detail = userAdapter.GetUserDetailsByRole(role);

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetUserDetailsByRoleMongoreturnsData()
        {
            //arrange
            string role = "Admin";
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserDataById(It.IsAny<FilterDefinition<UserDetails>>(), It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var detail = userAdapter.GetUserDetailsByRole(role);

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetAllUserDetailsMongoreturnsNull()
        {
            //arrange
            var response = new List<UserDetails>();
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserData(It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var detail = userAdapter.GetAllUserDetails();

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void GetAllUserDetailsMongoreturnsData()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserData(It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var detail = userAdapter.GetAllUserDetails();

            //assert
            Assert.IsInstanceOf<List<UserDetails>>(detail);
        }

        [Test]
        public void FillUserDataTest()
        {
            //arrange
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.InsertMany(It.IsAny<List<UserDetails>>(),It.IsAny<string>()));

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            userAdapter.FillUserData();

            //assert
            _mokuserDetails.Verify(m => m.InsertMany(It.IsAny<List<UserDetails>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void InsertUserDetailTest()
        {
            //arrange
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.InsertOne(It.IsAny<UserDetails>(), It.IsAny<string>()));

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            userAdapter.InsertUserDetail(It.IsAny<UserDetails>());

            //assert
            _mokuserDetails.Verify(m => m.InsertOne(It.IsAny<UserDetails>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LastInsertedIdTest()
        {
            //arrange
            var response = new List<UserDetails>
            {
                new UserDetails { id=1, emailid="emailid", role="admin", updatetimestamp="date", userid="11233" }
            };
            var settings = new MongoDbSettings { UsersCollection = _userDetailsCollection };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokuserDetails.Setup(a => a.GetUserData(It.IsAny<string>())).Returns(response);

            //act
            var userAdapter = new UserDetailDataAdapter(_mokuserDetails.Object, _settings.Object);
            var result = userAdapter.LastInsertedId();

            //assert
            Assert.AreEqual(1, result);
        }
    }
}
