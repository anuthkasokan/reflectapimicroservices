using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.CuriosityQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class CuriousQuizBusinessLogicsTest
    {
        private readonly Mock<ICuriousQuizAdapter> _curiousityQuizAdapter = new Mock<ICuriousQuizAdapter>();
        private CuriousQuizBusinessLogic _curiousQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _curiousQuizBusinessLogic = new CuriousQuizBusinessLogic(_curiousityQuizAdapter.Object);
        }

        [Test]
        public void CuriousQuizBusinessLogic_Instance()
        {
            Assert.IsInstanceOf<CuriousQuizBusinessLogic>(_curiousQuizBusinessLogic);
        }

        [Test]
        public void GetCuriousQuizzes_ReturnsQuestionList()
        {
            _curiousityQuizAdapter.Setup(x => x.GetCuriosQuizzes()).Returns(
            new List<CuriousQuiz>
            {
                new CuriousQuiz
                {
                    id=1
                }
            }
                );
            var actual = _curiousQuizBusinessLogic.GetCuriousQuizzes();
            Assert.AreEqual(1,actual[0].id);
        }

        [Test]
        public void InsertCuriousQuiz_ReturnsInt()
        {
            Assert.DoesNotThrow(() =>_curiousQuizBusinessLogic.InsertCuriousQuiz(It.IsAny<CuriousQuiz>()));
        }

        [Test]
        public void InsertCuriousQuizResponse_WithAttempt_ReturnsInt()
        {
            List<CuriousQuizAttempts> attempts = new List<CuriousQuizAttempts>
            {
                new CuriousQuizAttempts()
            };
            _curiousityQuizAdapter.Setup(x => x.GetLatestId()).Returns(
                new CuriousQuizAttempts
                {
                    id = 1,
                    attemptcount = 1
                });
            Assert.DoesNotThrow(()=>_curiousQuizBusinessLogic.InsertCuriousQuizResponse(attempts));
        }
    }
}