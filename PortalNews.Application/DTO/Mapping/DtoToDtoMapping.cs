using AutoMapper;
using PortalNews.Application.DTO.NewsDataTransferObject;
using PortalNews.Application.DTO.UserDataTransferObject;

namespace PortalNews.Application.DTO.Mapping
{
    public  class DtoToDtoMapping : Profile
    {

        public DtoToDtoMapping()
        {
            CreateMap<NewsDTO, FindNewsDTO>();
            CreateMap<SaveUserDTO, FindUserDTO>();
           
        }

    }
}
