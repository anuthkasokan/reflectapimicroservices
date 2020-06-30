using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class ProductivityZoneBusinessLogicsTest
    {
        private Mock<IProductivityZoneQuizAdapter> _productivityZoneQuizAdapter = new Mock<IProductivityZoneQuizAdapter>();
        private ProductivityZoneQuizBusinessLogic _productivityZoneQuizBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _productivityZoneQuizBusinessLogic = new ProductivityZoneQuizBusinessLogic(_productivityZoneQuizAdapter.Object);
        }

        [Test]
        public void ProductivityZoneQuizBL_Instance()
        {
            Assert.IsInstanceOf<ProductivityZoneQuizBusinessLogic>(_productivityZoneQuizBusinessLogic);
        }

        [Test]
        public void GetProductivityZoneQuizzes_ReturnsQuestionList()
        {
            _productivityZoneQuizAdapter.Setup(x => x.GetProductivityZoneQuizzes()).Returns(
                new List<ProductivityZoneQuiz>
                {
                    new ProductivityZoneQuiz()
                    {
                        id=1
                    }
                }
            );
            var actual = _productivityZoneQuizBusinessLogic.GetProductivityZoneQuizzes();
            Assert.AreEqual(1, actual[0].id);
        }

        [Test]
        public void InsertProductivityZoneQuiz_ReturnsInt()
        {
            Assert.DoesNotThrow(() => _productivityZoneQuizBusinessLogic.InsertProductivityZoneQuizzes(It.IsAny<ProductivityZoneQuiz>()));
        }

        [Test]
        public void InsertProductivityZoneQuizResponse_WithAttempt_ReturnsInt()
        {
            List<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts = new List<ProductivityZoneQuizAttempts>
            {
                new ProductivityZoneQuizAttempts()
            };
            _productivityZoneQuizAdapter.Setup(x => x.GetLatestId()).Returns(
                new ProductivityZoneQuizAttempts()
                {
                    id = 1,
                    attemptcount = 1
                });
            Assert.DoesNotThrow(() => _productivityZoneQuizBusinessLogic.InsertProductivityZoneQuizAttempts(productivityZoneQuizAttempts));
        }
    }
}