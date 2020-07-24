using System;
using System.Globalization;
using MongoDB.Driver;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Handlers
{
    internal static class FilterDefinitionHandler
    {
        internal static FilterDefinition<Feedback> FilterFeedbacksByPendingStatus()
            => Builders<Feedback>.Filter.Eq(f => f.status,"pending");
        internal static FilterDefinition<Feedback> FilterFeedbacksByType()
            => Builders<Feedback>.Filter.Eq(f => f.type, "feedback");

        internal static FilterDefinition<Feedback> FilterAssignedFeedbacksByUser(string userid)
            => Builders<Feedback>.Filter.Eq(f => f.assigned, userid);

        internal static FilterDefinition<Feedback> FilterFeedbacksByTypeAndStatus()
            => Builders<Feedback>.Filter.And(FilterFeedbacksByPendingStatus(), FilterFeedbacksByType());

        internal static FilterDefinition<Feedback> FilterFeedbacksByUserAndStatus(string userid)
            => Builders<Feedback>.Filter.And(FilterFeedbacksByPendingStatus(),FilterAssignedFeedbacksByUser(userid));

        internal static FilterDefinition<Feedback> FilterFeedBackByUser(string userid)
            => Builders<Feedback>.Filter.Eq(f => f.userid, userid);

        internal static FilterDefinition<FeedbackReply> FilterFeedBackReply(long questionId)
         => Builders<FeedbackReply>.Filter.Eq(f => f.feedbackid, questionId);

        internal static SortDefinition<FeedbackReply> SortFeedBackReply()
            => Builders<FeedbackReply>.Sort.Descending(s => s.id);

        internal static SortDefinition<Feedback> SortFeedBackRyId()
            => Builders<Feedback>.Sort.Descending(s => s.id);

        internal static FilterDefinition<Feedback> FilterFeedBackById(long id)
            => Builders<Feedback>.Filter.Eq(f => f.id, id);

        internal static UpdateDefinition<Feedback> UpdateFeedBackStatus(long id)
            => Builders<Feedback>.Update.Set(f => f.status, "closed");

        internal static UpdateDefinition<Feedback> UpdateFeedBackAssigned(string assignId)
            => Builders<Feedback>.Update.Set(f => f.assigned, assignId);

        internal static UpdateDefinition<Feedback> UpdateFeedBackTime()
            => Builders<Feedback>.Update.Set(f => f.updatetimestamp, DateTime.Now.ToString(CultureInfo.InvariantCulture));

        internal static UpdateDefinition<Feedback> UpdateFeedbacksByAssignedAndTime(string userid)
            => Builders<Feedback>.Update.Combine(new []{UpdateFeedBackAssigned(userid),UpdateFeedBackTime()});

    }
}
