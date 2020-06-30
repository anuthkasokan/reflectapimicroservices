using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CognizantReflect.Api.Models;

namespace CognizantReflect.Api.Helpers.Interfaces
{
    internal interface IServiceHelper<in TRequest, out TResponse>
    {
        TResponse HandleRequest(TRequest request);
        HttpWebRequest CreateWebRequest(ServiceRequest request);
    }
}
