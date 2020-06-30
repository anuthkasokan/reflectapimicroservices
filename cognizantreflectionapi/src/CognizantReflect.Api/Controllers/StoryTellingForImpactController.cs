using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.StoryTellingForImpactQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CognizantReflect.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class StoryTellingForImpactController : ControllerBase
    {
        private readonly IStoryTellingForImpactBusinessLogic _storyTellingForImpactBusinessLogic;

        public StoryTellingForImpactController(IStoryTellingForImpactBusinessLogic storyTellingForImpactBusinessLogic)
        {
            _storyTellingForImpactBusinessLogic = storyTellingForImpactBusinessLogic;
        }

        [HttpGet("getStoryTellingImpactQuizzes",Name = "getStoryTellingImpactQuizzes")]
        public List<StoryTellingForImpactQuiz> GetStorytellingQuiz()
        {
            return _storyTellingForImpactBusinessLogic.GetStoryTellingForImpactQuizzes();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult saveStoryTellingQuizAttempts([FromBody] List<StoryTellingForImpactQuizAttempts> storyTellingForImpactQuiz)
        {
            return Ok(_storyTellingForImpactBusinessLogic.InsertStoryTellingForImpactQuizzAttempts(storyTellingForImpactQuiz));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult saveStoryTellingQuiz([FromBody] StoryTellingForImpactQuiz storyTellingForImpactQuiz)
        {
            return Ok(_storyTellingForImpactBusinessLogic.InsertStoryTellingForImpactQuizzes(storyTellingForImpactQuiz));
        }

        // DELETE api/<StoryTellingForImpactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
