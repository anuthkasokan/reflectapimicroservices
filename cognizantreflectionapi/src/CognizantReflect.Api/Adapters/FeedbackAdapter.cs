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
    }
}
