using PortalNews.Api.Exceptions;
using System;
using System.ComponentModel.Design;

namespace PortalNews.Api.Test.Rules
{
    public interface IRuleException
    {
        bool IsMatches(Exception ex);
        Exception Execute(Exception ex);
        StandardError GetTypeDetails(Exception ex , HttpContext context);

    }
}
