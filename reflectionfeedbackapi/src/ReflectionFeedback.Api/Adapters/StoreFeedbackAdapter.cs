using System.Collections.Generic;
using Microsoft.Extensions.Options;
using ReflectionFeedback.Api.Adapters.Interfaces;
using ReflectionFeedback.Api.Handlers;
using ReflectionFeedback.Api.Helpers;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Adapters
{
    internal class StoreFeedbackAdapter:IStoreFeedbackAdapter
    {
        private readonly IMongoClientHelper<FeedbackReply> _feedbackReplyClientHelper;
        private readonly IMongoClientHelper<Feedback> _feedbackClientHelper;
        private readonly string _feedbackCollection;
        private readonly string _feedbackReplyCollection;


        public StoreFeedbackAdapter(IMongoClientHelper<FeedbackReply> feedbackReplyClientHelper, 
            IMongoClientHelper<Feedback> feedbackClientHelper, IOptions<MongoDbSettings> settings)
        {
            _feedbackReplyClientHelper = feedbackReplyClientHelper;
            _feedbackClientHelper = feedbackClientHelper;
            _feedbackCollection = settings.Value.FeedbackCollection;
            _feedbackReplyCollection = settings.Value.FeedbackReplyCollection;
        }

        public void SaveFeedbackQuestion(Feedback feedback)
        {
            _feedbackClientHelper.InsertOne(feedback,_feedbackCollection);
        }

        public void SaveFeedbackReply(FeedbackReply feedbackReply)
        {
            _feedbackReplyClientHelper.InsertOne(feedbackReply, _feedbackReplyCollection);
            UpdateFeedbackStatus(feedbackReply.id);
        }

        public void AddOrUpdateFeedbackFromAdmin(List<Feedback> feedbacks)
        {
            _feedbackClientHelper.DeleteMany(FilterDefinitionHandler.FilterFeedbacksByPendingStatus(),_feedbackCollection);
            _feedbackClientHelper.InsertMany(feedbacks, _feedbackCollection);
        }

        public void UpdateFeedbackStatus(long id)
        {
            _feedbackClientHelper.UpdateOne(FilterDefinitionHandler.UpdateFeedBackStatus(id),
            FilterDefinitionHandler.FilterFeedBackById(id),_feedbackCollection);
        }

        public void FillFeedbackData()
        {

                _feedbackClientHelper.InsertMany(SampleData.FeedbackList(),_feedbackCollection);
                _feedbackReplyClientHelper.InsertMany(SampleData.FeedbackReplies(),_feedbackReplyCollection);

        }

        public void DeleteFeedback(long id)
        {
            _feedbackClientHelper.DeleteOne(FilterDefinitionHandler.FilterFeedBackById(id),_feedbackCollection);
        }

        public void UpdateFeedbackAssigned(Feedback feedback)
        {
            _feedbackClientHelper.UpdateOne(FilterDefinitionHandler.UpdateFeedbacksByAssignedAndTime(feedback.assigned),
                FilterDefinitionHandler.FilterFeedBackById(feedback.id), _feedbackCollection);
        }

    }
}
