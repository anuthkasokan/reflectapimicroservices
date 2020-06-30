using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CognizantReflect.Api.BusinessLogics.Interfaces
{
    public interface ISettingsBusinessLogics
    {
        HttpStatusCode UploadExcel(string path);
    }
}
