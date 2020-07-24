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
using CognizantReflect.Api.Models.Reports;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class ReportsAdapterTests
    {
        private Mock<IMongoClientHelper<QuizAttempts>> _mokquizAttempt;
        private Mock<ICuriousQuizAdapter> _mokcuriousQuizAdapter;
        private Mock<IGrowthMindsetAdapter> _mokgrowthMindsetQuizAdapter;
        private Mock<IMakingTimeForMeQuizAdapter> _mokmakingTimeForMeQuizAdapter;
        private Mock<IStoryTellingForImpactAdapter> _mokstoryTellingForImpactAdapter;
        private Mock<IContinuousLearningAdapter> _mokcontinuousLearningAdapter;
        private Mock<IBlindSpotAdapter> _mokblindSpotAdapter;
        private Mock<ILearningMythsAdapter> _moklearningMythAdapter;
        private Mock<ICulturalObservationAdapter> _mokculturalObservationAdapter;
        private Mock<IProductivityZoneQuizAdapter> _mokproductivityZoneQuizAdapter;
        private Mock<IReflectionToolAdapter> _mokreflectionToolAdapter;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private ReportsAdapter _reportsAdpater;

        [SetUp]
        public void SetUp()
        {
            _mokquizAttempt = new Mock<IMongoClientHelper<QuizAttempts>>();
            _mokcuriousQuizAdapter = new Mock<ICuriousQuizAdapter>();
            _mokgrowthMindsetQuizAdapter = new Mock<IGrowthMindsetAdapter>();
            _mokmakingTimeForMeQuizAdapter = new Mock<IMakingTimeForMeQuizAdapter>();
            _mokstoryTellingForImpactAdapter = new Mock<IStoryTellingForImpactAdapter>();
            _mokcontinuousLearningAdapter = new Mock<IContinuousLearningAdapter>();
            _mokblindSpotAdapter = new Mock<IBlindSpotAdapter>();
            _moklearningMythAdapter = new Mock<ILearningMythsAdapter>();
            _mokculturalObservationAdapter = new Mock<ICulturalObservationAdapter>();
            _mokproductivityZoneQuizAdapter = new Mock<IProductivityZoneQuizAdapter>();
            _mokreflectionToolAdapter = new Mock<IReflectionToolAdapter>();
            _settings = new Mock<IOptions<MongoDbSettings>>();

            var settings = new MongoDbSettings
            {
                StoryTellingForImpactQuizCollection = "",
                StoryTellingForImpactQuizAttemptsCollection = "",
                BlindSpotQuizAttemptsCollection = "",
                BlindSpotQuizCollection = "",
                BlindSpotQuizCoWorkerReplyCollection = "",
                ContinuousLearningAssessmentQuizAttemptsCollection = "",
                ContinuousLearningAssessmentQuizCollection = "",
                CultureObservationToolQuizAttemptsCollection = "",
                CultureObservationToolQuizCollection = "",
                CultureObservationToolScoringCollection = "",
                CuriousQuizAttemptsCollection = "",
                CuriousQuizCollection = "",
                GrowthMindsetAttemptsQuizCollection = "",
                GrowthMindsetQuizCollection = "",
                LearningMythsQuizAttemptsCollection = "",
                LearningMythsQuizCollection = "",
                MakingTimeForMeQuizAttemptsCollection = "",
                MakingTimeForMeQuizCollection = "",
                ProductivityZoneQuizAttemptsCollection = "",
                ProductivityZoneQuizCollection = "",
                ReflectionToolQuizAttemptsCollection = "",
                ReflectionToolQuizCollection = ""
            };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetQuizDetailsTest()
        {
            var response = new BsonDocument();
            _mokquizAttempt.Setup(a => a.GetSingleRecord(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(response);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetQuizDetails(1);
            Assert.IsInstanceOf<QuizDetails>(result);
        }

        [Test]
        public void GetAllQuizzesTest()
        {
            var response = new List<BsonDocument>();
            _mokquizAttempt.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetAllQuizzes();
            Assert.IsInstanceOf<List<QuizDetails>>(result);
        }

        [Test]
        public void GetCuriousQuizAttemptsTest()
        {
            var response = new CuriousQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<CuriousQuizAttempts>();
            var request = new QuizDetails();
            var quizResponse = new List<CuriousQuiz>();
            _mokcuriousQuizAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokcuriousQuizAdapter.Setup(a => a.GetCuriousAttempts(It.IsAny<string>(), It.IsAny<int>())).Returns(quizAttemptResponse);

            _mokcuriousQuizAdapter.Setup(a => a.GetCuriosQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetCuriousQuizAttempts("", 1, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetCuriousQuizAttemptsAttemptNotOneTest()
        {
            var response = new CuriousQuizAttempts
            {
                attemptcount = 2
            };
            var quizAttemptResponse = new List<CuriousQuizAttempts>
            {
                new CuriousQuizAttempts {questionid=1}
            };
            var request = new QuizDetails();
            var quizResponse = new List<CuriousQuiz>
            {
                new CuriousQuiz { id = 1}
            };
            _mokcuriousQuizAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokcuriousQuizAdapter.Setup(a => a.GetCuriousAttempts(It.IsAny<string>(), It.IsAny<int>())).Returns(quizAttemptResponse);

            _mokcuriousQuizAdapter.Setup(a => a.GetCuriosQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetCuriousQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetBlindSpotQuizAttemptsTest()
        {
            var response = new BlindSpotQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new BlindSpotQuizAttempts();
            var request = new QuizDetails();
            var quizResponse = new List<BlindSpotCoWorkerReply>();
            _mokblindSpotAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokblindSpotAdapter.Setup(a => a.GetBlindSpotAttemptResponse(It.IsAny<int>(), It.IsAny<string>())).Returns(quizAttemptResponse);

            _mokblindSpotAdapter.Setup(a => a.GetCoWorkerResponsesByAttempt(It.IsAny<long>())).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetBlindSpotQuizAttempts("", 1, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetGrowthMindsetQuizAttemptsTest()
        {
            var response = new GrowthMindsetQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>();
            var request = new QuizDetails();
            var quizResponse = new List<GrowthMindsetQuiz>();
            _mokgrowthMindsetQuizAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokgrowthMindsetQuizAdapter.Setup(a => a.GetGrowthMindsetQuiz()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetGrowthMindsetQuizAttempts("", 1, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetGrowthMindsetQuizAttemptsNotOneTest()
        {
            var response = new GrowthMindsetQuizAttempts
            {
                attemptcount = 2
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<GrowthMindsetQuiz>();
            _mokgrowthMindsetQuizAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokgrowthMindsetQuizAdapter.Setup(a => a.GetGrowthMindsetQuiz()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetGrowthMindsetQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }
                
        [Test]
        public void GetContinuousLearningQuizAttemptsNotOneTest()
        {
            var response = new ContinuousLearningAssessmentQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<ContinuousLearningAssessmentQuiz>
            { new ContinuousLearningAssessmentQuiz { id= 1 } };
            _mokcontinuousLearningAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokcontinuousLearningAdapter.Setup(a => a.GetContinuousLearningAssessmentQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetContinuousLearningQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetMakingTimeForMeQuizAttemptsTest()
        {
            var response = new MakingTimeForMeQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<MakingTimeForMeQuiz>
            { new MakingTimeForMeQuiz { id= 1 } };
            _mokmakingTimeForMeQuizAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokmakingTimeForMeQuizAdapter.Setup(a => a.GetMakingTimeForMeQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetMakingTimeForMeQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetStoryTellingForImpactQuizAttemptsTest()
        {
            var response = new StoryTellingForImpactQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<StoryTellingForImpactQuiz>
            { new StoryTellingForImpactQuiz { id= 1 } };
            _mokstoryTellingForImpactAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokstoryTellingForImpactAdapter.Setup(a => a.GetStoryTellingForImpactQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetStoryTellingForImpactQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetLearningMythQuizAttemptsTest()
        {
            var response = new LearningMythsQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<LearningMythsQuiz>
            { new LearningMythsQuiz { id= 1 } };
            _moklearningMythAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _moklearningMythAdapter.Setup(a => a.GetLearningMythsQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetLearningMythQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetCulturalObservationQuizAttemptsTest()
        {
            var response = new CultureObservationToolQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<CultureObservationToolQuiz>
            { new CultureObservationToolQuiz { id= 1 } };
            _mokculturalObservationAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokculturalObservationAdapter.Setup(a => a.GetCutlturalObservationQuiz()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetCulturalObservationQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }

        [Test]
        public void GetProductivityZoneQuizAttemptsTest()
        {
            var response = new ProductivityZoneQuizAttempts
            {
                attemptcount = 1
            };
            var quizAttemptResponse = new List<BsonDocument>
            {
                new BsonDocument { }
            };
            var request = new QuizDetails();
            var quizResponse = new List<ProductivityZoneQuiz>
            { new ProductivityZoneQuiz { id= 1 } };
            _mokproductivityZoneQuizAdapter.Setup(a => a.GetLatestAttemptByUser(It.IsAny<string>())).Returns(response);
            _mokquizAttempt.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(quizAttemptResponse);

            _mokproductivityZoneQuizAdapter.Setup(a => a.GetProductivityZoneQuizzes()).Returns(quizResponse);

            _reportsAdpater = new ReportsAdapter(_mokquizAttempt.Object, _settings.Object, _mokcuriousQuizAdapter.Object, _mokgrowthMindsetQuizAdapter.Object,
                _mokmakingTimeForMeQuizAdapter.Object, _mokstoryTellingForImpactAdapter.Object, _mokblindSpotAdapter.Object, _moklearningMythAdapter.Object, _mokcontinuousLearningAdapter.Object,
                _mokculturalObservationAdapter.Object, _mokproductivityZoneQuizAdapter.Object, _mokreflectionToolAdapter.Object);

            var result = _reportsAdpater.GetProductivityZoneQuizAttempts("", 2, request);
            Assert.IsInstanceOf<List<QuizAttempts>>(result);
        }
    }
}
