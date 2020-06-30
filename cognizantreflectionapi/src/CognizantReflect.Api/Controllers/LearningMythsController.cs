using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.LearningMythsQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CognizantReflect.Api.Controllers
{
#if !DEBUG
    [Authorize]
#endif
    [Route("[controller]")]
    [ApiController]
    public class LearningMythsController : ControllerBase
    {
        private readonly ILearningMythsBusinessLogic _learningMythsBusinessLogic;

        public LearningMythsController(ILearningMythsBusinessLogic learningMythsBusinessLogic)
        {
            _learningMythsBusinessLogic = learningMythsBusinessLogic;
        }

        // GET: <LearningMythsController>
        [HttpGet("getLearningMythsQuiz",Name ="getLearningMythsQuiz")]
        public List<LearningMythsQuiz> Get()
        {
            return _learningMythsBusinessLogic.GetLearningMythsQuizzes();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult saveLearningMythsQuizAttempts([FromBody] List<LearningMythsQuizAttempts> learningMythsQuizAttempts)
        {
            return Ok(_learningMythsBusinessLogic.InsertLearningMythsQuizResponse(learningMythsQuizAttempts));
        }

        // GET <LearningMythsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LearningMythsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LearningMythsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LearningMythsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
