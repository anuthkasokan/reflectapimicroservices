using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using ReflectionFeedback.Api.Adapters;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace ReflectionFeedback.Tests.Adapters
{
    [TestFixture]
    public class GetFeedbackDetailsAdapterTests
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
        }

        [Test]
        public void GetFeedBacksAssignedToUserReturnsValidData()
        {
            //arrange
            string userid = "1";
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "",FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokfeedbackClientHelper.Setup(a => a.GetData(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>())).Returns(response);

            //act
            var feedbackAdapter = new GetFeedbackDetailsAdapter(_mokfeedbackClientHelper.Object, _mokfeedbackReplyClientHelper.Object, _settings.Object);
            var detail = feedbackAdapter.GetFeedBacksAssignedToUser(userid);

            //assert
            Assert.IsInstanceOf<List<Feedback>>(detail);
        }

        [Test]
        public void GetFeedbackRequestsByUserReturnsValidData()
        {
            //arrange
            string userid = "1";
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokfeedbackClientHelper.Setup(a => a.GetData(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>())).Returns(response);

            //act
            var feedbackAdapter = new GetFeedbackDetailsAdapter(_mokfeedbackClientHelper.Object, _mokfeedbackReplyClientHelper.Object, _settings.Object);
            var detail = feedbackAdapter.GetFeedbackRequestsByUser(userid);

            //assert
            Assert.IsInstanceOf<List<Feedback>>(detail);
        }

        [Test]
        public void GetFeedbackReplyForQuestionReturnsValidData()
        {
            //arrange
            long questionId = 1;
            var response = new List<FeedbackReply>
            {
                new FeedbackReply { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokfeedbackReplyClientHelper.Setup(a => a.GetData(It.IsAny<FilterDefinition<FeedbackReply>>(), It.IsAny<string>())).Returns(response);

            //act
            var feedbackAdapter = new GetFeedbackDetailsAdapter(_mokfeedbackClientHelper.Object, _mokfeedbackReplyClientHelper.Object, _settings.Object);
            var detail = feedbackAdapter.GetFeedbackReplyForQuestion(questionId);

            //assert
            Assert.IsInstanceOf<FeedbackReply>(detail);
        }

        [Test]
        public void GetAllPendingFeedbacksReturnsValidData()
        {
            //arrange
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var replyResponse = new List<FeedbackReply>
            {
                new FeedbackReply { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokfeedbackClientHelper.Setup(a => a.GetData(It.IsAny<FilterDefinition<Feedback>>(), It.IsAny<string>())).Returns(response);
            _mokfeedbackReplyClientHelper.Setup(a => a.GetData(It.IsAny<FilterDefinition<FeedbackReply>>(), It.IsAny<string>())).Returns(replyResponse);

            //act
            var feedbackAdapter = new GetFeedbackDetailsAdapter(_mokfeedbackClientHelper.Object, _mokfeedbackReplyClientHelper.Object, _settings.Object);
            var detail = feedbackAdapter.GetAllPendingFeedbacks();

            //assert
            Assert.IsInstanceOf<List<Feedback>>(detail);
        }

        [Test]
        public void GetLastAddedFeedbackReturnsValidData()
        {
            //arrange
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var replyResponse = new List<FeedbackReply>
            {
                new FeedbackReply { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokfeedbackClientHelper.Setup(a => a.GetDataBySorting(It.IsAny<FilterDefinition<Feedback>>(),It.IsAny<SortDefinition<Feedback>>(), It.IsAny<string>())).Returns(response);

            //act
            var feedbackAdapter = new GetFeedbackDetailsAdapter(_mokfeedbackClientHelper.Object, _mokfeedbackReplyClientHelper.Object, _settings.Object);
            var detail = feedbackAdapter.GetLastAddedFeedback();

            //assert
            Assert.IsInstanceOf<long>(detail);
        }
        [Test]
        public void GetLastAddedFeedbackReplyReturnsValidData()
        {
            //arrange
            var replyResponse = new List<FeedbackReply>
            {
                new FeedbackReply { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokfeedbackReplyClientHelper.Setup(a => a.GetDataBySorting(It.IsAny<FilterDefinition<FeedbackReply>>(), It.IsAny<SortDefinition<FeedbackReply>>(), It.IsAny<string>())).Returns(replyResponse);

            //act
            var feedbackAdapter = new GetFeedbackDetailsAdapter(_mokfeedbackClientHelper.Object, _mokfeedbackReplyClientHelper.Object, _settings.Object);
            var detail = feedbackAdapter.GetLastAddedFeedbackReply();

            //assert
            Assert.IsInstanceOf<long>(detail);
        }
    }
}
