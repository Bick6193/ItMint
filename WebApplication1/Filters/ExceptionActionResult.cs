using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Filters
{
    public class ExceptionActionResult : IActionResult
    {
        private HttpStatusCode StatusCode { get; }

        private Exception Exception { get; }

        public ExceptionActionResult(HttpStatusCode statusCode, Exception exception)
        {
            StatusCode = statusCode;
            Exception = exception;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var message = new OperationResult
            {
                Message = "[Unhandled Exception] " + Exception.Message,
                StackTrace = Exception.StackTrace,
                Success = false,
                Code = OperationCode.UnhandledError
            };

            var json = JsonConvert.SerializeObject(message);

            var response = context.HttpContext.Response;

            response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
            response.StatusCode = (int)StatusCode;
            await response.WriteAsync(json, Encoding.ASCII);
        }
    }
}
