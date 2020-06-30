using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class ReflectionToolBusinessLogicsTest
    {
        private readonly Mock<IReflectionToolAdapter> _reflectionToolAdapter = new Mock<IReflectionToolAdapter>();
        private ReflectionToolBusinessLogics _reflectionToolQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _reflectionToolQuizBusinessLogic = new ReflectionToolBusinessLogics(_reflectionToolAdapter.Object);
        }

        [Test]
        public void ReflectionToolBL_Instance()
        {
            Assert.IsInstanceOf<ReflectionToolBusinessLogics>(_reflectionToolQuizBusinessLogic);
        }

        [Test]
        public void GetReflectionToolQuizzes_ReturnsQuestionList()
        {
            _reflectionToolAdapter.Setup(x => x.GetReflectionToolQuestions()).Returns(
                new List<ReflectionTool>
                {
                    new ReflectionTool()
                    {
                        id=1
                    }
                }
            );
            var actual = _reflectionToolQuizBusinessLogic.GetReflectionToolQuestions();
            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void InsertReflectionToolQuizResponse_WithAttempt_ReturnsInt()
        {
            List<ReflectionToolQuizAttempt> reflectionToolQuizAttempts = new List<ReflectionToolQuizAttempt>
            {
                new ReflectionToolQuizAttempt()
            };
            _reflectionToolAdapter.Setup(x => x.GetLastInsertedReflectionQuizId()).Returns(
                1);
            Assert.DoesNotThrow(() => _reflectionToolQuizBusinessLogic.SaveReflectionToolResponse(reflectionToolQuizAttempts));
        }
    }
}