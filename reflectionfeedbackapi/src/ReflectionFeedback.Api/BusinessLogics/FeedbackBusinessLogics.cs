using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using ReflectionFeedback.Api.Adapters.Interfaces;
using ReflectionFeedback.Api.BusinessLogics.Interfaces;
using ReflectionFeedback.Api.Models;

[assembly: InternalsVisibleTo("ReflectUser.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ReflectionFeedback.Api.BusinessLogics
{
    internal class FeedbackBusinessLogics : IFeedbackBusinessLogics
    {
        private readonly IStoreFeedbackAdapter _storeFeedbackAdapter;
        private readonly IGetFeedbackDetailsAdapter _getFeedbackDetailsAdapter;

        public FeedbackBusinessLogics(IStoreFeedbackAdapter storeFeedbackAdapter, 
            IGetFeedbackDetailsAdapter getFeedbackDetailsAdapter)
        {
            _storeFeedbackAdapter = storeFeedbackAdapter;
            _getFeedbackDetailsAdapter = getFeedbackDetailsAdapter;
        }

        public void StoreFeedbackQuestions(Feedback feedback)
        {
            feedback.id = _getFeedbackDetailsAdapter.GetLastAddedFeedback() + 1;
            feedback.createtimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            feedback.type = "feedback";
            feedback.status = "pending";
            _storeFeedbackAdapter.SaveFeedbackQuestion(feedback);
        }

        public List<Feedback> GetFeedbackDetailsForAdmin()
        {
            return _getFeedbackDetailsAdapter.GetAllPendingFeedbacks();
        }

        public void SaveFeedbackReply(FeedbackReply feedbackReply)
        {
            feedbackReply.createtimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            feedbackReply.id = _getFeedbackDetailsAdapter.GetLastAddedFeedbackReply() + 1;
            _storeFeedbackAdapter.SaveFeedbackReply(feedbackReply);
        }

        public void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks)
        {
            var i = _getFeedbackDetailsAdapter.GetLastAddedFeedback() + 1;
            foreach (var feedback in feedbacks)
            {
                if (feedback.id == 0)
                {
                    if (!string.IsNullOrEmpty(feedback.assigned))
                    {
                        feedback.createtimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                        feedback.id = i;
                        feedback.type = "feedback";
                        feedback.status = "pending";
                        _storeFeedbackAdapter.SaveFeedbackQuestion(feedback);
                        i++;
                    }

                }
                else
                {
                    feedback.updatetimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    _storeFeedbackAdapter.UpdateFeedbackAssigned(feedback);
                }
            }
        }

        public void UpdateFeedbackStatus(long id)
        {
            _storeFeedbackAdapter.UpdateFeedbackStatus(id);
        }

        public void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification)
        {
            foreach (var coworker in blindSpotNotification.coworkerid)
            {
                Feedback feedback = new Feedback
                {
                    id = _getFeedbackDetailsAdapter.GetLastAddedFeedback() + 1,
                    assigned = coworker,
                    createtimestamp = DateTime.Now.ToString(),
                    question = "You have been requested for blind spot by your friend " + blindSpotNotification.userid,
                    status = "pending",
                    updatetimestamp = DateTime.Now.ToString(),
                    type = "blindspot",
                    userid = blindSpotNotification.userid
                };

                _storeFeedbackAdapter.SaveFeedbackQuestion(feedback);
            }
        }

        public List<Feedback> GetNotificationListForUser(string userid, int start, int count)
        {
            List<Feedback> feedbacks = new List<Feedback>();

            var feedbacksAssignedToUser = _getFeedbackDetailsAdapter.GetFeedBacksAssignedToUser(userid);

            if (feedbacksAssignedToUser.Any())
                feedbacks.AddRange(feedbacksAssignedToUser);


            var feedbacksAddedByUser = _getFeedbackDetailsAdapter.GetFeedbackRequestsByUser(userid);

            if (feedbacksAddedByUser.Any())
            {
                foreach (var feedback in feedbacksAddedByUser)
                {
                    var getReply = _getFeedbackDetailsAdapter.GetFeedbackReplyForQuestion(feedback.id);

                    if (getReply != null)
                    {

                        Feedback addAsNotification = new Feedback
                        {
                            userid = userid,
                            question = getReply.feedback,
                            status = "pending",
                            type = "feedback"
                        };
                        feedbacks.Add(addAsNotification);
                    }
                }
            }

            if (feedbacks.Count > start && feedbacks.Count < (start + count))
            {
                return feedbacks.GetRange(start, (feedbacks.Count - start));
            }

            if (feedbacks.Count > start)
            {
                return feedbacks.GetRange(start, count);
            }

            return new List<Feedback>();


        }

        public List<Feedback> GetAdminComments(string userid)
        {
            return _getFeedbackDetailsAdapter.GetFeedBacksAssignedToUser(userid);
        }

        public long GetNotificationCount(string userid)
        {
            var feedbacksAssignedToUser = _getFeedbackDetailsAdapter.GetFeedBacksAssignedToUser(userid)?.Count ?? 0;


            var feedbacksAddedByUser = _getFeedbackDetailsAdapter.GetFeedbackRequestsByUser(userid);

            if (feedbacksAddedByUser.Any())
            {
                foreach (var feedback in feedbacksAddedByUser)
                {
                    var getReply = _getFeedbackDetailsAdapter.GetFeedbackReplyForQuestion(feedback.id);

                    if (getReply != null)
                    {
                        feedbacksAssignedToUser++;
                    }
                }
            }

            return feedbacksAssignedToUser;
        }

        public void FillFeedback()
        {
            _storeFeedbackAdapter.FillFeedbackData();
        }

        public void DeleteFeedback(long id)
        {
            _storeFeedbackAdapter.DeleteFeedback(id);
        }

    }
}
