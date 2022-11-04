using FluentValidation;
using LanguageExt;
using PortalNews.Api.Validators.Enum;
using PortalNews.Api.Validators.Extensions;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Api.Validators
{
    public class UserValidator : AbstractValidator<SaveUserDTO>
    {
        private readonly IUserRepository _userRepository;

        private readonly IRoleRepository _roleRepository;
        public UserValidator(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;


            RuleFor(e => e.Name).IsValidNotEmpty();
            RuleFor(e => e.Email).IsValidNotEmpty();

            RuleFor(e => e.Email)
                .Must(_userRepository.ExistByEmail)
                .WithMessage(DefaultMessage.MESSAGE_EXISTING_EMAIL);


            RuleFor(e => e.RoleId)
                .Must(IsValidRoleId)
                .WithMessage(DefaultMessage.MESSAGE_ROLE_NON_EXISTING);

          

        }


        private bool IsValidRoleId(string roleId)
        {
            var findRole = _roleRepository.GetById(roleId);
            return findRole == null ? false : true;
        
        }

    }
}
