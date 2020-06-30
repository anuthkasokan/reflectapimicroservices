using System.Collections.Generic;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Adapters.Interfaces
{
    internal interface IStoreFeedbackAdapter
    {
        void SaveFeedbackQuestion(Feedback feedback);

        void SaveFeedbackReply(FeedbackReply feedbackReply);

        void AddOrUpdateFeedbackFromAdmin(List<Feedback> feedback);

        void UpdateFeedbackStatus(long id);

        void FillFeedbackData();

        void DeleteFeedback(long id);

        void UpdateFeedbackAssigned(Feedback feedback);
    }
}
