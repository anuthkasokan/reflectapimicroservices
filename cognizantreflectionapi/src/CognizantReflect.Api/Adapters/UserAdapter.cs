using System;
using System.Collections.Generic;
using System.Net;
using CognizantReflect.Api.Adapters.Interfaces;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using CognizantReflect.Api.Models.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;

namespace CognizantReflect.Api.Adapters
{
    internal class UserAdapter:IUserAdapter
    {
        private readonly IOptions<ServiceSettings> _config;
        private readonly IServiceHelper<HttpWebRequest, BaseHttpResponse> _serviceHelper;
        private readonly ILogger<UserAdapter> _log;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAdapter(IServiceHelper<HttpWebRequest,BaseHttpResponse> serviceHelper,
            IOptions<ServiceSettings> config,ILogger<UserAdapter> log,IHttpContextAccessor httpContextAccessor)
        {
            _serviceHelper = serviceHelper;
            _config = config;
            _log = log;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<UserDetails> GetUserList()
        {
            var token = _httpContextAccessor.HttpContext.GetTokenAsync("access_token")?.Result;

            ServiceRequest request = new ServiceRequest
            {
                Url = _config.Value.UserServiceUrl+ "getUser",
                ContentType = "application/json",
                HttpMethod = "GET",
                AuthorizationHeader = token
            };
            var webRequest = _serviceHelper.CreateWebRequest(request);
            BaseHttpResponse webResponse = _serviceHelper.HandleRequest(webRequest);

            if (webResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<UserDetails>>(webResponse.Description);
            }
            
            _log.LogError(webResponse.Description);

            return new List<UserDetails>();
        }
    }
}
