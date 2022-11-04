using AutoMapper;
using LanguageExt;
using PortalNews.Api.Services;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Application.Exceptions;
using PortalNews.Application.Services.Interfaces;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;
using PortalNews.Util.SecureIdentity;
using SecureIdentity.Password;

namespace PortalNews.Application.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        private readonly EmailService _emailService;


        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository , IMapper mapper, EmailService emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public List<FindUserDTO> FindAll()
        {
            return _mapper.Map<List<FindUserDTO>>(_userRepository.GetAll());
        }

        public Option<FindUserDTO> FindById(string id)
        {
            var entity = _userRepository.GetById(id);
            return entity.Match(Some: result => _mapper.Map<FindUserDTO>(result),
                                None: () => throw new ResourceNotFoundException("Resource not found"));
        }

        public Option<FindUserDTO> FindByEmail(string email)
        {
            var entity = _userRepository.GetByEmail(email);
            return FindById(entity.Id);
        }

        public FindUserDTO Save(SaveUserDTO userDTO)
        {
           
            var entity = _mapper.Map<User>(userDTO);
            var password = PasswordHashedUtil.GeneratePassword();
            _emailService.Send(entity.Name, entity.Email, "Sem Assunto", 
                "<h1>Olá! Aqui Hvex: </h1> " +
                password );
            entity.PasswordHash = PasswordHashedUtil.GeneratePasswordHashed(password);
            return _mapper.Map<FindUserDTO>(_userRepository.Create(entity));

        }
    }
}
