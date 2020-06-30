using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.Reports;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using CognizantReflect.Api.Models;
using System.Diagnostics;

namespace CognizantReflect.Api.Controllers
{
#if !DEBUG
    [Authorize]
#endif
    [Route("[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsBusinessLogic _reportsBusinessLogic;
        public ReportsController(IReportsBusinessLogic reportsBusinessLogic)
        {
            _reportsBusinessLogic = reportsBusinessLogic;
        }
        // GET: <ReportsController>
        [HttpGet("getReportData/{userId}/{quizId}/{attempt}",Name = "getReportData/{userId}/{quizId}/{attempt}")]
        public List<QuizAttempts> getReportData(string userId, int quizId, int attempt)
        {
            return _reportsBusinessLogic.GetQuizAttempts(userId, quizId, attempt);
        }

        [HttpGet("getQuizzes", Name = "getQuizzes")]
        public List<QuizDetails> getQuizzes()
        {
            return _reportsBusinessLogic.GetQuizzes();
        }

        // GET api/<ReportsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReportsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReportsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
