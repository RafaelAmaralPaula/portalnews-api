using FluentValidation;
using PortalNews.Api.Validators.Enum;
using PortalNews.Api.Validators.Extensions;
using PortalNews.Application.DTO.NewsDataTransferObject;

using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Application.Validation
{
    public class NewsValidator : AbstractValidator<NewsDTO>
    {
        private readonly INewsRepository _repository;

        public NewsValidator(INewsRepository repository)
        {
            
            _repository = repository;


            RuleFor(news => news.Hat).IsValidNotEmpty();
                   

            RuleFor(news => news.Title)
                    .Must(_repository.ExistByTitle)
                    .WithMessage("Title já existe tente outro");
    
        }
    }
}
