using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Infratructure.Persistences.Implementations
{
    public class NewsRepository : MongoRepository<News> , INewsRepository 
    {
        public NewsRepository(IConfiguration configuration , IMongoClient mongoClient) : base(configuration , mongoClient)
        {
        }

        public bool ExistByTitle(string title)
        {
            var entity = base._model.Find(news => news.Title == title).FirstOrDefault();
            return entity != null ? false : true;
        }
    }
}
