using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
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
    public class StoryTellingForImpactAdapterTests
    {
        private Mock<IMongoClientHelper<StoryTellingForImpactQuiz>> _mokstoryTellingForImpactQuiz;
        private Mock<IMongoClientHelper<StoryTellingForImpactQuizAttempts>> _mokstoryTellingForImpactQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private StoryTellingForImpactAdapter _storyTellingForImpactQuizAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokstoryTellingForImpactQuiz = new Mock<IMongoClientHelper<StoryTellingForImpactQuiz>>();
            _mokstoryTellingForImpactQuizAttempt = new Mock<IMongoClientHelper<StoryTellingForImpactQuizAttempts>>();
            var settings = new MongoDbSettings { StoryTellingForImpactQuizCollection = "", StoryTellingForImpactQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetStoryTellingForImpactQuizzesTest()
        {
            var response = new List<BsonDocument>();
            var getLatestIdResponse = new StoryTellingForImpactQuizAttempts();
            _mokstoryTellingForImpactQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _storyTellingForImpactQuizAdapter = new StoryTellingForImpactAdapter(_mokstoryTellingForImpactQuiz.Object, _settings.Object, _mokstoryTellingForImpactQuizAttempt.Object);

            var result = _storyTellingForImpactQuizAdapter.GetStoryTellingForImpactQuizzes();
            Assert.IsInstanceOf<List<StoryTellingForImpactQuiz>>(result);
        }

        [Test]
        public void InsertStoryTellingForImpactQuizzesTest()
        {
            var request = new StoryTellingForImpactQuiz();
            var getLatestIdResponse = new StoryTellingForImpactQuizAttempts();
            _mokstoryTellingForImpactQuiz.Setup(a => a.InsertOne(It.IsAny<StoryTellingForImpactQuiz>(),It.IsAny<string>()));

            _storyTellingForImpactQuizAdapter = new StoryTellingForImpactAdapter(_mokstoryTellingForImpactQuiz.Object, _settings.Object, _mokstoryTellingForImpactQuizAttempt.Object);

            var result = _storyTellingForImpactQuizAdapter.InsertStoryTellingForImpactQuizzes(request);
            _mokstoryTellingForImpactQuiz.Verify(a => a.InsertOne(It.IsAny<StoryTellingForImpactQuiz>(),It.IsAny<string>()));
        }

        [Test]
        public void InsertStoryTellingForImpactQuizzAttemptsTest()
        {
            var request = new List<StoryTellingForImpactQuizAttempts>();
            var getLatestIdResponse = new StoryTellingForImpactQuizAttempts();
            _mokstoryTellingForImpactQuizAttempt.Setup(a => a.InsertAll(It.IsAny<List<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>()));

            _storyTellingForImpactQuizAdapter = new StoryTellingForImpactAdapter(_mokstoryTellingForImpactQuiz.Object, _settings.Object, _mokstoryTellingForImpactQuizAttempt.Object);

            var result = _storyTellingForImpactQuizAdapter.InsertStoryTellingForImpactQuizzAttempts(request);
            _mokstoryTellingForImpactQuizAttempt.Verify(a => a.InsertAll(It.IsAny<List<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestIdTest()
        {
            var request = new List<StoryTellingForImpactQuizAttempts>();
            var getLatestIdResponse = new StoryTellingForImpactQuizAttempts();
            _mokstoryTellingForImpactQuizAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<StoryTellingForImpactQuizAttempts>>()));

            _storyTellingForImpactQuizAdapter = new StoryTellingForImpactAdapter(_mokstoryTellingForImpactQuiz.Object, _settings.Object, _mokstoryTellingForImpactQuizAttempt.Object);

            var result = _storyTellingForImpactQuizAdapter.GetLatestId();
            _mokstoryTellingForImpactQuizAttempt.Verify(a => a.GetLatestId(It.IsAny<string>(), It.IsAny<SortDefinition<StoryTellingForImpactQuizAttempts>>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            var request = new List<StoryTellingForImpactQuizAttempts>();
            var getLatestIdResponse = new StoryTellingForImpactQuizAttempts();
            _mokstoryTellingForImpactQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>()));

            _storyTellingForImpactQuizAdapter = new StoryTellingForImpactAdapter(_mokstoryTellingForImpactQuiz.Object, _settings.Object, _mokstoryTellingForImpactQuizAttempt.Object);

            var result = _storyTellingForImpactQuizAdapter.GetLatestAttemptByUser("");
            _mokstoryTellingForImpactQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<StoryTellingForImpactQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
