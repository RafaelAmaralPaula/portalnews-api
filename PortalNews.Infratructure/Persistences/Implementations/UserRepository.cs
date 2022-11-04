using LanguageExt;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;
using PortalNews.Util.SecureIdentity;

namespace PortalNews.Infratructure.Persistences.Implementations
{
    public class UserRepository : MongoRepository<User> , IUserRepository
    {
        public UserRepository(IConfiguration configuration , IMongoClient mongoClient) : base(configuration , mongoClient)
        {
        }

        public User GetByEmail(string email)
        {
            var find = base._model.Find(user => user.Email == email).FirstOrDefault();
            return find;
        }

        public bool ExistByEmail(string email)
        {

            var emailFind = base._model.Find(user => user.Email == email).FirstOrDefault();
            return emailFind != null ? false : true;
        }

        public bool ExistByEmailAndPassword(string email , string password)
        {
            
            var find = base._model.Find(user => user.Email == email).FirstOrDefault();
            bool emailFind = find == null ? false : true;

            return emailFind == true ? PasswordHashedUtil.Compare(find.PasswordHash, password) : false;
        }
    }
}
