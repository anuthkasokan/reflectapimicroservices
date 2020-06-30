using Moq;
using NUnit.Framework;
using ReflectUser.API.BusinessAccess.Interfaces;
using ReflectUser.API.Controllers;

namespace ReflectUser.Tests.Controllers
{
    [TestFixture]
    public class PingControllerTests
    {
        private Mock<IUserDetailBusinessLogic> _mokuserDetailLogic;

        [SetUp]
        public void SetUp()
        {
            _mokuserDetailLogic = new Mock<IUserDetailBusinessLogic>();
        }

        [Test]
        public void GetAllUsersTest()
        {

            //act
            var pingController = new PingController( _mokuserDetailLogic.Object);
            var detail = pingController.Get();

            //assert
            Assert.AreEqual("Pinged successfully!", detail);
        }

        [Test]
        public void PingPost()
        {
            //arrange
            _mokuserDetailLogic.Setup(a => a.FillUserData());

            //act
            var pingController = new PingController( _mokuserDetailLogic.Object);
            pingController.Post();

            //assert
            _mokuserDetailLogic.Verify(m => m.FillUserData(), Times.Once);
        }
    }
}
