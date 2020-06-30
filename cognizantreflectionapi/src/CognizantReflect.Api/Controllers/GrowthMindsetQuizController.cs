using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.GrowthMindsetQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CognizantReflect.Api.Controllers
{
#if !DEBUG
    [Authorize]
#endif
    [Route("[controller]")]
    [ApiController]
    public class GrowthMindsetQuizController : ControllerBase
    {
        private readonly IGrowthMindsetQuizBusinessLogic _growthMindsetQuizBusinessLogic;
        public GrowthMindsetQuizController(IGrowthMindsetQuizBusinessLogic growthMindsetQuizBusinessLogic)
        {
            _growthMindsetQuizBusinessLogic = growthMindsetQuizBusinessLogic;
        }
        // GET: <GrowthMindSetQuizController>
        [HttpGet("getGrowthMindsetQuiz", Name = "getGrowthMindsetQuiz")]
        public List<GrowthMindsetQuiz> GetCuriousQuiz()
        {
            return _growthMindsetQuizBusinessLogic.GetGrowthMindsetQuizzes();
        }

        // POST <GrowthMindSetQuizController>
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveGrowthMindsetQuiz([FromBody] GrowthMindsetQuiz growthMindsetQuiz)
        {
            return Ok(_growthMindsetQuizBusinessLogic.InsertGrowthMindsetQuiz(growthMindsetQuiz));
        }

        // POST api/<GrowthMindSetQuizController>
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveGrowthMindsetQuizAttempts([FromBody] List<GrowthMindsetQuizAttempts> growthMindsetQuizAttempts)
        {
            return Ok(_growthMindsetQuizBusinessLogic.InsertGrowthMindsetQuizResponse(growthMindsetQuizAttempts));
        }

        // DELETE api/<GrowthMindSetQuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
