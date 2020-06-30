using System.Collections.Generic;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.BusinessLogics.Interfaces
{
    public interface IFeedbackBusinessLogics
    {
        void StoreFeedbackQuestions(Feedback feedback);

        List<Feedback> GetFeedbackDetailsForAdmin();

        void SaveFeedbackReply(FeedbackReply feedbackReply);

        void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks);

        List<Feedback> GetNotificationListForUser(string userid, int start, int count);

        void UpdateFeedbackStatus(long id);

        void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification);

        List<Feedback> GetAdminComments(string userid);

        long GetNotificationCount(string userid);

        void FillFeedback();

        void DeleteFeedback(long id);
    }


}
