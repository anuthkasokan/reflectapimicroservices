using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ReflectionFeedback.Api.Models;

namespace ReflectionFeedback.Api.Filters
{
    internal class InternalErrorExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<InternalErrorExceptionFilter> _log;

        public InternalErrorExceptionFilter(ILogger<InternalErrorExceptionFilter> log)
        {
            _log = log ?? throw new ArgumentException(nameof(log));
        }

        public override void OnException(ExceptionContext context)
        {
            var errorSummary = new ErrorLogs
            {
                ErrorCode = StatusCodes.Status500InternalServerError,
                Message = "Exception: "+context.Exception.Message +" occurred in "+context.ActionDescriptor
            };

            _log.LogError(errorSummary.Message);

            context.Result= new JsonResult(errorSummary){ StatusCode = StatusCodes.Status500InternalServerError};
        }
    }
}
