using Newtonsoft.Json;
using PortalNews.Api.Test.Rules;

namespace PortalNews.Api.Exceptions
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {

        private readonly IEnumerable<IRuleException> _rules;

        private readonly CheckerException _checkerException;

     
        public GlobalExceptionHandlerMiddleware(IEnumerable<IRuleException> rules , CheckerException checkerException)
        {
            _rules = rules;
            _checkerException = checkerException;
            
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context , exception);
            }

        }

        public Task HandleExceptionAsync(HttpContext context , Exception exception)
        {
            context.Response.ContentType = "application/Json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(_checkerException.Action(exception , context)));
        }

      
    }
}
