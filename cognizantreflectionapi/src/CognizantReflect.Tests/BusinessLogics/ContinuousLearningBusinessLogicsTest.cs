using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class ContinuousLearningBusinessLogicsTest
    {
        private readonly Mock<IContinuousLearningAdapter> _continuousLearningAdapter = new Mock<IContinuousLearningAdapter>();
        private ContinuousLearningBusinessLogic _continuousLearningBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _continuousLearningBusinessLogic = new ContinuousLearningBusinessLogic(_continuousLearningAdapter.Object);
        }

        [Test]
        public void ContinuousLearningBL_Instance()
        {
            Assert.IsInstanceOf<ContinuousLearningBusinessLogic>(_continuousLearningBusinessLogic);
        }

        [Test]
        public void GetContinuousLearningAssessmentQuizzes_ReturnsQuestionList()
        {
            _continuousLearningAdapter.Setup(x => x.GetContinuousLearningAssessmentQuizzes()).Returns(
            new List<ContinuousLearningAssessmentQuiz>
            {
                new ContinuousLearningAssessmentQuiz
                {
                    id=1
                }
            }
                );
            var assert = _continuousLearningBusinessLogic.GetContinuousLearningAssessmentQuizzes();
            Assert.AreEqual(1,assert[0].id);
        }

        [Test]
        public void InsertContinuousLearningQuizResponse_withResponse_ReturnsInt()
        {
            var attempt = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts()
            };
            _continuousLearningAdapter.Setup(x => x.GetLatestId()).Returns(
                new ContinuousLearningAssessmentQuizAttempts
                {
                    attemptcount = 1,id = 1
                });
            Assert.DoesNotThrow(() => _continuousLearningBusinessLogic.InsertContinuousLearningQuizResponse(attempt));
        }
    }
}