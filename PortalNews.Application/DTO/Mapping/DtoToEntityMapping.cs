using AutoMapper;
using PortalNews.Application.DTO.NewsDataTransferObject;
using PortalNews.Application.DTO.RoleDataTransferObject;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Domain;

namespace PortalNews.Application.DTO.Mapping
{
    public class DtoToEntityMapping : Profile
    {
        public DtoToEntityMapping()
        {
            CreateMap<NewsDTO, News>();
            CreateMap<UpdateNewsDTO, News>();
            CreateMap<FindNewsDTO, News>();
            CreateMap<SaveUserDTO, User>();
            CreateMap<FindUserDTO, User>();
            CreateMap<RoleDTO, Role>();
            
        }

    }
}
