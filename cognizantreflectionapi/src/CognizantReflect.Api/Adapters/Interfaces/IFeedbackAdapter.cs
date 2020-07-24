using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CognizantReflect.Api.Models.FeedbackService;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("CognizantReflect.Tests")]
namespace CognizantReflect.Api.Adapters.Interfaces
{
    internal interface IFeedbackAdapter
    {
        void SendNotification(BlindSpotNotification notification);

        List<Feedback> GetFeedbackDetailsForAdmin();

        void SaveFeedbackQuestion(Feedback feedback);

        void SaveFeedbackReply(FeedbackReply feedbackReply);

        void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks);

        void UpdateFeedbackStatus(long id);

        void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification);

        List<Feedback> GetNotificationListForUser(string userid, int start, int count);

        long GetNotificationsCount(string userid);

        List<Feedback> GetAdminComments(string userid);

        void DeleteFeedback(long id);
    }
}
