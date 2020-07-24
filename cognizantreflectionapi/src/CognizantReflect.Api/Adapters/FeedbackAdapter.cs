using System.Collections.Generic;
using System.Net;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.FeedbackService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace CognizantReflect.Api.Adapters
{
    internal class FeedbackAdapter:IFeedbackAdapter
    {
        private readonly IOptions<ServiceSettings> _config;
        private readonly IServiceHelper<HttpWebRequest, BaseHttpResponse> _serviceHelper;
        private readonly ILogger<FeedbackAdapter> _log;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FeedbackAdapter(IServiceHelper<HttpWebRequest, BaseHttpResponse> serviceHelper,
            IOptions<ServiceSettings> config, ILogger<FeedbackAdapter> log, IHttpContextAccessor httpContextAccessor)
        {
            _serviceHelper = serviceHelper;
            _config = config;
            _log = log;
            _httpContextAccessor = httpContextAccessor;
        }

        public void SendNotification(BlindSpotNotification notification)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "saveBlindSpotNotification",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(notification),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result
                
            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }

        }

        public List<Feedback> GetFeedbackDetailsForAdmin()
        {
            var token = _httpContextAccessor?.HttpContext?.GetTokenAsync("access_token")?.Result;

            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "getFeedbackDetailsForAdmin",
                ContentType = "application/json",
                HttpMethod = "GET",
                AuthorizationHeader = token
            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Feedback>>(webResponse.Description);
            }

            _log.LogError(webResponse.Description);

            return new List<Feedback>();
        }

        public void SaveFeedbackQuestion(Feedback feedback)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "saveFeedbackQuestion",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(feedback),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result

            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }
        }

        public void SaveFeedbackReply(FeedbackReply feedbackReply)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "saveFeedbackReply",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(feedbackReply),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result

            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }
        }

        public void UpdateOrAddFeedbacksByAdmin(List<Feedback> feedbacks)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "updateOrAddFeedbacksByAdmin",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(feedbacks),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result

            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }
        }

        public void UpdateFeedbackStatus(long id)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "updateFeedbackStatus",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(id),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result

            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }
        }

        public void SaveBlindSpotNotification(BlindSpotNotification blindSpotNotification)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "saveBlindSpotNotification",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(blindSpotNotification),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result

            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }
        }

        public List<Feedback> GetNotificationListForUser(string userid, int start, int count)
        {
            var token = _httpContextAccessor?.HttpContext?.GetTokenAsync("access_token")?.Result;

            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "getNotificationListForUser/"+userid+"/"+start+"/"+count,
                ContentType = "application/json",
                HttpMethod = "GET",
                AuthorizationHeader = token
            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Feedback>>(webResponse.Description);
            }

            _log.LogError(webResponse.Description);

            return new List<Feedback>();
        }

        public long GetNotificationsCount(string userid)
        {
            var token = _httpContextAccessor?.HttpContext?.GetTokenAsync("access_token")?.Result;

            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "getNotificationsCount/"+userid,
                ContentType = "application/json",
                HttpMethod = "GET",
                AuthorizationHeader = token
            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<long>(webResponse.Description);
            }

            _log.LogError(webResponse.Description);

            return 0;
        }

        public List<Feedback> GetAdminComments(string userid)
        {
            var token = _httpContextAccessor?.HttpContext?.GetTokenAsync("access_token")?.Result;

            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "getAdminComments/"+userid,
                ContentType = "application/json",
                HttpMethod = "GET",
                AuthorizationHeader = token
            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<Feedback>>(webResponse.Description);
            }

            _log.LogError(webResponse.Description);

            return new List<Feedback>();
        }

        public void DeleteFeedback(long id)
        {
            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.FeedbackServiceUrl + "deleteFeedback",
                ContentType = "application/json",
                HttpMethod = "POST",
                Request = JsonConvert.SerializeObject(id),
                AuthorizationHeader = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result

            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _log.LogError(webResponse.Description);
            }
        }
    }
}
