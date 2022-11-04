using LanguageExt;
using PortalNews.Application.DTO.NewsDataTransferObject;

namespace PortalNews.Application.Services.Interfaces
{
    public interface INewsService
    {

        List<FindNewsDTO> FindAll();

        Option<FindNewsDTO> FindById(string id);

        FindNewsDTO Save(NewsDTO newsDTO);

        void Update(string id , NewsDTO news);

        void Delete(string id);

    }
}