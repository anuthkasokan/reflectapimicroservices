using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CognizantReflect.Tests.Adapters
{
    public class ContinuousLearningAdapterTest
    {
        private readonly Mock<IMongoClientHelper<ContinuousLearningAssessmentQuiz>> _continuousLearningAssessmentQuiz = new Mock<IMongoClientHelper<ContinuousLearningAssessmentQuiz>>();
        private readonly Mock<IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts>> _continuousLearningAssessmentQuizAttempt = new Mock<IMongoClientHelper<ContinuousLearningAssessmentQuizAttempts>>();
        private readonly string _userDetailsCollection = "";
        private Mock<IOptions<MongoDbSettings>> _settings;
        private ContinuousLearningAdapter _continuousLearningAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
        }
        [Test]
        public void ContinuousLearningAdapter_GetContinuousLearningAssessmentQuizzes()
        {
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };

            var settings = new MongoDbSettings { ContinuousLearningAssessmentQuizCollection="" , ContinuousLearningAssessmentQuizAttemptsCollection=""};
            _settings.Setup(s => s.Value).Returns(settings);
            _continuousLearningAssessmentQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _continuousLearningAdapter = new ContinuousLearningAdapter(_continuousLearningAssessmentQuiz.Object, _continuousLearningAssessmentQuizAttempt.Object, _settings.Object);

            List<ContinuousLearningAssessmentQuiz> result = _continuousLearningAdapter.GetContinuousLearningAssessmentQuizzes();
            Assert.IsInstanceOf<List<ContinuousLearningAssessmentQuiz>>(result);
        }
    }
    
}
