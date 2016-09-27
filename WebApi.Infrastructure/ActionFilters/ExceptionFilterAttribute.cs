using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi.Infrastructure.ActionFilters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}