using System.Collections.Generic;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using CognizantReflect.Api.Models.Dashboard;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CognizantReflect.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardBusinessLogics _dashboardBusinessLogics;

        public DashboardController(IDashboardBusinessLogics dashboardBusinessLogics)
        {
            _dashboardBusinessLogics = dashboardBusinessLogics;
        }

        // GET: api/Dashboard
        [HttpGet("getPercentageOfCompletion/{userid}", Name = "GetPercentageOfCompletionByUser")]
        public int GetPercentageOfCompletionByUser(string userid)
        {
            return _dashboardBusinessLogics.GetPercentageOfCompletionByUser(userid);
        }

        [HttpGet("getPercentageOfCompletion", Name = "GetPercentageOfCompletion")]
        public int GetPercentageOfCompletion()
        {
            return _dashboardBusinessLogics.GetOverallPercentageOfQuizCompletion();
        }

        // GET: api/Dashboard/5
        [HttpGet("getScoreChartDetails/{userid}", Name = "GetScoreChartDetailsByUser")]
        public int[][] GetScoreChartDetailsByUser(string userid)
        {

            return _dashboardBusinessLogics.GetDetailsForScoreGraphChart(userid);
        }

        [HttpGet("getScoreChartDetails", Name = "GetScoreChartDetails")]
        public int[][] GetScoreChartDetails()
        {

            return _dashboardBusinessLogics.GetDetailsForScoreGraphChart();
        }

        [HttpGet("getAttemptCount/{userid}", Name = "GetAttemptCountByUser")]
        public QuizAttemptCounts GetAttemptCountsByUser(string userid)
        {
            return _dashboardBusinessLogics.GetQuizAttemptCountsByUser(userid);
        }

        [HttpGet("getAttemptCount",Name = "GetTotalAttemptCount")]
        public QuizAttemptCounts GetTotalAttemptCount()
        {
            return _dashboardBusinessLogics.GetTotalQuizAttemptCounts();
        }

        [HttpGet("getAttemptHistoryDetails/{userid}", Name = "GetAttemptHistoryDoughnutDetailsByUser")]
        public int[] GetAttemptHistoryDoughnutDetailsByUser(string userid)
        {
            return _dashboardBusinessLogics.GetQuizAttemptHistoryDetailsByUser(userid);

        }

        [HttpGet("getAttemptHistoryDetails", Name = "GetAttemptHistoryDoughnutDetails")]
        public int[] GetAttemptHistoryDoughnutDetails()
        {
            return _dashboardBusinessLogics.GetQuizAttemptHistoryDetails();

        }

        [HttpGet("getContinuousLearningDetails/{userid}", Name = "GetContinuousLearningCountsDetailsByUser")]
        public int[] GetContinuousLearningDetailsByUser(string userid)
        {
            return _dashboardBusinessLogics.GetContinuousLearningDetails(userid);

        }

        [HttpGet("getContinuousLearningDetails", Name = "GetContinuousLearningCountsDetails")]
        public int[] GetContinuousLearningDetails()
        {
            return _dashboardBusinessLogics.GetContinuousLearningDetails("");

        }

        [HttpGet("getCuriosityAnswers/{userid}", Name = "GetCuriosityQuizAnswersByUser")]
        public List<QuizResultAndTimes> GetCuriosityQuizAnswersByUser(string userid)
        {
            return _dashboardBusinessLogics.GetCuriosityResultAndTimes(userid);
        }

        [HttpGet("getCuriosityAnswers", Name = "GetCuriosityQuizAnswers")]
        public List<QuizResultAndTimes> GetCuriosityQuizAnswers()
        {
            return _dashboardBusinessLogics.GetCuriosityResultAndTimes();
        }

        [HttpGet("getGrowthMindset/{userid}", Name = "GetGrowthMindsetQuizAnswersByUser")]
        public List<QuizResultAndTimes> GetGrowthMindsetQuizAnswersByUser(string userid)
        {

            return _dashboardBusinessLogics.GetGrowthMindsetResultAndTimes(userid);
        }

        [HttpGet("getGrowthMindset", Name = "GetGrowthMindsetQuizAnswers")]
        public List<QuizResultAndTimes> GetGrowthMindsetQuizAnswers()
        {
            return _dashboardBusinessLogics.GetGrowthMindsetResultAndTimes();
        }

        [HttpGet("getMakingTimeAnswers/{userid}", Name = "GetMakingTimeQuizAnswersByUser")]
        public List<QuizResultAndTimes> GetMakingTimeQuizAnswersByUser(string userid)
        {

            return _dashboardBusinessLogics.GetMakingTimeResultAndTimes(userid);
        }

        [HttpGet("getMakingTimeAnswers", Name = "GetMakingTimeQuizAnswers")]
        public List<QuizResultAndTimes> GetMakingTimeQuizAnswers()
        {
            return _dashboardBusinessLogics.GetMakingTimeResultAndTimes();
        }

        // POST: api/Dashboard
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Dashboard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
