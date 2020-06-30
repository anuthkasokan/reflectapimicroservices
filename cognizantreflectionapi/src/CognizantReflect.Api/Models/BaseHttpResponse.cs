using System.Net;

namespace CognizantReflect.Api.Models
{
    public class BaseHttpResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Description { get; set; }
    }
}
