using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class StoryTellingBusinessLogicsTest
    {
        private readonly Mock<IStoryTellingForImpactAdapter> _storyTellingForImpactAdapter = new Mock<IStoryTellingForImpactAdapter>();
        private StoryTellingForImpactBusinessLogic _storyTellingQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _storyTellingQuizBusinessLogic = new StoryTellingForImpactBusinessLogic(_storyTellingForImpactAdapter.Object);
        }

        [Test]
        public void StoryTellingBL_Instance()
        {
            Assert.IsInstanceOf<StoryTellingForImpactBusinessLogic>(_storyTellingQuizBusinessLogic);
        }

        [Test]
        public void GetStoryTellingQuizzes_ReturnsQuestionList()
        {
            _storyTellingForImpactAdapter.Setup(x => x.GetStoryTellingForImpactQuizzes()).Returns(
                new List<StoryTellingForImpactQuiz>
                {
                    new StoryTellingForImpactQuiz()
                    {
                        id=1
                    }
                }
            );
            var actual = _storyTellingQuizBusinessLogic.GetStoryTellingForImpactQuizzes();
            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void InsertStoryTellingQuizResponse_WithAttempt_ReturnsInt()
        {
            List<StoryTellingForImpactQuizAttempts> storyTellingQuizQuizAttempts = new List<StoryTellingForImpactQuizAttempts>
            {
                new StoryTellingForImpactQuizAttempts()
            };
            _storyTellingForImpactAdapter.Setup(x => x.GetLatestId()).Returns(
                new StoryTellingForImpactQuizAttempts()
                {
                    id = 1,
                    attemptcount = 1
                });
            Assert.DoesNotThrow(() => _storyTellingQuizBusinessLogic.InsertStoryTellingForImpactQuizzAttempts(storyTellingQuizQuizAttempts));
        }

        [Test]
        public void InsertStoryTellingForImpactQuizzes_ReturnsInt()
        {
            _storyTellingForImpactAdapter
                .Setup(x => x.InsertStoryTellingForImpactQuizzes(It.IsAny<StoryTellingForImpactQuiz>()))
                .Returns(1);

            var actual =
                _storyTellingQuizBusinessLogic.InsertStoryTellingForImpactQuizzes(new StoryTellingForImpactQuiz());

            Assert.AreEqual(1,actual);
        }
    }
}