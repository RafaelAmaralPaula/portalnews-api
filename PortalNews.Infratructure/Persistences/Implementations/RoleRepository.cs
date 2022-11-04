using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Infratructure.Persistences.Implementations
{
    public class RoleRepository : MongoRepository<Role> , IRoleRepository
    {
        public RoleRepository(IConfiguration configuration, IMongoClient mongoClient) : base(configuration , mongoClient)
        {
        }
    }
}
