using System.Collections.Generic;
using CognizantReflect.Api.Models.Dashboard;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface IDashboardBusinessLogics
    {
        int[][] GetDetailsForScoreGraphChart(string user);

        int[][] GetDetailsForScoreGraphChart();

        QuizAttemptCounts GetQuizAttemptCountsByUser(string userid);

        QuizAttemptCounts GetTotalQuizAttemptCounts();

        int GetPercentageOfCompletionByUser(string userid);

        int GetOverallPercentageOfQuizCompletion();

        int[] GetQuizAttemptHistoryDetailsByUser(string userid);

        int[] GetQuizAttemptHistoryDetails();

        int[] GetContinuousLearningDetails(string userid);

        List<QuizResultAndTimes> GetCuriosityResultAndTimes();

        List<QuizResultAndTimes> GetCuriosityResultAndTimes(string userid);

        List<QuizResultAndTimes> GetGrowthMindsetResultAndTimes();

        List<QuizResultAndTimes> GetGrowthMindsetResultAndTimes(string userid);

        List<QuizResultAndTimes> GetMakingTimeResultAndTimes();

        List<QuizResultAndTimes> GetMakingTimeResultAndTimes(string userid);

    }
}
