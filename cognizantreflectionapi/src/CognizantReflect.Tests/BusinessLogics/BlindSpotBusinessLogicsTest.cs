using System;
using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.BlindSpotQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class BlindSpotBusinessLogicsTest
    {
        private readonly Mock<IBlindSpotAdapter> _blindSpotAdapter = new Mock<IBlindSpotAdapter>();
        private readonly Mock<IFeedbackAdapter> _feedbackAdapter = new Mock<IFeedbackAdapter>();
        private BlindSpotBusinessLogics _blindSpotBusinessLogics;

        [SetUp]
        public void SetUp()
        {
            _blindSpotBusinessLogics = new BlindSpotBusinessLogics(_blindSpotAdapter.Object, _feedbackAdapter.Object);
        }
        [Test]
        public void BlindSpotBusinessLogic_Instance()
        {
            Assert.IsInstanceOf<BlindSpotBusinessLogics>(_blindSpotBusinessLogics);
        }

        [Test]
        public void GetBlindSpotQuizQuestions_BlindSpotQuestionList()
        {
            _blindSpotAdapter.Setup(x => x.GetBlindSpotQuizQuestions()).Returns(new BlindSpotQuizQuestions
            {
                id = 1, adjectives = new string[] {"kind"}
            });

            var assert = _blindSpotBusinessLogics.GetBlindSpotQuizQuestions();
            Assert.AreEqual(1, assert.id);
        }

        [Test]
        public void SaveBlindSpotUserResponse_WithAttempts_ReturnsVoid()
        {
            BlindSpotQuizAttempts attempt = new BlindSpotQuizAttempts
            {
                id = 1,selectedcoWorkers = new string[]{"Anuth"},userid = "Hamid"
            };
            _blindSpotAdapter.Setup(x => x.GetLastInsertedAttemptId()).Returns(1);
            _blindSpotAdapter.Setup(x => x.GetLatestAttemptByUser(It.IsAny<string>())).Returns(

                new BlindSpotQuizAttempts
                {
                    id = 1,attemptcount = 1
                });
            _blindSpotAdapter.Setup(x => x.GetLastInsertedCoWorkerReply()).Returns(1);
            Assert.DoesNotThrow(() => _blindSpotBusinessLogics.SaveBlindSpotUserResponse(attempt));
        }

        [Test]
        public void SaveBlindSpotCoWorkerReply_ReturnsVoid()
        {
            BlindSpotCoWorkerReply reply = new BlindSpotCoWorkerReply();

            Assert.DoesNotThrow(() => _blindSpotBusinessLogics.SaveBlindSpotCoWorkerReply(reply));
        }

        [Test]
        public void UpdateBlindSpotCoWorkerReply_ReturnsVoid()
        {
            BlindSpotCoWorkerReply reply = new BlindSpotCoWorkerReply();
            Assert.DoesNotThrow(() => _blindSpotBusinessLogics.UpdateBlindSpotCoWorkerReply(reply));
        }

        [Test]
        public void ShowBlindSpotQuizResult_WithUser_ReturnsQuizResult()
        {
            string user = "Hamid";
            _blindSpotAdapter.Setup(x => x.GetBlindSpotQuizQuestions()).Returns(new BlindSpotQuizQuestions
            {
                id = 1, adjectives = new[] {"kind", "positive", "caring", "helpful"}
            });
            _blindSpotAdapter.Setup(x => x.GetLatestAttemptByUser(It.IsAny<string>())).Returns(
            new BlindSpotQuizAttempts
            {
                attemptcount = 1,id=1,selectedadjectives = new []{"kind","positive"}
            }
                );
            _blindSpotAdapter.Setup(x => x.GetCoWorkerResponsesByAttempt(It.IsAny<long>())).Returns(
                new List<BlindSpotCoWorkerReply>
                {
                    new BlindSpotCoWorkerReply
                    {
                        attemptid = 1,id=1,selectedadjectives = new string[]{"positive","caring"}
                    }
                });
            var assert = _blindSpotBusinessLogics.ShowBlindSpotQuizResult(user);

            Assert.AreEqual(new string[] { "positive" },assert.arena);
        }

        [Test]
        public void GetBlindSpotCoWorkerRequest_WithUser_ReturnsCWReply()
        {
            _blindSpotAdapter.Setup(x => x.GetDataForCoWorkerReply(It.IsAny<string>())).Returns(
            new List<BlindSpotCoWorkerReply>
            {
                new BlindSpotCoWorkerReply
                {
                    attemptid = 1,selectedadjectives = new string[]{"kind"}
                }
            }
                );
            var assert = _blindSpotBusinessLogics.GetBlindSpotCoWorkerRequest("hamid");
            Assert.AreEqual(1,assert[0].attemptid);
        }
    }
}