using System.Collections.Generic;
using CognizantReflect.Api.Models.Dashboard;
using CognizantReflect.Api.Models.FeedbackService;
using CognizantReflect.Api.Models.UserService;

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

        List<UserDetails> GetUserDetails(string userId = "");

        UserDetails GetLoggedUserDetails(string userId = "", string emailId = "");

        List<UserDetails> GetUsersByRole(string role);

        void StoreFeedbackQuestions(Feedback feedback);

        List<Feedback> GetFeedbackDetailsForAdmin();

        void SaveFeedbackReply(FeedbackReply feedbackReply);

        void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks);

        List<Feedback> GetNotificationListForUser(string userid, int start, int count);

        void UpdateFeedbackStatus(long id);

        void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification);

        List<Feedback> GetAdminComments(string userid);

        long GetNotificationCount(string userid);

        void DeleteFeedback(long id);
    }
}
