using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.ContinuousLearningAssessmentQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CognizantReflect.Api.Controllers
{
#if !DEBUG
    [Authorize]
#endif
    [Route("[controller]")]
    [ApiController]
    public class ContinuousLearningAssessmentQuizController : ControllerBase
    {
        private readonly IContinuousLearningBusinessLogic _continuousLearningBusinessLogic;
        public ContinuousLearningAssessmentQuizController(IContinuousLearningBusinessLogic continuousLearningBusinessLogic)
        {
            _continuousLearningBusinessLogic = continuousLearningBusinessLogic;
        }
        // GET: <ContinuousLearningAssessmentQuizController>
        [HttpGet("getContinuousLearningQuiz", Name = "getContinuousLearningQuiz")]
        public List<ContinuousLearningAssessmentQuiz> GetContinuousLearningQuiz()
        {
            return _continuousLearningBusinessLogic.GetContinuousLearningAssessmentQuizzes();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult saveContinuousLearningQuizAttempts([FromBody] List<ContinuousLearningAssessmentQuizAttempts> continuousLearningQuizAttempts)
        {
            return Ok(_continuousLearningBusinessLogic.InsertContinuousLearningQuizResponse(continuousLearningQuizAttempts));
        }

        // GET api/<ContinuousLearningAssessmentQuizController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContinuousLearningAssessmentQuizController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContinuousLearningAssessmentQuizController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContinuousLearningAssessmentQuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
