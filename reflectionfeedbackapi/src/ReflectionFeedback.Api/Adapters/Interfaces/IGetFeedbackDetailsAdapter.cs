using System.Collections.Generic;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Adapters.Interfaces
{
    internal interface IGetFeedbackDetailsAdapter
    {

        List<Feedback> GetFeedBacksAssignedToUser(string userid);

        List<Feedback> GetFeedbackRequestsByUser(string userid);

        FeedbackReply GetFeedbackReplyForQuestion(long questionId);

        List<Feedback> GetAllPendingFeedbacks();

        long GetLastAddedFeedback();

        long GetLastAddedFeedbackReply();
    }
}
