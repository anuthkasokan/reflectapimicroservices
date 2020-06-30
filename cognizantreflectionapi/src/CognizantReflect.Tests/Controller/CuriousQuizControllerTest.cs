using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.CuriosityQuiz;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;


namespace CognizantReflect.Tests.Controller
{
    class CuriousQuizControllerTest
    {
        private readonly Mock<ICuriousQuizBusinessLogic> _curiousityQuizBusinessLogic = new Mock<ICuriousQuizBusinessLogic>();

        [Test]
        [Description("CognizantReflect Api CuriousQuizController instance is getting created")]
        public void CuriousQuizController()
        {
            //Act
            var actual = new CuriousQuizController(_curiousityQuizBusinessLogic.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<CuriousQuizController>(actual);

        }
        [Test]
        [Description("saveCuriosQuiz")]
        public void CuriousQuizController_saveCuriosQuiz()
        {
            //Act
            var actual = new CuriousQuizController(_curiousityQuizBusinessLogic.Object);
            var curiousQuiz = new CuriousQuiz();

            var target = actual.saveCuriosQuiz(curiousQuiz);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }
        [Test]
        [Description("saveCuriosQuizAttempts")]
        public void CuriousQuizController_saveCuriosQuizAttempts()
        {
            //Act
            var actual = new CuriousQuizController(_curiousityQuizBusinessLogic.Object);
            var curiousQuizAttempts = new List<CuriousQuizAttempts>();
            var target = actual.saveCuriosQuizAttempts(curiousQuizAttempts);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }
    }
}
