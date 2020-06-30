using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReflectionFeedback.Api.Adapters.Interfaces;
using ReflectionFeedback.Api.Handlers;
using ReflectionFeedback.Api.Helpers;
using ReflectionFeedback.Api.Helpers.Interfaces;
using ReflectionFeedback.Api.Models;

[assembly: InternalsVisibleTo("ReflectUser.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ReflectionFeedback.Api.Adapters
{
    internal class GetFeedbackDetailsAdapter : IGetFeedbackDetailsAdapter
    {
        private readonly IMongoClientHelper<Feedback> _feedbackClientHelper;
        private readonly IMongoClientHelper<FeedbackReply> _feedbackReplyClientHelper;
        private readonly string _feedbackCollection;
        private readonly string _feedbackReplyCollection;


        public GetFeedbackDetailsAdapter(IMongoClientHelper<Feedback> feedbackClientHelper,
            IMongoClientHelper<FeedbackReply> feedbackReplyClientHelper,
            IOptions<MongoDbSettings> settings)
        {
            _feedbackClientHelper = feedbackClientHelper;
            _feedbackReplyClientHelper = feedbackReplyClientHelper;
            _feedbackCollection = settings.Value.FeedbackCollection;
            _feedbackReplyCollection = settings.Value.FeedbackReplyCollection;
        }

        public List<Feedback> GetFeedBacksAssignedToUser(string userid)
        {
            //return SampleData.FeedbackList().Where(x => x.assigned == userid && x.status == "pending")?.ToList();
            return _feedbackClientHelper.GetData(
                  FilterDefinitionHandler.FilterFeedbacksByUserAndStatus(userid)
                  , _feedbackCollection);
        }

        public List<Feedback> GetFeedbackRequestsByUser(string userid)
        {
            //return SampleData.FeedbackList().Where(x => x.userid == userid)?.ToList();
            return _feedbackClientHelper.GetData(FilterDefinitionHandler.FilterFeedBackByUser(userid),
                _feedbackCollection);
        }

        public FeedbackReply GetFeedbackReplyForQuestion(long questionId)
        {
            // return SampleData.FeedbackReplies().Where(r => r.feedbackid == questionId)?.FirstOrDefault();
            return _feedbackReplyClientHelper.GetData(
                  FilterDefinitionHandler.FilterFeedBackReply(questionId),
                  _feedbackReplyCollection).FirstOrDefault();
        }

        public List<Feedback> GetAllPendingFeedbacks()
        {
            //return SampleData.FeedbackList().Where(x => x.status == "pending" && x.type == "feedback").ToList();
            var feedbackList= _feedbackClientHelper.GetData(FilterDefinitionHandler.FilterFeedbacksByTypeAndStatus(),
                _feedbackCollection);

            var replyList = _feedbackReplyClientHelper.GetData(FilterDefinitionHandler.FilterFeedBackReply(0),
                    _feedbackReplyCollection);

            if (replyList != null && replyList.Any())
            {
                foreach (var reply in replyList)
                {
                    Feedback feedback = new Feedback
                    {
                        question = reply.feedback,
                        createtimestamp = reply.createtimestamp
                    };
                    feedbackList.Add(feedback);
                }
            }

            return feedbackList;
        }

        public long GetLastAddedFeedback()
        {
            //return SampleData.FeedbackList().OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0;
            return _feedbackClientHelper.GetDataBySorting(FilterDefinition<Feedback>.Empty,
                FilterDefinitionHandler.SortFeedBackRyId(), _feedbackCollection).FirstOrDefault()
                ?.id ?? 0;
        }

        public long GetLastAddedFeedbackReply()
        {
            //return SampleData.FeedbackList().OrderByDescending(x => x.id).FirstOrDefault()?.id ?? 0;
            return _feedbackReplyClientHelper.GetDataBySorting(FilterDefinition<FeedbackReply>.Empty,
                    FilterDefinitionHandler.SortFeedBackReply(), _feedbackReplyCollection).FirstOrDefault()
                ?.id ?? 0;
        }
    }
}
