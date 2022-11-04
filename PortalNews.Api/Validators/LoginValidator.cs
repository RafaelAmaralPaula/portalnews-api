using FluentValidation;
using PortalNews.Api.Validators.Enum;
using PortalNews.Api.Validators.Extensions;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Api.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        private readonly IUserRepository _userRepository;
        public LoginValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(e => e.Email).IsValidNotEmpty();
            RuleFor(e => e.Password).IsValidNotEmpty();



            RuleFor(e => e)
                .Must(IsValidEmailAndPasswordValid)
                .WithName("Email/Senha")
                .WithMessage(DefaultMessage.MESSAGE_EMAIL_PASSWORD_INVALID);

            
        }
        private bool IsValidEmailAndPasswordValid(LoginDTO loginDTO)
        {
            var result = _userRepository.ExistByEmailAndPassword(loginDTO.Email, loginDTO.Password);
            return result;
            
        }
    }
}
