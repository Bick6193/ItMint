using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Web.Tracing
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new HttpExceptionResult(HttpStatusCode.InternalServerError, context.Exception);
        }

        public class HttpExceptionResult : IActionResult
        {
            private HttpStatusCode StatusCode { get; }

            private Exception Exception { get; }

            public HttpExceptionResult(HttpStatusCode statusCode, Exception exception)
            {
                StatusCode = statusCode;
                Exception = exception;
            }

            public async Task ExecuteResultAsync(ActionContext context)
            {
                var message = new OperationResult
                {
                    Messages = new List<string>() { "[Unhandled Exception] " + Exception.Message },
                    StackTrace = Exception.StackTrace,
                    Success = false,
                    Code = OperationCode.UnhandledError
                };

                var json = JsonConvert.SerializeObject(message);

                var response = context.HttpContext.Response; 

                response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
                await response.WriteAsync(json, Encoding.ASCII);
            }
        }
    }
}

