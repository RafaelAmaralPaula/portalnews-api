using LanguageExt;
using PortalNews.Application.DTO.RoleDataTransferObject;

namespace PortalNews.Application.Services.Interfaces
{
    public interface IRoleService
    {

        List<RoleDTO> FindAll();

        Option<RoleDTO> FindById(string id);

    }
}
