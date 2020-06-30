using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ReflectionEmailService.Helpers.Interface;
using ReflectionEmailService.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace ReflectionEmailService.Helpers
{
    internal class HttpClientWrapper<TModel> : IHttpClientWrapper<TModel>
    {
        private readonly string _apibaseurl;
        public HttpClientWrapper(IOptions<envSettings> options)
        {
            _apibaseurl = options.Value.userapibaseurl;
        }

        public List<TModel> GetData(string methodname)
        {
            List<TModel> details = new List<TModel>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(_apibaseurl + methodname);
            string apiResponse = response.Result;
            details = JsonConvert.DeserializeObject<List<TModel>>(apiResponse);
            return details;
        }
    }
}
