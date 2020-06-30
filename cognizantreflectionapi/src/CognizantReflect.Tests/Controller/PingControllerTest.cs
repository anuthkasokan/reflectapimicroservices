using NUnit.Framework;
using CognizantReflect.Api.Controllers;

namespace CognizantReflect.Tests.Controller
{
    public class PingControllerTest
    {
        public void PingTest()
        {
            const string expected = "Pinged successfully!";

            //Act
            var message = new PingController().Get();

            //Assert
            Assert.AreEqual(expected,message);

        }
        
    }
}
