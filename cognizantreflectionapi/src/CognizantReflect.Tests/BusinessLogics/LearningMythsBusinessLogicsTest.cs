using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class LearningMythsBusinessLogicsTest
    {
        private readonly Mock<ILearningMythsAdapter> _learningMythsAdapter = new Mock<ILearningMythsAdapter>();
        private LearningMythsBusinessLogic _learningMythsQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _learningMythsQuizBusinessLogic = new LearningMythsBusinessLogic(_learningMythsAdapter.Object);
        }

        [Test]
        public void LearningMythsBL_Instance()
        {
            Assert.IsInstanceOf<LearningMythsBusinessLogic>(_learningMythsQuizBusinessLogic);
        }

        [Test]
        public void GetLearningMythsQuizzes_ReturnsQuestionList()
        {
            _learningMythsAdapter.Setup(x => x.GetLearningMythsQuizzes()).Returns(
                new List<LearningMythsQuiz>
                {
                    new LearningMythsQuiz()
                    {
                        id=1
                    }
                }
            );
            var actual = _learningMythsQuizBusinessLogic.GetLearningMythsQuizzes();
            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void InsertGrowthMindsetQuizResponse_WithAttempt_ReturnsInt()
        {
            List<LearningMythsQuizAttempts> learningMythsQuizQuizAttempts = new List<LearningMythsQuizAttempts>
            {
                new LearningMythsQuizAttempts()
            };
            _learningMythsAdapter.Setup(x => x.GetLatestId()).Returns(
                new LearningMythsQuizAttempts()
                {
                    id = 1,
                    attemptcount = 1
                });
            Assert.DoesNotThrow(() => _learningMythsQuizBusinessLogic.InsertLearningMythsQuizResponse(learningMythsQuizQuizAttempts));
        }
    }
}