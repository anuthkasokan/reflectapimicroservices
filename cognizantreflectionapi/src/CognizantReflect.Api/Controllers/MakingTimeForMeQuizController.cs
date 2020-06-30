using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.MakingTimeForMeQuiz;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace CognizantReflect.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MakingTimeForMeQuizController : ControllerBase
    {
        private readonly IMakingTimeForMeQuizBusinessLogic _makingTimeForMeQuizBusinessLogic;
        public MakingTimeForMeQuizController(IMakingTimeForMeQuizBusinessLogic makingTimeForMeQuizBusinessLogic)
        {
            _makingTimeForMeQuizBusinessLogic = makingTimeForMeQuizBusinessLogic;
        }
        // POST: <MakingTimeForMeQuizController>
        [HttpGet("getMakingTimeForMeQuiz", Name = "getMakingTimeForMeQuiz")]
        public List<MakingTimeForMeQuiz> GetMakingTimeForMeQuiz()
        {
            return _makingTimeForMeQuizBusinessLogic.GetMakingTimeForMeQuizzes();
        }

        // POST: <MakingTimeForMeQuizController>
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveMakingTimeForMeQuiz([FromBody] MakingTimeForMeQuiz makingTimeForMeQuiz)
        {
            return Ok(_makingTimeForMeQuizBusinessLogic.InsertMakingTimeForMeQuizzes(makingTimeForMeQuiz));
        }

        // POST <MakingTimeForMeQuizController>
        [HttpPost("saveMakingTimeForMeQuizAttempts",Name = "SaveMakingTimeForMeQuizAttempts")]
        public IActionResult saveMakingTimeForMeQuizAttempts([FromBody] List<MakingTimeForMeQuizAttempts> makingTimeForMeQuizAttempts)
        {
            return Ok(_makingTimeForMeQuizBusinessLogic.InsertMakingTimeForMeQuizAttempts(makingTimeForMeQuizAttempts));
        }

        // DELETE api/<MakingTimeForMeQuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
