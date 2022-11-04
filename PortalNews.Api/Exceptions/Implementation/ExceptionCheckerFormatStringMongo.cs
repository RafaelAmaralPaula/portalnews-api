using PortalNews.Api.Exceptions;
using PortalNews.Api.Test.Rules;
using System.Net;

namespace PortalNews.Api.Test.Implementation
{
    public class ExceptionCheckerFormatStringMongo : IRuleException
    {

        public bool IsMatches(Exception ex)
        {
            bool isResourceNotFoundException = ex.GetType() == typeof(FormatException);
            return isResourceNotFoundException;
        }

        public Exception Execute(Exception ex)
        {
            return IsMatches(ex) ? new FormatException("") : default;
        }

        public StandardError GetTypeDetails(Exception exception , HttpContext context)
        {
            StandardError error = new StandardError();

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            error.TimesStamp = DateTime.Now;
            error.Status = (int)HttpStatusCode.BadRequest;
            error.Error = "Is not a valid 24 digit hex string.";
            error.Message = exception.Message;
            error.Path = context.Request.Path;
            return error;
        }
    }
 }

