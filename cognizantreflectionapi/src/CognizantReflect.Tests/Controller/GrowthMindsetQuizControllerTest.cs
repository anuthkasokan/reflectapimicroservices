using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;

namespace CognizantReflect.Tests.Controller
{
    class GrowthMindsetQuizControllerTest
    {
        private readonly Mock<IGrowthMindsetQuizBusinessLogic> _growthMindsetQuizBusinessLogic = new Mock<IGrowthMindsetQuizBusinessLogic>();

        [Test]
        [Description("CognizantReflect Api GrowthMindsetQuizController instance is getting created")]
        public void GrowthMindsetQuizController()
        {
            //Act
            var actual = new GrowthMindsetQuizController(_growthMindsetQuizBusinessLogic.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<GrowthMindsetQuizController>(actual);

        }
        [Test]
        [Description("GetCuriousQuiz")]
        public void GrowthMindsetQuizControllerr_GetCuriousQuiz()
        {
            //Act
            var actual = new GrowthMindsetQuizController(_growthMindsetQuizBusinessLogic.Object);
            var target = actual.GetCuriousQuiz();

            //Assert
            Assert.IsNull(target);

        }
        [Test]
        [Description("saveGrowthMindsetQuiz")]
        public void GrowthMindsetQuizController_saveGrowthMindsetQuiz()
        {
            //Act
            var actual = new GrowthMindsetQuizController(_growthMindsetQuizBusinessLogic.Object);
            var growthMindsetQuiz = new GrowthMindsetQuiz();

            var target = actual.saveGrowthMindsetQuiz(growthMindsetQuiz);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }
        [Test]
        [Description("saveGrowthMindsetQuizAttempts")]
        public void GrowthMindsetQuizController_saveGrowthMindsetQuizAttempts()
        {
            //Act
            var actual = new GrowthMindsetQuizController(_growthMindsetQuizBusinessLogic.Object);
            var makingTimeForMeQuizAttempts = new List<GrowthMindsetQuizAttempts>();
            var target = actual.saveGrowthMindsetQuizAttempts(makingTimeForMeQuizAttempts);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }

    }
}
