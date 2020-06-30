using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
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
    public class GrowthMindsetAdapterTests
    {
        private Mock<IMongoClientHelper<GrowthMindsetQuiz>> _mokgrowthMindsetQuiz;
        private Mock<IMongoClientHelper<GrowthMindsetQuizAttempts>> _mokgrowthMindsetAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private GrowthMindsetAdapter _growthMindsetAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokgrowthMindsetQuiz = new Mock<IMongoClientHelper<GrowthMindsetQuiz>>();
            _mokgrowthMindsetAttempt = new Mock<IMongoClientHelper<GrowthMindsetQuizAttempts>>();
            var settings = new MongoDbSettings { BlindSpotQuizCollection = "", BlindSpotQuizCoWorkerReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetGrowthMindsetQuizTest()
        {
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };            
            _mokgrowthMindsetQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _growthMindsetAdapter = new GrowthMindsetAdapter(_mokgrowthMindsetQuiz.Object, _mokgrowthMindsetAttempt.Object, _settings.Object);

            var result = _growthMindsetAdapter.GetGrowthMindsetQuiz();
            Assert.IsInstanceOf<List<GrowthMindsetQuiz>>(result);
        }

        [Test]
        public void InsertGrowthMindsetQuizTest()
        {
            var request = new GrowthMindsetQuiz();
            _mokgrowthMindsetQuiz.Setup(a => a.InsertOne(It.IsAny<GrowthMindsetQuiz>(),It.IsAny<string>()));

            _growthMindsetAdapter = new GrowthMindsetAdapter(_mokgrowthMindsetQuiz.Object, _mokgrowthMindsetAttempt.Object, _settings.Object);

            var result = _growthMindsetAdapter.InsertGrowthMindsetQuiz(request);
            _mokgrowthMindsetQuiz.Verify(a => a.InsertOne(It.IsAny<GrowthMindsetQuiz>(), It.IsAny<string>()));
        }

        [Test]
        public void InsertGrowthMindsetQuizAttemptsTest()
        {
            var request = new List<GrowthMindsetQuizAttempts>();
            _mokgrowthMindsetAttempt.Setup(a => a.InsertAll(It.IsAny<List<GrowthMindsetQuizAttempts>>(), It.IsAny<string>()));

            _growthMindsetAdapter = new GrowthMindsetAdapter(_mokgrowthMindsetQuiz.Object, _mokgrowthMindsetAttempt.Object, _settings.Object);

            var result = _growthMindsetAdapter.InsertGrowthMindsetQuizAttempts(request);
            _mokgrowthMindsetAttempt.Setup(a => a.InsertAll(It.IsAny<List<GrowthMindsetQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestIdTest()
        {
            var request = new List<GrowthMindsetQuizAttempts>();
            _mokgrowthMindsetAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<GrowthMindsetQuizAttempts>>()));

            _growthMindsetAdapter = new GrowthMindsetAdapter(_mokgrowthMindsetQuiz.Object, _mokgrowthMindsetAttempt.Object, _settings.Object);

            var result = _growthMindsetAdapter.GetLatestId();
            _mokgrowthMindsetAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<GrowthMindsetQuizAttempts>>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            var response = new List<GrowthMindsetQuizAttempts>
            {
                new GrowthMindsetQuizAttempts { attemptcount = 1 }
            };
            _mokgrowthMindsetAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>()));

            _growthMindsetAdapter = new GrowthMindsetAdapter(_mokgrowthMindsetQuiz.Object, _mokgrowthMindsetAttempt.Object, _settings.Object);

            var result = _growthMindsetAdapter.GetLatestAttemptByUser("");
            _mokgrowthMindsetAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<GrowthMindsetQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
