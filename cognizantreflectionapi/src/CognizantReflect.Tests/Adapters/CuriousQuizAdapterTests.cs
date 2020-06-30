using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.CuriosityQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class CuriousQuizAdapterTests
    {
        private Mock<IMongoClientHelper<CuriousQuiz>> _mokcuriousQuiz;
        private Mock<IMongoClientHelper<CuriousQuizAttempts>> _mokcuriousQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private CuriousQuizAdapter _curiousQuizAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokcuriousQuiz = new Mock<IMongoClientHelper<CuriousQuiz>>();
            _mokcuriousQuizAttempt = new Mock<IMongoClientHelper<CuriousQuizAttempts>>();
        }

        [Test]
        public void GetCutlturalObservationQuizTest()
        {
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };

            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcuriousQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _curiousQuizAdapter = new CuriousQuizAdapter(_mokcuriousQuiz.Object, _mokcuriousQuizAttempt.Object, _settings.Object);

            var result = _curiousQuizAdapter.GetCuriosQuizzes();
            Assert.IsInstanceOf<List<CuriousQuiz>>(result);
        }

        [Test]
        public void InsertCuriosQuizTest()
        {
            var request = new CuriousQuiz();
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };

            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcuriousQuiz.Setup(a => a.InsertOne(It.IsAny<CuriousQuiz>(), It.IsAny<string>()));

            _curiousQuizAdapter = new CuriousQuizAdapter(_mokcuriousQuiz.Object, _mokcuriousQuizAttempt.Object, _settings.Object);

            var result = _curiousQuizAdapter.InsertCuriosQuiz(request);
            _mokcuriousQuiz.Verify(a => a.InsertOne(It.IsAny<CuriousQuiz>(), It.IsAny<string>()));
        }

        [Test]
        public void InsertCuriosQuizResponseTest()
        {
            var request = new List<CuriousQuizAttempts>();

            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcuriousQuizAttempt.Setup(a => a.InsertAll(It.IsAny<List<CuriousQuizAttempts>>(), It.IsAny<string>()));

            _curiousQuizAdapter = new CuriousQuizAdapter(_mokcuriousQuiz.Object, _mokcuriousQuizAttempt.Object, _settings.Object);

            var result = _curiousQuizAdapter.InsertCuriosQuizResponse(request);
            _mokcuriousQuizAttempt.Verify(a => a.InsertAll(It.IsAny<List<CuriousQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestIdTest()
        {
            var request = new List<CuriousQuizAttempts>();

            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcuriousQuizAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(),It.IsAny<SortDefinition<CuriousQuizAttempts>>()));

            _curiousQuizAdapter = new CuriousQuizAdapter(_mokcuriousQuiz.Object, _mokcuriousQuizAttempt.Object, _settings.Object);

            var result = _curiousQuizAdapter.GetLatestId();
            _mokcuriousQuizAttempt.Verify(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<CuriousQuizAttempts>>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            var request = new List<CuriousQuizAttempts>();

            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcuriousQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>()));

            _curiousQuizAdapter = new CuriousQuizAdapter(_mokcuriousQuiz.Object, _mokcuriousQuizAttempt.Object, _settings.Object);

            var result = _curiousQuizAdapter.GetLatestAttemptByUser("");
            _mokcuriousQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetCuriousAttemptsTest()
        {
            var request = new List<CuriousQuizAttempts>();

            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcuriousQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>()));

            _curiousQuizAdapter = new CuriousQuizAdapter(_mokcuriousQuiz.Object, _mokcuriousQuizAttempt.Object, _settings.Object);

            var result = _curiousQuizAdapter.GetCuriousAttempts("",1);
            _mokcuriousQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<CuriousQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
