using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
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
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class DashboardAdapterTests
    {
        private Mock<IMongoClientHelper<CuriousQuizAttempts>> _curiousQuizAttempts;
        private Mock<IMongoClientHelper<BlindSpotQuizAttempts>> _blindSpotQuizAttempts;
        private Mock<IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts>> _continuousLearningQuizAttempts;
        private Mock<IMongoClientHelper<CultureObservationToolQuizAttempts>> _cultureObservationToolQuizAttempts;
        private Mock<IMongoClientHelper<GrowthMindsetQuizAttempts>> _growthMindsetQuizAttempts;
        private Mock<IMongoClientHelper<LearningMythsQuizAttempts>> _learningMythsQuizAttempts;
        private Mock<IMongoClientHelper<MakingTimeForMeQuizAttempts>> _makingTimeForMeQuizAttempts;
        private Mock<IMongoClientHelper<ProductivityZoneQuizAttempts>> _productivityZoneQuizAttempts;
        private Mock<IMongoClientHelper<ReflectionToolQuizAttempt>> _reflectionToolQuizAttempts;
        private Mock<IMongoClientHelper<StoryTellingForImpactQuizAttempts>> _storyTellingForImpactQuizAttempts;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private DashboardAdapter _dashboardAdapter;

        [SetUp]
        public void SetUp()
        {
            var settings = new MongoDbSettings { 
                CuriousQuizAttemptsCollection = "", BlindSpotQuizAttemptsCollection = "" ,
                ContinuousLearningAssessmentQuizAttemptsCollection = "",CultureObservationToolQuizAttemptsCollection = "",
                GrowthMindsetAttemptsQuizCollection = "",LearningMythsQuizAttemptsCollection = "",
                MakingTimeForMeQuizAttemptsCollection = "",ProductivityZoneQuizAttemptsCollection = "",
                ReflectionToolQuizAttemptsCollection = "",StoryTellingForImpactQuizAttemptsCollection = ""
            };
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _settings.Setup(s => s.Value).Returns(settings);
            _curiousQuizAttempts = new Mock<IMongoClientHelper<CuriousQuizAttempts>>();
            _blindSpotQuizAttempts = new Mock<IMongoClientHelper<BlindSpotQuizAttempts>>();
            _continuousLearningQuizAttempts = new Mock<IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts>>();
            _cultureObservationToolQuizAttempts = new Mock<IMongoClientHelper<CultureObservationToolQuizAttempts>>();
            _growthMindsetQuizAttempts = new Mock<IMongoClientHelper<GrowthMindsetQuizAttempts>>();
            _learningMythsQuizAttempts = new Mock<IMongoClientHelper<LearningMythsQuizAttempts>>();
            _makingTimeForMeQuizAttempts = new Mock<IMongoClientHelper<MakingTimeForMeQuizAttempts>>();
            _productivityZoneQuizAttempts = new Mock<IMongoClientHelper<ProductivityZoneQuizAttempts>>();
            _reflectionToolQuizAttempts = new Mock<IMongoClientHelper<ReflectionToolQuizAttempt>>();
            _storyTellingForImpactQuizAttempts = new Mock<IMongoClientHelper<StoryTellingForImpactQuizAttempts>>();
        }

        [Test]
        public void GetAttemptCountForCuriousQuizTest()
        {
            var response = new List<CuriousQuizAttempts>
            {
                new CuriousQuizAttempts { answer = true }
            };

            _curiousQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(),It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object,_blindSpotQuizAttempts.Object,_continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object,_growthMindsetQuizAttempts.Object,_learningMythsQuizAttempts.Object,_makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object,_reflectionToolQuizAttempts.Object,_storyTellingForImpactQuizAttempts.Object,_settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForCuriousQuiz("");
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void GetAttemptCountForGrowthMindsetQuizTest()
        {
            var response = new List<GrowthMindsetQuizAttempts>
            {
                new GrowthMindsetQuizAttempts { answer = true }
            };

            _growthMindsetQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForGrowthMindsetQuiz("");
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void GetAttemptCountForMakingTimeQuizTest()
        {
            var response = new List<MakingTimeForMeQuizAttempts>
            {
                new MakingTimeForMeQuizAttempts { answer = "" }
            };

            _makingTimeForMeQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForMakingTimeQuiz("");
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void GetAttemptCountForCultureObservationQuizTest()
        {
            var response = new List<CultureObservationToolQuizAttempts>
            {
                new CultureObservationToolQuizAttempts { attemptcount = 1 }
            };

            _cultureObservationToolQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForCultureObservationQuiz("");
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void GetTotalRecordsOfCuriosityQuizTest()
        {
            var response = new List<CuriousQuizAttempts>
            {
                new CuriousQuizAttempts { attemptcount = 1 }
            };

            _curiousQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfCuriosityQuiz();
            Assert.IsInstanceOf<List<CuriousQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfGrowthMindsetQuizTest()
        {
            var response = new List<GrowthMindsetQuizAttempts>
            {
                new GrowthMindsetQuizAttempts { attemptcount = 1 }
            };

            _growthMindsetQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfGrowthMindsetQuiz();
            Assert.IsInstanceOf<List<GrowthMindsetQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfMakingTimeForMeQuizTest()
        {
            var response = new List<MakingTimeForMeQuizAttempts>
            {
                new MakingTimeForMeQuizAttempts { attemptcount = 1 }
            };

            _makingTimeForMeQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfMakingTimeForMeQuiz();
            Assert.IsInstanceOf<List<MakingTimeForMeQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfCultureObservationQuizTest()
        {
            var response = new List<CultureObservationToolQuizAttempts>
            {
                new CultureObservationToolQuizAttempts { attemptcount = 1 }
            };

            _cultureObservationToolQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfCultureObservationQuiz();
            Assert.IsInstanceOf<List<CultureObservationToolQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfBlindSpotQuizTest()
        {
            var response = new List<BlindSpotQuizAttempts>
            {
                new BlindSpotQuizAttempts { attemptcount = 1 }
            };

            _blindSpotQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<BlindSpotQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfBlindSpotQuiz();
            Assert.IsInstanceOf<List<BlindSpotQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfContinuousLearningQuizTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfContinuousLearningQuiz();
            Assert.IsInstanceOf<List<ContinuousLearningAssessmentQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfLearningMythsQuizTest()
        {
            var response = new List<LearningMythsQuizAttempts>
            {
                new LearningMythsQuizAttempts { attemptcount = 1 }
            };

            _learningMythsQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<LearningMythsQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfLearningMythsQuiz();
            Assert.IsInstanceOf<List<LearningMythsQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfProductivityZoneQuizTest()
        {
            var response = new List<ProductivityZoneQuizAttempts>
            {
                new ProductivityZoneQuizAttempts { attemptcount = 1 }
            };

            _productivityZoneQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ProductivityZoneQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfProductivityZoneQuiz();
            Assert.IsInstanceOf<List<ProductivityZoneQuizAttempts>>(result);
        }

        [Test]
        public void GetTotalRecordsOfReflectionToolQuizTest()
        {
            var response = new List<ReflectionToolQuizAttempt>
            {
                new ReflectionToolQuizAttempt { attemptcount = 1 }
            };

            _reflectionToolQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfReflectionToolQuiz();
            Assert.IsInstanceOf<List<ReflectionToolQuizAttempt>>(result);
        }

        [Test]
        public void GetTotalRecordsOfStoryTellingQuizTest()
        {
            var response = new List<StoryTellingForImpactQuizAttempts>
            {
                new StoryTellingForImpactQuizAttempts { attemptcount = 1 }
            };

            _storyTellingForImpactQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetTotalRecordsOfStoryTellingQuiz();
            Assert.IsInstanceOf<List<StoryTellingForImpactQuizAttempts>>(result);
        }

        [Test]
        public void GetAttemptedQuizCountByUserTest()
        {
            var response = new List<StoryTellingForImpactQuizAttempts>
            {
                new StoryTellingForImpactQuizAttempts { attemptcount = 1 }
            };

            _curiousQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _growthMindsetQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _makingTimeForMeQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _cultureObservationToolQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _blindSpotQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<BlindSpotQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _continuousLearningQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _learningMythsQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<LearningMythsQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _productivityZoneQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<ProductivityZoneQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _storyTellingForImpactQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>())).Returns(1);
            _reflectionToolQuizAttempts.Setup(a => a.GetDocumentCount(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>())).Returns(1);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptedQuizCountByUser("");
            Assert.AreEqual(10, result);
        }

        [Test]
        public void GetCuriousQuizScoreOfUserTest()
        {
            var response = new List<CuriousQuizAttempts>
            {
                new CuriousQuizAttempts { attemptcount = 1 }
            };

            _curiousQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetCuriousQuizScoreOfUser("",1);
            _curiousQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetGrowthMindsetQuizScoreOfUserTest()
        {
            var response = new List<GrowthMindsetQuizAttempts>
            {
                new GrowthMindsetQuizAttempts { attemptcount = 1 }
            };

            _growthMindsetQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetGrowthMindsetQuizScoreOfUser("", 1);
            _growthMindsetQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetMakingTimeQuizScoreOfUserTest()
        {
            var response = new List<MakingTimeForMeQuizAttempts>
            {
                new MakingTimeForMeQuizAttempts { attemptcount = 1 }
            };

            _makingTimeForMeQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetMakingTimeQuizScoreOfUser("", 1);
            _makingTimeForMeQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetCultureObservationQuizScoreOfUserTest()
        {
            var response = new List<CultureObservationToolQuizAttempts>
            {
                new CultureObservationToolQuizAttempts { attemptcount = 1 }
            };

            _cultureObservationToolQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetCultureObservationQuizScoreOfUser("", 1);
            _cultureObservationToolQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForBlindSpotQuizTest()
        {
            var response = new List<BlindSpotQuizAttempts>
            {
                new BlindSpotQuizAttempts { attemptcount = 1 }
            };

            _blindSpotQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<BlindSpotQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForBlindSpotQuiz("");
            _blindSpotQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<BlindSpotQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForContinuousLearningQuizTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForContinuousLearningQuiz("");
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForLearningMythsQuizTest()
        {
            var response = new List<LearningMythsQuizAttempts>
            {
                new LearningMythsQuizAttempts { attemptcount = 1 }
            };

            _learningMythsQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<LearningMythsQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForLearningMythsQuiz("");
            _learningMythsQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<LearningMythsQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForProductivityZoneQuizTest()
        {
            var response = new List<ProductivityZoneQuizAttempts>
            {
                new ProductivityZoneQuizAttempts { attemptcount = 1 }
            };

            _productivityZoneQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ProductivityZoneQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForProductivityZoneQuiz("");
            _productivityZoneQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ProductivityZoneQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForReflectionToolQuizTest()
        {
            var response = new List<ReflectionToolQuizAttempt>
            {
                new ReflectionToolQuizAttempt { attemptcount = 1 }
            };

            _reflectionToolQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForReflectionToolQuiz("");
            _reflectionToolQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForStoryTellingForImpactQuizTest()
        {
            var response = new List<StoryTellingForImpactQuizAttempts>
            {
                new StoryTellingForImpactQuizAttempts { attemptcount = 1 }
            };

            _storyTellingForImpactQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetAttemptCountForStoryTellingForImpactQuiz("");
            _storyTellingForImpactQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetContinuousLearningYesCountTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetContinuousLearningYesCount("");
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAllContinuousLearningYesCountTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetContinuousLearningYesCount();
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetContinuousLearningNoCountTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetContinuousLearningYesCount("");
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAllContinuousLearningNoCountTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetContinuousLearningYesCount();
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetContinuousLearningSomewhatCountTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetContinuousLearningSomewhatCount("");
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAllContinuousLearningSomewhatCountTest()
        {
            var response = new List<ContinuousLearningAssessmentQuizAttempts>
            {
                new ContinuousLearningAssessmentQuizAttempts { attemptcount = 1 }
            };

            _continuousLearningQuizAttempts.Setup(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _dashboardAdapter = new DashboardAdapter(_curiousQuizAttempts.Object, _blindSpotQuizAttempts.Object, _continuousLearningQuizAttempts.Object,
                _cultureObservationToolQuizAttempts.Object, _growthMindsetQuizAttempts.Object, _learningMythsQuizAttempts.Object, _makingTimeForMeQuizAttempts.Object,
                _productivityZoneQuizAttempts.Object, _reflectionToolQuizAttempts.Object, _storyTellingForImpactQuizAttempts.Object, _settings.Object);

            var result = _dashboardAdapter.GetContinuousLearningSomewhatCount();
            _continuousLearningQuizAttempts.Verify(a => a.GetData(It.IsAny<FilterDefinition<ContinuousLearningAssessmentQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
