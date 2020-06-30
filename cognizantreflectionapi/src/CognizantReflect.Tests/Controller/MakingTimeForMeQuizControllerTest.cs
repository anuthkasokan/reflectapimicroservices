using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CognizantReflect.Tests.Controller
{
    public class MakingTimeForMeQuizControllerTest
    {
        private readonly Mock<IMakingTimeForMeQuizBusinessLogic> _makingTimeForMeQuizBusinessLogic = new Mock<IMakingTimeForMeQuizBusinessLogic>();

        [Test]
        [Description("CognizantReflect Api MakingTimeForMeQuizController instance is getting created")]
        public void MakingTimeForMeQuizController()
        {
            //Act
            var actual = new MakingTimeForMeQuizController(_makingTimeForMeQuizBusinessLogic.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<MakingTimeForMeQuizController>(actual);

        }
        [Test]
        [Description("GetMakingTimeForMeQuiz")]
        public void MakingTimeForMeQuizController_GetMakingTimeForMeQuiz()
        {
            //Act
            var actual = new MakingTimeForMeQuizController(_makingTimeForMeQuizBusinessLogic.Object);
            var target = actual.GetMakingTimeForMeQuiz();

            //Assert
            Assert.IsNull(target);

        }
        [Test]
        [Description("saveMakingTimeForMeQuiz")]
        public void MakingTimeForMeQuizController_saveMakingTimeForMeQuiz()
        {
            //Act
            var actual = new MakingTimeForMeQuizController(_makingTimeForMeQuizBusinessLogic.Object);
            var makingTimeForMeQuiz = new MakingTimeForMeQuiz();

            var target = actual.saveMakingTimeForMeQuiz(makingTimeForMeQuiz);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }
        [Test]
        [Description("saveMakingTimeForMeQuizAttempts")]
        public void MakingTimeForMeQuizController_saveMakingTimeForMeQuizAttempts()
        {
            //Act
            var actual = new MakingTimeForMeQuizController(_makingTimeForMeQuizBusinessLogic.Object);
            var makingTimeForMeQuizAttempts = new List<MakingTimeForMeQuizAttempts>
                {
                new MakingTimeForMeQuizAttempts()
                };
            var target = actual.saveMakingTimeForMeQuizAttempts(makingTimeForMeQuizAttempts);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }

    }
}
