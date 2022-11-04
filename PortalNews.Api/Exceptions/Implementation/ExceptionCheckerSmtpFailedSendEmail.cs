using PortalNews.Api.Exceptions;
using PortalNews.Api.Test.Rules;

using System.Net;
using System.Net.Mail;

namespace PortalNews.Api.Test.Implementation
{
    public class ExceptionCheckerSmptFailedSendEmail : IRuleException
    {
       
        public bool IsMatches(Exception ex)
        {
                bool isResourceNotFoundException = ex.GetType() == typeof(SmtpException);
                return isResourceNotFoundException;
        }

        public Exception Execute(Exception ex)
        {
            return IsMatches(ex) ? new SmtpException() : default;
        }

        public StandardError GetTypeDetails(Exception exception, HttpContext context)
        {
            StandardError error = new StandardError();

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            error.TimesStamp = DateTime.Now;
            error.Status = (int)HttpStatusCode.BadRequest;
            error.Error = "Email not send";
            error.Message = exception.Message;
            error.Path = context.Request.Path;
            return error;
        }

    }

}