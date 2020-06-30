using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CognizantReflect.Tests.Controller
{
    public class StoryTellingForImpactControllerTest
    {
        private readonly Mock<IStoryTellingForImpactBusinessLogic> _storyTellingForImpactBusinessLogic = new Mock<IStoryTellingForImpactBusinessLogic>();

        [Test]
        [Description("CognizantReflect Api StoryTellingForImpactController instance is getting created")]
        public void StoryTellingForImpactController()
        {
            //Act
            var actual = new StoryTellingForImpactController(_storyTellingForImpactBusinessLogic.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<StoryTellingForImpactController>(actual);

        }
        [Test]
        [Description("saveStoryTellingQuizAttempts")]
        public void StoryTellingForImpactController_saveStoryTellingQuizAttempts()
        {
            //Act
            var actual = new StoryTellingForImpactController(_storyTellingForImpactBusinessLogic.Object);
            var storyTellingForImpactQuiz = new List<StoryTellingForImpactQuizAttempts>();
            var target = actual.saveStoryTellingQuizAttempts(storyTellingForImpactQuiz);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);
        }
        [Test]
        [Description("saveStoryTellingQuiz")]
        public void StoryTellingForImpactController_saveStoryTellingQuiz()
        {
            //Act
            var actual = new StoryTellingForImpactController(_storyTellingForImpactBusinessLogic.Object);
            var storyTellingForImpactQuiz = new StoryTellingForImpactQuiz();

            var target = actual.saveStoryTellingQuiz(storyTellingForImpactQuiz);

            //Assert
            Assert.IsNotNull(target);
            Assert.AreEqual(200, ((ObjectResult)target).StatusCode);

        }
    }
}
