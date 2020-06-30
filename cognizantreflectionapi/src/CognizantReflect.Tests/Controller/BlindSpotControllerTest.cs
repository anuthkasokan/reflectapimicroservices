using CognizantReflect.Api.BusinessLogics.Interfaces;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;


namespace CognizantReflect.Tests.Controller
{
    public class BlindSpotControllerTest
    {
        private readonly Mock<IBlindSpotBusinessLogics> _blindSpotBusinessLogics=new Mock<IBlindSpotBusinessLogics>();

        [Test]
        [Description("CognizantReflect Api BlindSpotController instance is getting created")]
        public void BlindSpotController()
        {
            //Act
            var actual = new BlindSpotController(_blindSpotBusinessLogics.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<BlindSpotController>(actual);

        }
        [Test]
        [Description("GetBlindSpotQuestions")]
        public void BlindSpotController_GetBlindSpotQuestions()
        {
            //Act
            var actual = new BlindSpotController(_blindSpotBusinessLogics.Object);

            //Assert
            var target = actual.GetBlindSpotQuestions();
            Assert.IsNull(target);

        } 
        [Test]
        [Description("GetBlindSpotResult")]
        public void BlindSpotController_GetBlindSpotResult()
        {
            //Act
            var actual = new BlindSpotController(_blindSpotBusinessLogics.Object);
            string makingTimeForMeQuiz = "Test";

            var target = actual.GetBlindSpotResult(makingTimeForMeQuiz);

            //Assert
            Assert.IsNull(target);
        }
        [Test]
        [Description("GetBlindSpotReplyRequest")]
        public void BlindSpotController_GetBlindSpotReplyRequest()
        {
            //Act
            var actual = new BlindSpotController(_blindSpotBusinessLogics.Object);
            string makingTimeForMeQuiz = "Test";

            var target = actual.GetBlindSpotReplyRequest(makingTimeForMeQuiz);

            //Assert
            Assert.IsNull(target);
           
        }

    }
}
