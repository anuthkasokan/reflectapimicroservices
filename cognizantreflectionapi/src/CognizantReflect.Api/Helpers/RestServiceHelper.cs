using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using Microsoft.AspNetCore.Http;

namespace CognizantReflect.Api.Helpers
{
    public class RestServiceHelper<TResponse> : IServiceHelper<HttpWebRequest, TResponse>
    where TResponse : BaseHttpResponse, new()
    {
        public HttpWebRequest CreateWebRequest(ServiceRequest request)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(request.Url);
            webRequest.PreAuthenticate = true;
            webRequest.AllowAutoRedirect = true;
            webRequest.Method = request.HttpMethod;
            webRequest.ContentType = request.ContentType;

            if (!string.IsNullOrEmpty(request.AuthorizationHeader))
            {
                webRequest.Headers.Add("Access-Control-Allow-Origin","https://congizantreflectui.com");
                webRequest.Headers.Add("Origin","https://cognizantreflectui.com");
                webRequest.Headers.Add("Access-Control-Allow-Headers", "Authorization");
                webRequest.Headers.Add("Authorization", "Bearer " + request.AuthorizationHeader);
            }



            if (request.HttpMethod.ToLower() == "post")
            {
                if (string.IsNullOrEmpty(request.Request))
                    return webRequest;

                var byteArray = Encoding.UTF8.GetBytes(request.Request);
                webRequest.ContentLength = byteArray.Length;

                using var stream = webRequest.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);
            }

            return webRequest;

        }

        public TResponse HandleRequest(HttpWebRequest request)
        {
            var response = new TResponse();
            ParseHttpResponse((HttpWebResponse)request.GetResponse(), ref response);
            return response;
        }

        private void ParseHttpResponse(HttpWebResponse httpResponse, ref TResponse response)
        {
            var httpResponseStream = httpResponse?.GetResponseStream();
            if (httpResponseStream == null)
                return;
            var responseStreamReader = new StreamReader(httpResponseStream, Encoding.UTF8);
            var responseDate = responseStreamReader.ReadToEnd();
            response.HttpStatusCode = httpResponse.StatusCode;
            response.Description = string.IsNullOrEmpty(responseDate) ? httpResponse.StatusDescription : responseDate;
        }
    }
}
