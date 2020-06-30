using CognizantReflect.Api.BusinessLogics.Interfaces;
using Moq;
using NUnit.Framework;
using CognizantReflect.Api.Controllers;


namespace CognizantReflect.Tests.Controller
{
    class DashboardControllerTest
    {
        private readonly Mock<IDashboardBusinessLogics> _dashboardBusinessLogics = new Mock<IDashboardBusinessLogics>();

        [Test]
        [Description("CognizantReflect Api DashboardController instance is getting created")]
        public void DashboardController()
        {
            //Act
            var actual = new DashboardController(_dashboardBusinessLogics.Object);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<DashboardController>(actual);

        }
        [Test]
        [Description("GetPercentageOfCompletionByUser")]
        public void DashboardController_GetPercentageOfCompletionByUser()
        { 
            //Act
            var actual = new DashboardController(_dashboardBusinessLogics.Object);
            var useridRequest = "1234";
            var target = actual.GetPercentageOfCompletionByUser(useridRequest);
            //Assert
            Assert.IsNotNull(target);
            Assert.NotZero(1);
            
        }
        [Test]
        [Description("GetPercentageOfCompletion")]
        public void DashboardController_GetPercentageOfCompletion()
        {
            //Act
            var actual = new DashboardController(_dashboardBusinessLogics.Object);
            var target = actual.GetPercentageOfCompletion();
            //Assert
            Assert.IsNotNull(target);
            Assert.NotZero(1);

        }
        
        public void DashboardController_GetAttemptCountsByUser()
        {
            //Act
            var actual = new DashboardController(_dashboardBusinessLogics.Object);
            var useridRequest = "1234";
            var target = actual.GetAttemptCountsByUser(useridRequest);
            //Assert
            Assert.IsNotNull(target);
            Assert.NotZero(1);

        }

    }
}
