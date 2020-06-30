using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionFeedback.Api.BusinessLogics.Interfaces;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBusinessLogics _feedbackBusinessLogics;

        public FeedbackController(IFeedbackBusinessLogics feedbackBusinessLogics)
        {
            _feedbackBusinessLogics = feedbackBusinessLogics;
        }

        // GET: api/Feedback
        [HttpGet("getFeedbackDetailsForAdmin",Name = "GetFeedbackDetailsForAdmin")]
        public List<Feedback> GetFeedbackDetailsForAdmin()
        {
            return _feedbackBusinessLogics.GetFeedbackDetailsForAdmin();
        }

        // POST: api/Feedback
        [HttpPost("saveFeedbackQuestion",Name = "SaveFeedbackQuestion")]
        public void SaveFeedbackQuestion(Feedback feedback)
        {
            _feedbackBusinessLogics.StoreFeedbackQuestions(feedback);
        }

        [HttpPost("saveFeedbackReply", Name = "SaveFeedbackReply")]
        public void SaveFeedbackReply(FeedbackReply feedbackReply)
        {
            _feedbackBusinessLogics.SaveFeedbackReply(feedbackReply);
        }

        [HttpPost("updateOrAddFeedbacksByAdmin", Name = "UpdateOrAddFeedbacksByAdmin")]
        public void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks)
        {
            _feedbackBusinessLogics.UpdateOrAddFeedbacksByAdmin(feedbacks);
        }

        [HttpPost("updateFeedbackStatus", Name = "UpdateFeedbackStatus")]
        public void UpdateFeedbackStatus(long id)
        {
            _feedbackBusinessLogics.UpdateFeedbackStatus(id);
        }


        [HttpPost("saveBlindSpotNotification", Name = "SaveBlindSpotNotification")]
        public void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification)
        {
            _feedbackBusinessLogics.SaveBlindSpotNotification(blindSpotNotification);
        }

        [HttpGet("getNotificationListForUser/{userid}/{start}/{count}", Name = "GetNotificationListForUser")]
        public List<Feedback> GetNotificationListForUser(string userid,int start,int count)
        {
            return _feedbackBusinessLogics.GetNotificationListForUser(userid,start,count);
        }

        [HttpGet("getNotificationsCount/{userid}", Name = "GetNotificationsCount")]
        public long GetNotificationsCount(string userid)
        {
            return _feedbackBusinessLogics.GetNotificationCount(userid);
        }

        [HttpGet("getAdminComments/{userid}", Name = "GetAdminComments")]
        public List<Feedback> GetAdminComments(string userid)
        {
            return _feedbackBusinessLogics.GetAdminComments(userid);
        }

        [HttpPost("deleteFeedback", Name = "DeleteFeedback")]
        public void DeleteFeedback(long id)
        {
            _feedbackBusinessLogics.DeleteFeedback(id);
        }

    }
}
