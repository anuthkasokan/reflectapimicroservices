using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CognizantReflect.Tests.Controller
{
    class SettingsControllerTest
    {
        private readonly Mock<ISettingsBusinessLogics> _settingsBusinessLogics = new Mock<ISettingsBusinessLogics>();
        private readonly Mock<ILogger<SettingsController>> _logs = new Mock<ILogger<SettingsController>>();

        [Test]
        [Description("CognizantReflect Api SettingsController instance is getting created")]
        public void SettingsController()
        {
            //Act
            var actual = new SettingsController(_logs.Object,_settingsBusinessLogics.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<SettingsController>(actual);

        }
    }
}
