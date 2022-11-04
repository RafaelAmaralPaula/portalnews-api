using FluentValidation;
using PortalNews.Api.Validators.Enum;

namespace PortalNews.Api.Validators.Extensions
{
    public static class FluentExtensions
    {
        public static IRuleBuilderOptions<T, TElement> IsValidNotEmpty<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage(DefaultMessage.MESSAGE_NOT_EMPTY);
        }

    }
}
