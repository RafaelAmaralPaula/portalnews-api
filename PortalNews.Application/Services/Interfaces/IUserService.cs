using LanguageExt;
using PortalNews.Application.DTO.UserDataTransferObject;
using PortalNews.Domain;

namespace PortalNews.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<FindUserDTO> FindAll();
        Option<FindUserDTO> FindById(string id);

        FindUserDTO Save(SaveUserDTO userDTO);

        Option<FindUserDTO> FindByEmail(string email);

    }

}
