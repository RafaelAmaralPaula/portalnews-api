using PortalNews.Api.Exceptions;
using PortalNews.Api.Test.Rules;
using PortalNews.Application.Exceptions;
using System.Net;

namespace PortalNews.Api.Test.Implementation
{
    public class ExceptionCheckerResourceNotFound : IRuleException
    {

        public bool IsMatches(Exception ex)
        {
            bool isResourceNotFoundException = ex.GetType() == typeof(ResourceNotFoundException);
            return isResourceNotFoundException;
        }

        public Exception Execute(Exception ex)
        {
            return IsMatches(ex) ? new ResourceNotFoundException("") : default;
        }

        public StandardError GetTypeDetails(Exception exception, HttpContext context)
        {
            StandardError error = new StandardError();

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            error.TimesStamp = DateTime.Now;
            error.Status = (int)HttpStatusCode.NotFound;
            error.Error = "Resource not found";
            error.Message = exception.Message;
            error.Path = context.Request.Path;
            return error;
        }

    }
}
