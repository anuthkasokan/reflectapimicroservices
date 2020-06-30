using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
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
    public class CulturalObservationAdapterTests
    {
        private Mock<IMongoClientHelper<CultureObservationToolQuiz>> _mokcultureObservationToolQuiz;
        private Mock<IMongoClientHelper<CultureObservationToolQuizAttempts>> _mokcultureObservationToolQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private CulturalObservationAdapter _cultureObservationToolAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokcultureObservationToolQuiz = new Mock<IMongoClientHelper<CultureObservationToolQuiz>>();
            _mokcultureObservationToolQuizAttempt = new Mock<IMongoClientHelper<CultureObservationToolQuizAttempts>>();
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
            _mokcultureObservationToolQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _cultureObservationToolAdapter = new CulturalObservationAdapter(_mokcultureObservationToolQuiz.Object,_mokcultureObservationToolQuizAttempt.Object,_settings.Object);

            var result = _cultureObservationToolAdapter.GetCutlturalObservationQuiz();
            Assert.IsInstanceOf<List<CultureObservationToolQuiz>>(result);
        }

        [Test]
        public void InsertCultureObservationAttemptTest()
        {
            var request = new List<CultureObservationToolQuizAttempts>();
            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcultureObservationToolQuizAttempt.Setup(a => a.InsertAll(It.IsAny<List<CultureObservationToolQuizAttempts>>(), It.IsAny<string>()));

            _cultureObservationToolAdapter = new CulturalObservationAdapter(_mokcultureObservationToolQuiz.Object, _mokcultureObservationToolQuizAttempt.Object, _settings.Object);
            _cultureObservationToolAdapter.InsertCultureObservationAttempt(request);

            _mokcultureObservationToolQuizAttempt.Verify(a => a.InsertAll(It.IsAny<List<CultureObservationToolQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestAttemptIdTest()
        {
            var response = new List<CultureObservationToolQuizAttempts>
            {
                new CultureObservationToolQuizAttempts { id = 1 }
            };
            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcultureObservationToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _cultureObservationToolAdapter = new CulturalObservationAdapter(_mokcultureObservationToolQuiz.Object, _mokcultureObservationToolQuizAttempt.Object, _settings.Object);
            var result = _cultureObservationToolAdapter.GetLatestAttemptId();

            _mokcultureObservationToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>()));
            Assert.IsInstanceOf<CultureObservationToolQuizAttempts>(result);
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            var response = new List<CultureObservationToolQuizAttempts>
            {
                new CultureObservationToolQuizAttempts { id = 1 }
            };
            var settings = new MongoDbSettings { CultureObservationToolQuizCollection = "", CultureObservationToolQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokcultureObservationToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>())).Returns(response);

            _cultureObservationToolAdapter = new CulturalObservationAdapter(_mokcultureObservationToolQuiz.Object, _mokcultureObservationToolQuizAttempt.Object, _settings.Object);
            var result = _cultureObservationToolAdapter.GetLatestAttemptByUser("");

            _mokcultureObservationToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<CultureObservationToolQuizAttempts>>(), It.IsAny<string>()));
            Assert.IsInstanceOf<CultureObservationToolQuizAttempts>(result);
        }
    }
}
