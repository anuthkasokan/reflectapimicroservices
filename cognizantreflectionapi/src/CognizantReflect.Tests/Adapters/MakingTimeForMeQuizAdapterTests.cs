using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
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
    public class MakingTimeForMeQuizAdapterTests
    {
        private Mock<IMongoClientHelper<MakingTimeForMeQuiz>> _mokmakingTimeForMeQuiz;
        private Mock<IMongoClientHelper<MakingTimeForMeQuizAttempts>> _mokmakingTimeForMeQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private MakingTimeForMeQuizAdapter _makingTimeForMeQuizAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokmakingTimeForMeQuiz = new Mock<IMongoClientHelper<MakingTimeForMeQuiz>>();
            _mokmakingTimeForMeQuizAttempt = new Mock<IMongoClientHelper<MakingTimeForMeQuizAttempts>>();
            var settings = new MongoDbSettings { MakingTimeForMeQuizCollection = "", MakingTimeForMeQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetMakingTimeForMeQuizzesTest()
        {
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };
            _mokmakingTimeForMeQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _makingTimeForMeQuizAdapter = new MakingTimeForMeQuizAdapter(_mokmakingTimeForMeQuiz.Object, _mokmakingTimeForMeQuizAttempt.Object, _settings.Object);

            var result = _makingTimeForMeQuizAdapter.GetMakingTimeForMeQuizzes();
            Assert.IsInstanceOf<List<MakingTimeForMeQuiz>>(result);
        }

        [Test]
        public void InsertMakingTimeForMeQuizTest()
        {
            var request = new MakingTimeForMeQuiz();
            _mokmakingTimeForMeQuiz.Setup(a => a.InsertOne(It.IsAny<MakingTimeForMeQuiz>(),It.IsAny<string>()));

            _makingTimeForMeQuizAdapter = new MakingTimeForMeQuizAdapter(_mokmakingTimeForMeQuiz.Object, _mokmakingTimeForMeQuizAttempt.Object, _settings.Object);

            var result = _makingTimeForMeQuizAdapter.InsertMakingTimeForMeQuiz(request);
            _mokmakingTimeForMeQuiz.Verify(a => a.InsertOne(It.IsAny<MakingTimeForMeQuiz>(), It.IsAny<string>()));
        }

        [Test]
        public void InsertMakingTimeForMeQuizAttemptsTest()
        {
            var request = new List<MakingTimeForMeQuizAttempts>();
            _mokmakingTimeForMeQuizAttempt.Setup(a => a.InsertAll(It.IsAny<List<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>()));

            _makingTimeForMeQuizAdapter = new MakingTimeForMeQuizAdapter(_mokmakingTimeForMeQuiz.Object, _mokmakingTimeForMeQuizAttempt.Object, _settings.Object);

            var result = _makingTimeForMeQuizAdapter.InsertMakingTimeForMeQuizAttempts(request);
            _mokmakingTimeForMeQuizAttempt.Verify(a => a.InsertAll(It.IsAny<List<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestIdTest()
        {
            _mokmakingTimeForMeQuizAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(),It.IsAny<SortDefinition<MakingTimeForMeQuizAttempts>>()));

            _makingTimeForMeQuizAdapter = new MakingTimeForMeQuizAdapter(_mokmakingTimeForMeQuiz.Object, _mokmakingTimeForMeQuizAttempt.Object, _settings.Object);

            var result = _makingTimeForMeQuizAdapter.GetLatestId();
            _mokmakingTimeForMeQuizAttempt.Verify(a => a.GetLatestId(It.IsAny<string>(),It.IsAny<SortDefinition<MakingTimeForMeQuizAttempts>>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            _mokmakingTimeForMeQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>()));

            _makingTimeForMeQuizAdapter = new MakingTimeForMeQuizAdapter(_mokmakingTimeForMeQuiz.Object, _mokmakingTimeForMeQuizAttempt.Object, _settings.Object);

            var result = _makingTimeForMeQuizAdapter.GetLatestAttemptByUser("");
            _mokmakingTimeForMeQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<MakingTimeForMeQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
