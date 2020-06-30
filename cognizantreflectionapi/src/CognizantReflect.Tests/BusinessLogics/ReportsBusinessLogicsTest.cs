using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.Reports;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class ReportsBusinessLogicsTest
    {
        private readonly Mock<IReportsAdapter> _reportsAdapter = new Mock<IReportsAdapter>();
        private ReportsBusinessLogic _reportsBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _reportsBusinessLogic = new ReportsBusinessLogic(_reportsAdapter.Object);
        }

        [Test]
        public void ReportBusinessLogics_Instance()
        {
            Assert.IsInstanceOf<ReportsBusinessLogic>(_reportsBusinessLogic);
        }

        [Test]
        public void GetQuizAttempts_WithCuriosityQuizDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "curiosity"
                }
                );

            _reportsAdapter.Setup(x => x.GetCuriousQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1,actual[0].id);
        }


        [Test]
        public void GetQuizAttempts_WithBlindSpotDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "blindspot"
                }
            );

            _reportsAdapter.Setup(x => x.GetBlindSpotQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithGrowthMindsetDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "growthmindset"
                }
            );

            _reportsAdapter.Setup(x => x.GetGrowthMindsetQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithMakingTImeForMeDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "makingtimeforme"
                }
            );

            _reportsAdapter.Setup(x => x.GetMakingTimeForMeQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithStoryTellingDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "storytellingforimpact"
                }
            );

            _reportsAdapter.Setup(x => x.GetStoryTellingForImpactQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithContinuousLearningDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "continuouslearningassessment"
                }
            );

            _reportsAdapter.Setup(x => x.GetContinuousLearningQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithCultureObservationDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "culturalobservation"
                }
            );

            _reportsAdapter.Setup(x => x.GetCulturalObservationQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithLearningMythsDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "learningmyths"
                }
            );

            _reportsAdapter.Setup(x => x.GetLearningMythQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizAttempts_WithProductivityZoneDetails_ReturnQuizReport()
        {

            _reportsAdapter.Setup(x => x.GetQuizDetails(It.IsAny<int>())).Returns(
                new QuizDetails
                {
                    quizname = "productivityzone"
                }
            );

            _reportsAdapter.Setup(x => x.GetProductivityZoneQuizAttempts(It.IsAny<string>(),
                It.IsAny<int>(), It.IsAny<QuizDetails>())).Returns(
                new List<QuizAttempts>
                {
                    new QuizAttempts
                    {
                        id=1
                    }
                }
            );

            var actual = _reportsBusinessLogic.GetQuizAttempts("", 1, 1);

            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void GetQuizzes_ReturnsQuizList()
        {
            _reportsAdapter.Setup(x => x.GetAllQuizzes()).Returns(
                new List<QuizDetails>
                {
                    new QuizDetails
                    {
                        quizname = "curiosity"
                    }
                }
                );

            var actual = _reportsBusinessLogic.GetQuizzes();
            Assert.AreEqual("curiosity",actual[0].quizname);
        }

    }
}