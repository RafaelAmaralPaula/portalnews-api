using AutoMapper;
using PortalNews.Application.DTO.NewsDataTransferObject;
using PortalNews.Application.DTO.RoleDataTransferObject;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Domain;

namespace PortalNews.Application.DTO.Mapping
{
    public class EntityToDTOMapping : Profile
    {
        public EntityToDTOMapping()
        {
            CreateMap<News, NewsDTO>();
            CreateMap<News, FindNewsDTO>();
            CreateMap<News, UpdateNewsDTO>();
            CreateMap<User, SaveUserDTO>();
            CreateMap<User, FindUserDTO>();
            CreateMap<Role, RoleDTO>();
        }
    }
}
