using AutoMapper;
using LanguageExt;
using PortalNews.Application.DTO.RoleDataTransferObject;
using PortalNews.Application.Exceptions;
using PortalNews.Application.Services.Interfaces;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Application.Services.Implementations
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        
        public List<RoleDTO> FindAll()
        {
            return _mapper.Map<List<RoleDTO>>(_roleRepository.GetAll().ToList());
        }

        public Option<RoleDTO> FindById(string id)
        {
            var entity = _roleRepository.GetById(id);
            return entity.Match(Some: result => _mapper.Map<RoleDTO>(result),
                                None: () => throw new ResourceNotFoundException("Resource not found"));
        }
    }
}
