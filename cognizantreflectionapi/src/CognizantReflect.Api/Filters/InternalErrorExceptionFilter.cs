using System;
using System.Globalization;
using CognizantReflect.Api.Helpers.Interfaces;
using CognizantReflect.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CognizantReflect.Api.Filters
{
    internal class InternalErrorExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<InternalErrorExceptionFilter> _log;
        private readonly IMongoClientHelper<ErrorLogs> _errorLogs;
        private readonly string _errorLogsCollection;

        public InternalErrorExceptionFilter(ILogger<InternalErrorExceptionFilter> log,IMongoClientHelper<ErrorLogs> errorLogs,
            IOptions<MongoDbSettings> settings)
        {
            _log = log ?? throw new ArgumentException(nameof(log));
            _errorLogs = errorLogs ?? throw new ArgumentException(nameof(log));
            _errorLogsCollection = settings.Value.ErrorLogsCollection;
        }

        public override void OnException(ExceptionContext context)
        {
            var errorSummary = new ErrorLogs
            {
                ErrorCode = StatusCodes.Status500InternalServerError,
                Message = "Exception: "+context.Exception.Message +"Error occurred in "+context.ActionDescriptor,
                CreateTimestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };

            _log.LogError(errorSummary.Message);
           // _errorLogs.InsertOne(errorSummary,_errorLogsCollection);

            context.Result= new JsonResult(errorSummary){ StatusCode = StatusCodes.Status500InternalServerError};
        }
    }
}
