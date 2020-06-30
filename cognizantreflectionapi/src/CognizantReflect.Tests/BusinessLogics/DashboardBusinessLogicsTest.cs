using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using CognizantReflect.Api.Models.CuriosityQuiz;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using CognizantReflect.Api.Models.UserService;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class DashboardBusinessLogicsTest
    {
        private readonly Mock<IDashboardAdapter> _dashboardAdapter = new Mock<IDashboardAdapter>();
        private readonly Mock<IUserAdapter> _userAdapter = new Mock<IUserAdapter>();
        private DashboardBusinessLogics _dashboardBusinessLogics;

        [SetUp]
        public void SetUp()
        {
            _dashboardBusinessLogics = new DashboardBusinessLogics(_dashboardAdapter.Object, _userAdapter.Object);
        }


        [Test]
        public void DashboardBusinessLogics_Instance()
        {
            Assert.IsInstanceOf<DashboardBusinessLogics>(_dashboardBusinessLogics);
        }

        [Test]
        public void GetDetailsForScoreGraphChart_WithUserid_ReturnsScoreChartArray()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCuriousQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForGrowthMindsetQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForMakingTimeQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCultureObservationQuiz(It.IsAny<string>())).Returns(1);

            _dashboardAdapter.Setup(x => x.GetCuriousQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);
            _dashboardAdapter.Setup(x => x.GetGrowthMindsetQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);
            _dashboardAdapter.Setup(x => x.GetMakingTimeQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);
            _dashboardAdapter.Setup(x => x.GetCultureObservationQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);

            var actual = _dashboardBusinessLogics.GetDetailsForScoreGraphChart("");
            Assert.Greater(actual.Length,0);
        }

        [Test]
        public void GetDetailsForScoreGraphChart_ReturnsScoreChartArray()
        {
            _userAdapter.Setup(x => x.GetUserList()).Returns(
                new List<UserDetails>
                {
                    new UserDetails
                    {
                        UserId = "Hamid"
                    }
                }
                );
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCuriousQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForGrowthMindsetQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForMakingTimeQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCultureObservationQuiz(It.IsAny<string>())).Returns(1);

            _dashboardAdapter.Setup(x => x.GetCuriousQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);
            _dashboardAdapter.Setup(x => x.GetGrowthMindsetQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);
            _dashboardAdapter.Setup(x => x.GetMakingTimeQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);
            _dashboardAdapter.Setup(x => x.GetCultureObservationQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(5);

            var actual = _dashboardBusinessLogics.GetDetailsForScoreGraphChart();
            Assert.Greater(actual.Length, 0);
        }

        [Test]
        public void GetQuizAttemptCountsByUser_ReturnsAttemptCount()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCuriousQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForGrowthMindsetQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForMakingTimeQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCultureObservationQuiz("")).Returns(1);

            var actual = _dashboardBusinessLogics.GetQuizAttemptCountsByUser("");
            Assert.AreEqual(1,actual.CultureObservationAttemptCount);
        }

        [Test]
        public void GetTotalQuizAttemptCounts_ReturnsTotalAttemptCount()
        {
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfCuriosityQuiz()).Returns(
                new List<CuriousQuizAttempts>
                {
                    new CuriousQuizAttempts
                    {
                        userid = "Hamid",attemptcount = 1
                    }
                }
                );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfGrowthMindsetQuiz()).Returns(new List<GrowthMindsetQuizAttempts>
                {
                    new GrowthMindsetQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfMakingTimeForMeQuiz()).Returns(new List<MakingTimeForMeQuizAttempts>
                {
                    new MakingTimeForMeQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfCultureObservationQuiz()).Returns(
                new List<CultureObservationToolQuizAttempts>
                {
                    new CultureObservationToolQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );

            var actual = _dashboardBusinessLogics.GetTotalQuizAttemptCounts();
            Assert.AreEqual(1, actual.CultureObservationAttemptCount);
        }

        [Test]
        public void GetPercentageOfCompletionByUser_ReturnsPercentage()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptedQuizCountByUser("")).Returns(1);

            var actual = _dashboardBusinessLogics.GetPercentageOfCompletionByUser("");
            Assert.AreEqual(10,actual);
        }

        [Test]
        public void GetOverallPercentageOfQuizCompletion_ReturnsPercentage()
        {
            _userAdapter.Setup(x => x.GetUserList()).Returns(
            new List<UserDetails>
            {
                new UserDetails
                {
                    UserId = "Hamid"
                }
            }
                );
            _dashboardAdapter.Setup(x => x.GetAttemptedQuizCountByUser(It.IsAny<string>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetOverallPercentageOfQuizCompletion();
            Assert.AreEqual(10, actual);
        }
        [Test]
        public void GetQuizAttemptHistoryDetailsByUser_ReturnsAttemptHistoryArray()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptCountForBlindSpotQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForProductivityZoneQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForContinuousLearningQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForLearningMythsQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForReflectionToolQuiz("")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetAttemptCountForStoryTellingForImpactQuiz("")).Returns(1);

            var actual = _dashboardBusinessLogics.GetQuizAttemptHistoryDetailsByUser("");
            Assert.AreEqual(1,actual[0]);
        }

        [Test]
        public void GetQuizAttemptHistoryDetails_ReturnsAttemptHistoryArray()
        {
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfBlindSpotQuiz()).Returns(
                new List<BlindSpotQuizAttempts>
                {
                    new BlindSpotQuizAttempts()
                    {
                        userid = "Hamid",attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfContinuousLearningQuiz()).Returns(new List<ContinuousLearningAssessmentQuizAttempts>
                {
                    new ContinuousLearningAssessmentQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfLearningMythsQuiz()).Returns(new List<LearningMythsQuizAttempts>
                {
                    new LearningMythsQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfProductivityZoneQuiz()).Returns(
                new List<ProductivityZoneQuizAttempts>
                {
                    new ProductivityZoneQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfReflectionToolQuiz()).Returns(
                new List<ReflectionToolQuizAttempt>
                {
                    new ReflectionToolQuizAttempt()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );
            _dashboardAdapter.Setup(x => x.GetTotalRecordsOfStoryTellingQuiz()).Returns(
                new List<StoryTellingForImpactQuizAttempts>
                {
                    new StoryTellingForImpactQuizAttempts()
                    {
                        userid = "Hamid", attemptcount = 1
                    }
                }
            );

            var actual = _dashboardBusinessLogics.GetQuizAttemptHistoryDetails();
            Assert.AreEqual(1, actual[0]);
        }

        [Test]
        public void GetContinuousLearningDetails_WithUserid_ReturnsDetailsArray()
        {
            _dashboardAdapter.Setup(x => x.GetContinuousLearningYesCount("Hamid")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetContinuousLearningNoCount("Hamid")).Returns(1);
            _dashboardAdapter.Setup(x => x.GetContinuousLearningSomewhatCount("Hamid")).Returns(1);

            var actual=_dashboardBusinessLogics.GetContinuousLearningDetails("Hamid");
            Assert.AreEqual(1,actual[0]);
        }

        [Test]
        public void GetContinuousLearningDetails_ReturnsDetailsArray()
        {
            _dashboardAdapter.Setup(x => x.GetContinuousLearningYesCount()).Returns(1);
            _dashboardAdapter.Setup(x => x.GetContinuousLearningNoCount()).Returns(1);
            _dashboardAdapter.Setup(x => x.GetContinuousLearningSomewhatCount()).Returns(1);

            var actual = _dashboardBusinessLogics.GetContinuousLearningDetails("");
            Assert.AreEqual(1, actual[0]);
        }

        [Test]
        public void GetCuriosityResultAndTimes_WithUserid_ReturnsQuizResultAndTimes()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCuriousQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetCuriousQuizScoreOfUser(It.IsAny<string>(),It.IsAny<int>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetCuriosityResultAndTimes("");
            Assert.AreEqual(0,actual[0].times);

        }

        [Test]
        public void GetGrowthMindsetResultAndTimes_WithUserid_ReturnsQuizResultAndTimes()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptCountForGrowthMindsetQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetGrowthMindsetQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetGrowthMindsetResultAndTimes("");
            Assert.AreEqual(0, actual[0].times);
        }

        [Test]
        public void GetMakingTimeResultAndTimes_WithUserId_ReturnsResultAndTimes()
        {
            _dashboardAdapter.Setup(x => x.GetAttemptCountForMakingTimeQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetMakingTimeQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetMakingTimeResultAndTimes("");
            Assert.AreEqual(0, actual[0].times);
        }

        [Test]
        public void GetCuriosityResultAndTimes_ReturnsResultAndTimes()
        {
            _userAdapter.Setup(x => x.GetUserList()).Returns(new List<UserDetails>
            {
                new UserDetails
                {
                    UserId = "Hamid"
                }
            });
            _dashboardAdapter.Setup(x => x.GetAttemptCountForCuriousQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetCuriousQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetCuriosityResultAndTimes();
            Assert.AreEqual(0, actual[0].times);
        }

        [Test]
        public void GetGrowthMindsetResultAndTimes_ReturnsResultsAndTimes()
        {
            _userAdapter.Setup(x => x.GetUserList()).Returns(new List<UserDetails>
            {
                new UserDetails
                {
                    UserId = "Hamid"
                }
            });
            _dashboardAdapter.Setup(x => x.GetAttemptCountForGrowthMindsetQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetGrowthMindsetQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetGrowthMindsetResultAndTimes();
            Assert.AreEqual(0, actual[0].times);
        }

        [Test]
        public void GetMakingTimeResultAndTimes_ReturnsResultAndTimes()
        {
            _userAdapter.Setup(x => x.GetUserList()).Returns(new List<UserDetails>
            {
                new UserDetails
                {
                    UserId = "Hamid"
                }
            });
            _dashboardAdapter.Setup(x => x.GetAttemptCountForMakingTimeQuiz(It.IsAny<string>())).Returns(1);
            _dashboardAdapter.Setup(x => x.GetMakingTimeQuizScoreOfUser(It.IsAny<string>(), It.IsAny<int>())).Returns(1);

            var actual = _dashboardBusinessLogics.GetMakingTimeResultAndTimes();
            Assert.AreEqual(0, actual[0].times);
        }

    }
}