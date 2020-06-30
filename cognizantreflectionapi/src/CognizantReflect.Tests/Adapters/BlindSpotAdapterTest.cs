using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class BlindSpotAdapterTest
    {

        private readonly Mock<IMongoClientHelper<BlindSpotQuizAttempts>> _blindSpotAttemptsMongoHelper = new Mock<IMongoClientHelper<BlindSpotQuizAttempts>>();
        private readonly Mock<IMongoClientHelper<BlindSpotQuizQuestions>> _blindSpotQuestionsMongoHelper = new Mock<IMongoClientHelper<BlindSpotQuizQuestions>>();        
        private readonly Mock<IMongoClientHelper<BlindSpotCoWorkerReply>> _blindSpotCoWorkerMongoHelper=new Mock<IMongoClientHelper<BlindSpotCoWorkerReply>>();
        private readonly string _userDetailsCollection = "";
        private readonly string _blindSpotAttemptCollection;
        private Mock<IOptions<MongoDbSettings>> _settings;


        private BlindSpotAdapter  _blindSpotAdapter;

        [SetUp]
        public void SetUp()
        {
            
            _settings = new Mock<IOptions<MongoDbSettings>>();

        }

        [Test]
        public void BlindSpotAdapter_GetBlindSpotQuizQuestions()
        {

            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };
            var settings = new MongoDbSettings { BlindSpotQuizAttemptsCollection = "",BlindSpotQuizCollection="",BlindSpotQuizCoWorkerReplyCollection=""};
            _settings.Setup(s => s.Value).Returns(settings);
            _blindSpotQuestionsMongoHelper.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);
            _blindSpotAdapter = new BlindSpotAdapter(_blindSpotAttemptsMongoHelper.Object, _blindSpotQuestionsMongoHelper.Object, _blindSpotCoWorkerMongoHelper.Object, _settings.Object);
           

            var result = _blindSpotAdapter.GetBlindSpotQuizQuestions();
            Assert.IsInstanceOf<BlindSpotQuizQuestions>(result);
        }
        [Test]
        public void BlindSpotAdapter_GetBlindSpotAttemptResponse()
        {

            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };

            var settings = new MongoDbSettings { BlindSpotQuizAttemptsCollection = "", BlindSpotQuizCollection = "", BlindSpotQuizCoWorkerReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _blindSpotQuestionsMongoHelper.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(response);
            
            _blindSpotAdapter = new BlindSpotAdapter(_blindSpotAttemptsMongoHelper.Object, _blindSpotQuestionsMongoHelper.Object, _blindSpotCoWorkerMongoHelper.Object, _settings.Object);


            var result = _blindSpotAdapter.GetBlindSpotAttemptResponse(12,"");
            Assert.IsInstanceOf<BlindSpotQuizAttempts>(result);
        }
        [Test]
        public void BlindSpotAdapter_GetDataForCoWorkerReply()
        {

            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };
            int attemptId = 1245;
            var settings = new MongoDbSettings { BlindSpotQuizAttemptsCollection = "", BlindSpotQuizCollection = "", BlindSpotQuizCoWorkerReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _blindSpotQuestionsMongoHelper.Setup(a => a.GetRecords(It.IsAny<string>(), It.IsAny<FilterDefinition<BsonDocument>>())).Returns(response);

            _blindSpotAdapter = new BlindSpotAdapter(_blindSpotAttemptsMongoHelper.Object, _blindSpotQuestionsMongoHelper.Object, _blindSpotCoWorkerMongoHelper.Object, _settings.Object);


            var result = _blindSpotAdapter.GetDataForCoWorkerReply(attemptId);
            Assert.IsInstanceOf<List<BlindSpotCoWorkerReply>>(result);
        }

    }
}
