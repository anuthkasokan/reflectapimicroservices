using System.Collections.Generic;

namespace ReflectionEmailService.Helpers.Interface
{
    internal interface IHttpClientWrapper<TModel>
    {
        List<TModel> GetData(string methodname);
    }
}
