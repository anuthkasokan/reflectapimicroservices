using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using ReflectionFeedback.Api.Adapters;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionFeedback.Tests.Adapters
{
    [TestFixture]
    public class StoreFeedbackAdapterTests
    {
        private Mock<IMongoClientHelper<Feedback>> _mokfeedbackClientHelper;
        private Mock<IMongoClientHelper<FeedbackReply>> _mokfeedbackReplyClientHelper;
        private Mock<IOptions<MongoDbSettings>> _settings;

        [SetUp]
        public void SetUp()
        {
            _mokfeedbackClientHelper = new Mock<IMongoClientHelper<Feedback>>();
            _mokfeedbackReplyClientHelper = new Mock<IMongoClientHelper<FeedbackReply>>();
            _settings = new Mock<IOptions<MongoDbSettings>>();
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void SaveFeedbackQuestionTest()
        {
            //arrange
            var request = new Feedback();
            _mokfeedbackClientHelper.Setup(a => a.InsertOne(It.IsAny<Feedback>(), It.IsAny<string>()));

            //act
            var feedbackAdapter = new StoreFeedbackAdapter(_mokfeedbackReplyClientHelper.Object, _mokfeedbackClientHelper.Object, _settings.Object);
            feedbackAdapter.SaveFeedbackQuestion(request);

            //assert
            _mokfeedbackClientHelper.Verify(a => a.InsertOne(It.IsAny<Feedback>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void SaveFeedbackReplyTest()
        {
            //arrange
            var request = new FeedbackReply();
            
            _mokfeedbackReplyClientHelper.Setup(a => a.InsertOne(It.IsAny<FeedbackReply>(), It.IsAny<string>()));
            _mokfeedbackClientHelper.Setup(a => a.UpdateOne(It.IsAny<UpdateDefinition<Feedback>>(), It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()));

            //act
            var feedbackAdapter = new StoreFeedbackAdapter(_mokfeedbackReplyClientHelper.Object, _mokfeedbackClientHelper.Object, _settings.Object);
            feedbackAdapter.SaveFeedbackReply(request);

            //assert
            _mokfeedbackReplyClientHelper.Verify(a => a.InsertOne(It.IsAny<FeedbackReply>(), It.IsAny<string>()),Times.Once);
            _mokfeedbackClientHelper.Verify(a => a.UpdateOne(It.IsAny<UpdateDefinition<Feedback>>(), It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddOrUpdateFeedbackFromAdminTest()
        {
            //arrange
            var request = new List<Feedback>();

            _mokfeedbackClientHelper.Setup(a => a.DeleteMany(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()));
            _mokfeedbackClientHelper.Setup(a => a.InsertMany(It.IsAny<List<Feedback>>(), It.IsAny<string>()));

            //act
            var feedbackAdapter = new StoreFeedbackAdapter(_mokfeedbackReplyClientHelper.Object, _mokfeedbackClientHelper.Object, _settings.Object);
            feedbackAdapter.AddOrUpdateFeedbackFromAdmin(request);

            //assert
            _mokfeedbackClientHelper.Verify(a => a.DeleteMany(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()), Times.Once);
            _mokfeedbackClientHelper.Verify(a => a.InsertMany(It.IsAny<List<Feedback>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void FillFeedbackDataTest()
        {
            //arrange

            _mokfeedbackReplyClientHelper.Setup(a => a.InsertMany(It.IsAny<List<FeedbackReply>>(), It.IsAny<string>()));
            _mokfeedbackClientHelper.Setup(a => a.InsertMany(It.IsAny<List<Feedback>>(), It.IsAny<string>()));

            //act
            var feedbackAdapter = new StoreFeedbackAdapter(_mokfeedbackReplyClientHelper.Object, _mokfeedbackClientHelper.Object, _settings.Object);
            feedbackAdapter.FillFeedbackData();

            //assert
            _mokfeedbackReplyClientHelper.Verify(a => a.InsertMany(It.IsAny<List<FeedbackReply>>(), It.IsAny<string>()), Times.Once);
            _mokfeedbackClientHelper.Verify(a => a.InsertMany(It.IsAny<List<Feedback>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void DeleteFeedbackTest()
        {
            //arrange
            var request = 1;
            _mokfeedbackClientHelper.Setup(a => a.DeleteOne(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()));

            //act
            var feedbackAdapter = new StoreFeedbackAdapter(_mokfeedbackReplyClientHelper.Object, _mokfeedbackClientHelper.Object, _settings.Object);
            feedbackAdapter.DeleteFeedback(request);

            //assert
            _mokfeedbackClientHelper.Verify(a => a.DeleteOne(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void UpdateFeedbackAssignedTest()
        {
            //arrange
            var request = new Feedback();
            _mokfeedbackClientHelper.Setup(a => a.UpdateOne(It.IsAny<UpdateDefinition<Feedback>>(), It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()));

            //act
            var feedbackAdapter = new StoreFeedbackAdapter(_mokfeedbackReplyClientHelper.Object, _mokfeedbackClientHelper.Object, _settings.Object);
            feedbackAdapter.UpdateFeedbackAssigned(request);

            //assert
            _mokfeedbackClientHelper.Verify(a => a.UpdateOne(It.IsAny<UpdateDefinition<Feedback>>(), It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>()), Times.Once);
        }
    }
}
