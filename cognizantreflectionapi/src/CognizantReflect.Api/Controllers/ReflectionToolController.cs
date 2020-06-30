using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.ReflectionToolQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CognizantReflect.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReflectionToolController : ControllerBase
    {
        private readonly IReflectionToolBusinessLogics _reflectionToolBusinessLogics;

        public ReflectionToolController(IReflectionToolBusinessLogics reflectionToolBusinessLogics)
        {
            _reflectionToolBusinessLogics = reflectionToolBusinessLogics;
        }

        // GET: api/ReflectionTool
        [HttpGet("getReflectionToolQuestions", Name = "GetReflectionToolQuestions")]
        public  List<ReflectionTool> GetReflectionToolQuestions()
        {
            return _reflectionToolBusinessLogics.GetReflectionToolQuestions();
        }


        // POST: api/ReflectionTool
        [HttpPost("saveReflectionToolQuizAttempt",Name = "SaveReflectionToolQuizAttempt")]
        public void SaveReflectionToolQuizAttempt(List<ReflectionToolQuizAttempt> reflectionToolQuizAttempt)
        {
            _reflectionToolBusinessLogics.SaveReflectionToolResponse(reflectionToolQuizAttempt);
        }

    }
}
