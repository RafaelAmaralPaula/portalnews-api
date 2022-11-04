using PortalNews.Api.Test.Implementation;
using PortalNews.Api.Test.Rules;


namespace PortalNews.Api.Exceptions
{
    public class CheckerException
    {

        private readonly IEnumerable<IRuleException> _rules;


        public CheckerException(IEnumerable<IRuleException> rules)
        {
            _rules = rules;
        }


        public StandardError Action(Exception exception, HttpContext context)
        {
            foreach (var rule in _rules)
            {
                var error = rule.Execute(exception);
                if (error != null)
                {
                    return rule.GetTypeDetails(exception, context);
                    break;
                }
            }
            return null;
        }

    }
}

