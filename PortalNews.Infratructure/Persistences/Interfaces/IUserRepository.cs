using LanguageExt;
using PortalNews.Domain;

namespace PortalNews.Infratructure.Persistences.Interfaces
{
    public interface IUserRepository : IMongoRepository<User>
    {

        bool ExistByEmailAndPassword(string email , string password);

        bool ExistByEmail(string email);

        User GetByEmail(string email);

    }
}
