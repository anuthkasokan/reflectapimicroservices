using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;

namespace CognizantReflect.Tests.Filters
{
    [TestFixture]
    public class InternalExceptionFilterAttributeTest
    {
        //private static ExceptionContext ExceptionContext
        //{
        //    get
        //    {
        //        var routeData = new RouteData();
        //        var actionContext = GetActionContext(routeData);
        //        IList<IFilterMetadata> filters = new List<IFilterMetadata>();
        //        var context = new ExceptionContext(actionContext, filters);
        //        return context;
        //    }
        //}
        //private static ActionContext GetActionContext(RouteData routeData)
        //{
        //    return new ActionContext
        //    {
        //        HttpContext = new DefaultHttpContext(),
        //        RouteData = routeData,
        //        ActionDescriptor = new ActionDescriptor()

        //    };
        //}

    }
}
