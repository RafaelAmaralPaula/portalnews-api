using PortalNews.Domain;

namespace PortalNews.Infratructure.Persistences.Interfaces
{
    public interface INewsRepository : IMongoRepository<News>
    {

        bool ExistByTitle(string title);

    }
}
