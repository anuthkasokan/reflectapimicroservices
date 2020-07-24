using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantReflect.Tests.Adapters
{
    [TestFixture]
    public class ReflectionToolAdapterTests
    {
        private Mock<IMongoClientHelper<ReflectionTool>> _mokreflectionToolQuiz;
        private Mock<IMongoClientHelper<ReflectionToolQuizAttempt>> _mokreflectionToolQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private ReflectionToolAdapter _reflectionToolQuizAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokreflectionToolQuiz = new Mock<IMongoClientHelper<ReflectionTool>>();
            _mokreflectionToolQuizAttempt = new Mock<IMongoClientHelper<ReflectionToolQuizAttempt>>();
            var settings = new MongoDbSettings { ProductivityZoneQuizCollection = "", ProductivityZoneQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetReflectionToolQuestionsTest()
        {
            var response = new List<ReflectionTool>();
            _mokreflectionToolQuiz.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionTool>>(),It.IsAny<string>())).Returns(response);

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            var result = _reflectionToolQuizAdapter.GetReflectionToolQuestions();
            Assert.IsInstanceOf<List<ReflectionTool>>(result);
        }

        [Test]
        public void SaveReflectionToolQuizAttemptTest()
        {
            var request = new List<ReflectionToolQuizAttempt>();
            _mokreflectionToolQuizAttempt.Setup(a => a.InsertAll(It.IsAny<List<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            _reflectionToolQuizAdapter.SaveReflectionToolQuizAttempt(request);
            _mokreflectionToolQuizAttempt.Verify(a => a.InsertAll(It.IsAny<List<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLastInsertedReflectionQuizIdTest()
        {
            var request = new List<ReflectionToolQuizAttempt>();
            _mokreflectionToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            _reflectionToolQuizAdapter.GetLastInsertedReflectionQuizId();
            _mokreflectionToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetAttemptCountForReflectionToolQuizTest()
        {
            var response = new List<ReflectionToolQuizAttempt>
            {
                new ReflectionToolQuizAttempt { attemptcount = 1 }
            };
            _mokreflectionToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>())).Returns(response);

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            _reflectionToolQuizAdapter.GetAttemptCountForReflectionToolQuiz("");
            _mokreflectionToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetReflectionToolAttemptsTest()
        {
            var request = new List<ReflectionToolQuizAttempt>();
            _mokreflectionToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            _reflectionToolQuizAdapter.GetReflectionToolAttempts("",1);
            _mokreflectionToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            var request = new List<ReflectionToolQuizAttempt>();
            _mokreflectionToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            _reflectionToolQuizAdapter.GetLatestAttemptByUser("");
            _mokreflectionToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestAttemptIdTest()
        {
            var request = new List<ReflectionToolQuizAttempt>();
            _mokreflectionToolQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));

            _reflectionToolQuizAdapter = new ReflectionToolAdapter(_mokreflectionToolQuiz.Object, _mokreflectionToolQuizAttempt.Object, _settings.Object);

            _reflectionToolQuizAdapter.GetLatestAttemptId();
            _mokreflectionToolQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<ReflectionToolQuizAttempt>>(), It.IsAny<string>()));
        }
    }
}
