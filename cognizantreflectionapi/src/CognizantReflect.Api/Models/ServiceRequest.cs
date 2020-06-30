using System.Globalization;

namespace CognizantReflect.Api.Models
{
    public class ServiceRequest
    {
        public string Request { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public string AuthorizationHeader { get; set; }
        public string HttpMethod { get; set; }
        public string Host { get; set; }

    }
}
