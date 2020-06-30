using System;
using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class GrowthMindsetQuizBusinessLogicsTest
    {
        private readonly Mock<IGrowthMindsetAdapter> _growthMindsetAdapter = new Mock<IGrowthMindsetAdapter>();
        private GrowthMindsetQuizBusinessLogic _growthMindsetQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _growthMindsetQuizBusinessLogic = new GrowthMindsetQuizBusinessLogic(_growthMindsetAdapter.Object);
        }

        [Test]
        public void GrowthMindsetQuizBL_Instance()
        {
            Assert.IsInstanceOf<GrowthMindsetQuizBusinessLogic>(_growthMindsetQuizBusinessLogic);
        }

        [Test]
        public void GetGrowthMindsetQuizzes_ReturnsQuestionList()
        {
            _growthMindsetAdapter.Setup(x => x.GetGrowthMindsetQuiz()).Returns(
                new List<GrowthMindsetQuiz>
                {
                    new GrowthMindsetQuiz
                    {
                        id=1
                    }
                }
                );
            var actual = _growthMindsetQuizBusinessLogic.GetGrowthMindsetQuizzes();
            Assert.AreEqual(1,actual[0].id);
        }

        [Test]
        public void InsertGrowthMindsetQuiz_ReturnsInt()
        {
           Assert.DoesNotThrow(()=>_growthMindsetQuizBusinessLogic.InsertGrowthMindsetQuiz(It.IsAny<GrowthMindsetQuiz>()));
        }

        [Test]
        public void InsertGrowthMindsetQuizResponse_WithAttempt_ReturnsInt()
        {
            List<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts = new List<GrowthMindsetQuizAttempts>
            {
                new GrowthMindsetQuizAttempts()
            };
            _growthMindsetAdapter.Setup(x => x.GetLatestId()).Returns(
                new GrowthMindsetQuizAttempts()
                {
                    id=1,attemptcount = 1
                });
            Assert.DoesNotThrow(()=> _growthMindsetQuizBusinessLogic.InsertGrowthMindsetQuizResponse(growthMindsetQuizAttempts));
        }
    }
}