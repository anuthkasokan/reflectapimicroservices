using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.ProductivityZoneQuiz;
using Microsoft.AspNetCore.Mvc;


namespace CognizantReflect.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductivityZoneQuizController : ControllerBase
    {
        private readonly IProductivityZoneQuizBusinessLogic _productivityZoneQuizBusinessLogic;

        public ProductivityZoneQuizController(IProductivityZoneQuizBusinessLogic productivityZoneQuizBusinessLogic)
        {
            _productivityZoneQuizBusinessLogic = productivityZoneQuizBusinessLogic;
        }

        // GET: <ProductivityZoneQuizController>
        [HttpGet("getProductivityZoneQuiz",Name = "getProductivityZoneQuiz")]
        public List<ProductivityZoneQuiz> GetProductivityZoneQuiz()
        {
            return _productivityZoneQuizBusinessLogic.GetProductivityZoneQuizzes();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveProductivityZoneQuiz([FromBody] ProductivityZoneQuiz productivityZoneQuiz)
        {
            _productivityZoneQuizBusinessLogic.InsertProductivityZoneQuizzes(productivityZoneQuiz);
            return Ok();
        }

        // POST <MakingTimeForMeQuizController>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveProductivityZoneQuizAttempts([FromBody] List<ProductivityZoneQuizAttempts> productivityZoneQuizAttempts)
        {
            _productivityZoneQuizBusinessLogic.InsertProductivityZoneQuizAttempts(productivityZoneQuizAttempts);
            return Ok();
        }
    }
}
