using System.Net;
using Common;

using Microsoft.AspNetCore.Mvc.Filters;

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

