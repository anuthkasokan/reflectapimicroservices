using CognizantReflect.Api.Adapters;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
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
    public class ProductivityZoneQuizAdapterTests
    {
        private Mock<IMongoClientHelper<ProductivityZoneQuiz>> _mokproductivityZoneQuiz;
        private Mock<IMongoClientHelper<ProductivityZoneQuizAttempts>> _mokproductivityZoneQuizAttempt;
        private Mock<IOptions<MongoDbSettings>> _settings;
        private ProductivityZoneQuizAdapter _productivityZoneQuizAdapter;

        [SetUp]
        public void SetUp()
        {
            _settings = new Mock<IOptions<MongoDbSettings>>();
            _mokproductivityZoneQuiz = new Mock<IMongoClientHelper<ProductivityZoneQuiz>>();
            _mokproductivityZoneQuizAttempt = new Mock<IMongoClientHelper<ProductivityZoneQuizAttempts>>();
            var settings = new MongoDbSettings { ProductivityZoneQuizCollection = "", ProductivityZoneQuizAttemptsCollection = "" };
            _settings.Setup(s => s.Value).Returns(settings);
        }

        [Test]
        public void GetProductivityZoneQuizzesTest()
        {
            var response = new List<BsonDocument>
            {
                new BsonDocument {  }
            };
            _mokproductivityZoneQuiz.Setup(a => a.GetTotalRecords(It.IsAny<string>())).Returns(response);

            _productivityZoneQuizAdapter = new ProductivityZoneQuizAdapter(_mokproductivityZoneQuiz.Object, _mokproductivityZoneQuizAttempt.Object, _settings.Object);

            var result = _productivityZoneQuizAdapter.GetProductivityZoneQuizzes();
            Assert.IsInstanceOf<List<ProductivityZoneQuiz>>(result);
        }

        [Test]
        public void GetLatestIdTest()
        {
            var response = new ProductivityZoneQuizAttempts();
            _mokproductivityZoneQuizAttempt.Setup(a => a.GetLatestId(It.IsAny<string>(),It.IsAny<SortDefinition<ProductivityZoneQuizAttempts>>())).Returns(response);

            _productivityZoneQuizAdapter = new ProductivityZoneQuizAdapter(_mokproductivityZoneQuiz.Object, _mokproductivityZoneQuizAttempt.Object, _settings.Object);

            var result = _productivityZoneQuizAdapter.GetLatestId();
            Assert.IsInstanceOf<ProductivityZoneQuizAttempts> (result);
        }

        [Test]
        public void InsertProductivityZoneQuizAttemptsTest()
        {
            var request = new List<ProductivityZoneQuizAttempts>();
            _mokproductivityZoneQuizAttempt.Setup(a => a.InsertAll( It.IsAny<List<ProductivityZoneQuizAttempts>>(), It.IsAny<string>()));

            _productivityZoneQuizAdapter = new ProductivityZoneQuizAdapter(_mokproductivityZoneQuiz.Object, _mokproductivityZoneQuizAttempt.Object, _settings.Object);

            var result = _productivityZoneQuizAdapter.InsertProductivityZoneQuizAttempts(request);
            _mokproductivityZoneQuizAttempt.Verify(a => a.InsertAll( It.IsAny<List<ProductivityZoneQuizAttempts>>(), It.IsAny<string>()));
        }

        [Test]
        public void InsertProductivityZoneQuizTest()
        {
            var request = new ProductivityZoneQuiz();
            _mokproductivityZoneQuiz.Setup(a => a.InsertOne(It.IsAny<ProductivityZoneQuiz>(), It.IsAny<string>()));

            _productivityZoneQuizAdapter = new ProductivityZoneQuizAdapter(_mokproductivityZoneQuiz.Object, _mokproductivityZoneQuizAttempt.Object, _settings.Object);

            var result = _productivityZoneQuizAdapter.InsertProductivityZoneQuiz(request);
            _mokproductivityZoneQuiz.Verify(a => a.InsertOne(It.IsAny<ProductivityZoneQuiz>(), It.IsAny<string>()));
        }

        [Test]
        public void GetLatestAttemptByUserTest()
        {
            _mokproductivityZoneQuizAttempt.Setup(a => a.GetData(It.IsAny<FilterDefinition<ProductivityZoneQuizAttempts>>(), It.IsAny<string>()));

            _productivityZoneQuizAdapter = new ProductivityZoneQuizAdapter(_mokproductivityZoneQuiz.Object, _mokproductivityZoneQuizAttempt.Object, _settings.Object);

            var result = _productivityZoneQuizAdapter.GetLatestAttemptByUser("");
            _mokproductivityZoneQuizAttempt.Verify(a => a.GetData(It.IsAny<FilterDefinition<ProductivityZoneQuizAttempts>>(), It.IsAny<string>()));
        }
    }
}
