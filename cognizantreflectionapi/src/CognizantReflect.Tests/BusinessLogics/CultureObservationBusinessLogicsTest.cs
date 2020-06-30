using System.Collections.Generic;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.BusinessLogics;
using CognizantReflect.Api.Controllers;
using CognizantReflect.Api.Models.CultureObservationToolQuiz;
using Moq;
using NUnit.Framework;

namespace CognizantReflect.Tests.BusinessLogics
{
    [TestFixture]
    public class CultureObservationBusinessLogicsTest
    {
        private readonly Mock<ICulturalObservationAdapter> _cultureObservationAdapter = new Mock<ICulturalObservationAdapter>();
        private CulturalObservationBusinessLogic _culturalObservationBusinessLogic;

        [SetUp]
        public void SetUp()
        {
            _culturalObservationBusinessLogic =new CulturalObservationBusinessLogic(_cultureObservationAdapter.Object);
        }

        [Test]
        public void CultureObservationBusinessLogics_Instance()
        {
            Assert.IsInstanceOf<CulturalObservationBusinessLogic>(_culturalObservationBusinessLogic);
        }

        [Test]
        public void GetCulturalObservationQuiz_ReturnsQuestionList()
        {
            _cultureObservationAdapter.Setup(x => x.GetCutlturalObservationQuiz()).Returns(
            new List<CultureObservationToolQuiz>
            {
                new CultureObservationToolQuiz
                {
                    id=1
                }
            }
                );

            var actual = _culturalObservationBusinessLogic.GetCulturalObservationQuiz();
            Assert.AreEqual(1,actual[0].id);
        }
    }
}