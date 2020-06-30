using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using ReflectionFeedback.Api.Adapters.Interfaces;
using ReflectionFeedback.Api.BusinessLogics;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionFeedback.Tests.BusinessLogic
{
    [TestFixture]
    public class FeedbackBusinessLogicsTests
    {
        private Mock<IStoreFeedbackAdapter> _mokstoreFeedbackAdapter;
        private Mock<IGetFeedbackDetailsAdapter> _mokgetFeedbackDetailsAdapter;
        private Mock<IOptions<MongoDbSettings>> _settings;

        [SetUp]
        public void SetUp()
        {
            _mokstoreFeedbackAdapter = new Mock<IStoreFeedbackAdapter>();
            _mokgetFeedbackDetailsAdapter = new Mock<IGetFeedbackDetailsAdapter>();
            _settings = new Mock<IOptions<MongoDbSettings>>();
        }

        [Test]
        public void StoreFeedbackQuestionsTest()
        {
            //arrange
            var request = new Feedback();
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetLastAddedFeedback()).Returns(1);
            _mokstoreFeedbackAdapter.Setup(a => a.SaveFeedbackQuestion(It.IsAny<Feedback>()));
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.StoreFeedbackQuestions(request);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetLastAddedFeedback(), Times.Once);
            _mokstoreFeedbackAdapter.Verify(a => a.SaveFeedbackQuestion(It.IsAny<Feedback>()), Times.Once);
        }

        [Test]
        public void GetFeedbackDetailsForAdminTest()
        {
            //arrange
            var request = new Feedback();
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetAllPendingFeedbacks()).Returns(new List<Feedback>());
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            var result = feedbackAdapter.GetFeedbackDetailsForAdmin();

            //assert
            Assert.IsInstanceOf<List<Feedback>>(result);
        }

        [Test]
        public void SaveFeedbackReplyTest()
        {
            //arrange
            var request = new FeedbackReply();
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetLastAddedFeedbackReply()).Returns(1);
            _mokstoreFeedbackAdapter.Setup(a => a.SaveFeedbackReply(It.IsAny<FeedbackReply>()));
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.SaveFeedbackReply(request);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetLastAddedFeedbackReply(), Times.Once);
            _mokstoreFeedbackAdapter.Verify(a => a.SaveFeedbackReply(It.IsAny<FeedbackReply>()), Times.Once);
        }

        [Test]
        public void UpdateOrAddFeedbacksByAdminTestForIdIsZero()
        {
            //arrange
            var request = new List<Feedback>
            {
                new Feedback { id = 0 ,assigned = "yes"}
            };
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetLastAddedFeedback()).Returns(1);
            _mokstoreFeedbackAdapter.Setup(a => a.SaveFeedbackQuestion(It.IsAny<Feedback>()));
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.UpdateOrAddFeedbacksByAdmin(request);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetLastAddedFeedback());
            _mokstoreFeedbackAdapter.Verify(a => a.SaveFeedbackQuestion(It.IsAny<Feedback>()));
        }

        [Test]
        public void UpdateOrAddFeedbacksByAdminTestForIdIsNotZero()
        {
            //arrange
            var request = new List<Feedback>
            {
                new Feedback { id = 1 ,assigned = "yes"}
            };
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetLastAddedFeedback()).Returns(1);
            _mokstoreFeedbackAdapter.Setup(a => a.UpdateFeedbackAssigned(It.IsAny<Feedback>()));
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.UpdateOrAddFeedbacksByAdmin(request);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetLastAddedFeedback());
            _mokstoreFeedbackAdapter.Verify(a => a.UpdateFeedbackAssigned(It.IsAny<Feedback>()));
        }

        [Test]
        public void UpdateFeedbackStatusTest()
        {
            //arrange
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.UpdateFeedbackStatus(1);

            //assert
            _mokstoreFeedbackAdapter.Verify(a => a.UpdateFeedbackStatus(It.IsAny<long>()));
        }

        [Test]
        public void SaveBlindSpotNotificationTest()
        {
            //arrange
            var request = new BlindSpotNotification
            {
                coworkerid = new List<string>
                {
                   "1" , "2", "3"
                },
                userid = ""
            };
            var response = new List<Feedback>
            {
                new Feedback { }
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetLastAddedFeedback()).Returns(1);
            _mokstoreFeedbackAdapter.Setup(a => a.SaveFeedbackQuestion(It.IsAny<Feedback>()));
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.SaveBlindSpotNotification(request);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetLastAddedFeedback());
            _mokstoreFeedbackAdapter.Verify(a => a.SaveFeedbackQuestion(It.IsAny<Feedback>()));
        }

        [Test]
        public void GetNotificationListForUserTestForCountLessThantotalOfCountAndStart()
        {
            //arrange
            var request = new BlindSpotNotification
            {
                coworkerid = new List<string>
                {
                   "1" , "2", "3"
                },
                userid = ""
            };
            var response = new List<Feedback>
            {
                new Feedback {id = 1 }
            };
            var feedbackreplyresponse = new FeedbackReply
            {
                feedback = "feedback"
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>())).Returns(response);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedbackRequestsByUser(It.IsAny<string>())).Returns(response);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedbackReplyForQuestion(It.IsAny<long>())).Returns(feedbackreplyresponse);
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            feedbackAdapter.GetNotificationListForUser("1",0,2);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>()));
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedbackRequestsByUser(It.IsAny<string>()));
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedbackReplyForQuestion(It.IsAny<long>()));
        }

        [Test]
        public void GetNotificationListForUserTestForCountNotLessThantotalOfCountAndStart()
        {
            //arrange
            var request = new BlindSpotNotification
            {
                coworkerid = new List<string>
                {
                   "1" , "2", "3"
                },
                userid = ""
            };
            var response = new List<Feedback>
            {
                new Feedback {id = 1 }
            };
            var feedbackreplyresponse = new FeedbackReply
            {
                feedback = "feedback"
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>())).Returns(response);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedbackRequestsByUser(It.IsAny<string>())).Returns(response);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedbackReplyForQuestion(It.IsAny<long>())).Returns(feedbackreplyresponse);
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            var result = feedbackAdapter.GetNotificationListForUser("1", 0, 1);

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>()));
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedbackRequestsByUser(It.IsAny<string>()));
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedbackReplyForQuestion(It.IsAny<long>()));
            Assert.IsInstanceOf<List<Feedback>>(result);
        }

        [Test]
        public void GetAdminCommentsTest()
        {
            //arrange
            var response = new List<Feedback>();
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>())).Returns(response);
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            var result = feedbackAdapter.GetAdminComments("1");

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>()));
            Assert.IsInstanceOf<List<Feedback>>(result);
        }

        [Test]
        public void GetNotificationCountTest()
        {
            //arrange
            var request = new BlindSpotNotification
            {
                coworkerid = new List<string>
                {
                   "1" , "2", "3"
                },
                userid = ""
            };
            var response = new List<Feedback>
            {
                new Feedback {id = 1 }
            };
            var feedbackreplyresponse = new FeedbackReply
            {
                feedback = "feedback"
            };
            var settings = new MongoDbSettings { FeedbackCollection = "", FeedbackReplyCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>())).Returns(response);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedbackRequestsByUser(It.IsAny<string>())).Returns(response);
            _mokgetFeedbackDetailsAdapter.Setup(a => a.GetFeedbackReplyForQuestion(It.IsAny<long>())).Returns(feedbackreplyresponse);
            //act
            var feedbackAdapter = new FeedbackBusinessLogics(_mokstoreFeedbackAdapter.Object, _mokgetFeedbackDetailsAdapter.Object);
            var result = feedbackAdapter.GetNotificationCount("1");

            //assert
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedBacksAssignedToUser(It.IsAny<string>()));
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedbackRequestsByUser(It.IsAny<string>()));
            _mokgetFeedbackDetailsAdapter.Verify(a => a.GetFeedbackReplyForQuestion(It.IsAny<long>()));
            Assert.IsInstanceOf<long>(result);
        }
    }
}
