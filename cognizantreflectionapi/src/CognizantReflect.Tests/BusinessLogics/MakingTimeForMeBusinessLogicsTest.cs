using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class MakingTimeForMeBusinessLogicsTest
    {
        private readonly Mock<IMakingTimeForMeQuizAdapter> _makingTimeForMeQuizAdapter = new Mock<IMakingTimeForMeQuizAdapter>();

        private MakingTimeForMeQuizBusinessLogic _makingTimeForMeQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _makingTimeForMeQuizBusinessLogic = new MakingTimeForMeQuizBusinessLogic(_makingTimeForMeQuizAdapter.Object);
        }

        [Test]
        public void LearningMythsBL_Instance()
        {
            Assert.IsInstanceOf<MakingTimeForMeQuizBusinessLogic>(_makingTimeForMeQuizBusinessLogic);
        }

        [Test]
        public void GetLearningMythsQuizzes_ReturnsQuestionList()
        {
            _makingTimeForMeQuizAdapter.Setup(x => x.GetMakingTimeForMeQuizzes()).Returns(
                new List<MakingTimeForMeQuiz>
                {
                    new MakingTimeForMeQuiz()
                    {
                        id=1
                    }
                }
            );
            var actual = _makingTimeForMeQuizBusinessLogic.GetMakingTimeForMeQuizzes();
            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void InsertGrowthMindsetQuizResponse_WithAttempt_ReturnsInt()
        {
            List<MakingTimeForMeQuizAttempts> makingTimeQuizQuizAttempts = new List<MakingTimeForMeQuizAttempts>
            {
                new MakingTimeForMeQuizAttempts()
            };
            _makingTimeForMeQuizAdapter.Setup(x => x.GetLatestId()).Returns(
                new MakingTimeForMeQuizAttempts()
                {
                    id = 1,
                    attemptcount = 1
                });
            Assert.DoesNotThrow(() => _makingTimeForMeQuizBusinessLogic.InsertMakingTimeForMeQuizAttempts(makingTimeQuizQuizAttempts));
        }
    }
}