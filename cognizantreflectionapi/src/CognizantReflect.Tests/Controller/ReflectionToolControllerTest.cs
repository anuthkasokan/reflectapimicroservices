using CognizantReflect.Api.BusinessLogics.Interfaces;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using System.Collections.Generic;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
namespace CognizantReflect.Tests.Controller
{
    public class ReflectionToolControllerTest
    {
        private readonly Mock<IReflectionToolBusinessLogics> _reflectionToolBusinessLogics = new Mock<IReflectionToolBusinessLogics>();

        [Test]
        [Description("CognizantReflect Api ReflectionToolController instance is getting created")]
        public void ReflectionToolController()
        {
            //Act
            var actual = new ReflectionToolController(_reflectionToolBusinessLogics.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<ReflectionToolController>(actual);

        }
        [Test]
        [Description("GetReflectionToolQuestions")]
        public void ReflectionToolController_GetReflectionToolQuestions()
        {
            //Act
            var actual = new ReflectionToolController(_reflectionToolBusinessLogics.Object);
            var target = actual.GetReflectionToolQuestions();

            //Assert
            Assert.IsNull(target);

        }
        [Test]
        [Description("SaveReflectionToolQuizAttempt")]
        public void ReflectionToolController_SaveReflectionToolQuizAttempt()
        {
            //Act
            var actual = new ReflectionToolController(_reflectionToolBusinessLogics.Object);
            var makingTimeForMeQuiz = new MakingTimeForMeQuiz();
            List<ReflectionToolQuizAttempt> reflectionToolQuizAttempt = new List<ReflectionToolQuizAttempt>();
            {
                
            }
            actual.SaveReflectionToolQuizAttempt(reflectionToolQuizAttempt);

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}
