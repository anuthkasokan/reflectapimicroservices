using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class LearningMythsAdapterTests
    {
        private Mock<IMongoClientHelper<LearningMythsQuiz>> _moklearningMythQuiz;
        private Mock<IMongoClientHelper<LearningMythsQuizAttempts>> _moklearningMythQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private LearningMythsAdapter _learningMythAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _moklearningMythQuiz = new Mock<IMongoClientHelper<LearningMythsQuiz>>();
            _moklearningMythQuizAttempt = new Mock<IMongoClientHelper<LearningMythsQuizAttempts>>();
            var settings = new MongoDbSettings { LearningMythsQuizCollection = "", LearningMythsQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetLearningMythsQuizzesTest()
        {
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };
            _moklearningMythQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _learningMythAdapter = new LearningMythsAdapter(_moklearningMythQuiz.Object, _moklearningMythQuizAttempt.Object, _settings.Object);

            var result = _learningMythAdapter.GetLearningMythsQuizzes();
            Assert.IsInstanceOf<List<LearningMythsQuiz>>(result);
        }

        [Test]
        public void InsertLearningMythQuizAttemptsTest()
        {
            var request = new List<LearningMythsQuizAttempts>();
            _moklearningMythQuizAttempt.Setup(a => a.InsertAll(It.IsAny<List<LearningMythsQuizAttempts>>(), It.IsAny<string>()));

            _learningMythAdapter = new LearningMythsAdapter(_moklearningMythQuiz.Object, _moklearningMythQuizAttempt.Object, _settings.Object);

            var result = _learningMythAdapter.InsertLearningMythQuizAttempts(request);
            _moklearningMythQuizAttempt.Verify(a => a.InsertAll(It.IsAny<List<LearningMythsQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestIdTest()
        {
            var request = new List<LearningMythsQuizAttempts>();
            _moklearningMythQuizAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<LearningMythsQuizAttempts>>()));

            _learningMythAdapter = new LearningMythsAdapter(_moklearningMythQuiz.Object, _moklearningMythQuizAttempt.Object, _settings.Object);

            var result = _learningMythAdapter.GetLatestId();
            _moklearningMythQuizAttempt.Verify(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<LearningMythsQuizAttempts>>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            var response = new List<LearningMythsQuizAttempts>
            {
                new LearningMythsQuizAttempts { attemptcount = 1 }
            };
            _moklearningMythQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<LearningMythsQuizAttempts>>(), It.IsAny<string>()));

            _learningMythAdapter = new LearningMythsAdapter(_moklearningMythQuiz.Object, _moklearningMythQuizAttempt.Object, _settings.Object);

            var result = _learningMythAdapter.GetLatestAttemptByUser("");
            _moklearningMythQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<LearningMythsQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
