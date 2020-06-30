using System.Collections.Generic;
using System.Linq;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.CuriosityQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CognizantReflect.Api.Controllers
{
#if !DEBUG
    [Authorize]
#endif
    [Route("[controller]")]
    [ApiController]
    public class CuriousQuizController : ControllerBase
    {
        private readonly ICuriousQuizBusinessLogic _curiosityQuizBusinessLogic;

        public CuriousQuizController(ICuriousQuizBusinessLogic curiosityQuizBusinessLogic)
        {
            _curiosityQuizBusinessLogic = curiosityQuizBusinessLogic;
        }
        // GET: api/<CuriousQuizController>
        [HttpGet("getCuriousQuiz",Name ="getCuriousQuiz")]
        public List<CuriousQuiz> GetCuriousQuiz()
        {
            return _curiosityQuizBusinessLogic.GetCuriousQuizzes();
        }

        // POST /<CuriousQuizController>/InsertCuriousquiz
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveCuriosQuiz([FromBody] CuriousQuiz curiousQuiz)
        {
            return Ok(_curiosityQuizBusinessLogic.InsertCuriousQuiz(curiousQuiz));
        }

        // PUT /<CuriousQuizController>/InsertCuriousquizAttempts
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveCuriosQuizAttempts([FromBody] List<CuriousQuizAttempts> curiousQuizAttempts)
        {
            return Ok(_curiosityQuizBusinessLogic.InsertCuriousQuizResponse(curiousQuizAttempts));
        }

        // DELETE api/<CuriosityQuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
