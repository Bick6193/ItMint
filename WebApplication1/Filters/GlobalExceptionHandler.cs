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

namespace Web.Filters
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Log.Logger().Error(context.Exception, "Unhandled exception in controller: {contr}, action: {act}",
                context.RouteData.Values["controller"], context.RouteData.Values["action"]);

            context.Result = new ExceptionActionResult(HttpStatusCode.InternalServerError, context.Exception);
        }
    }
}

