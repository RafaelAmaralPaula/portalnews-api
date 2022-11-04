using LanguageExt;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;

namespace PortalNews.Infratructure.Persistences.Implementations
{
    public abstract class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        private readonly IMongoClient _mongoClient;

        protected readonly IMongoCollection<T> _model;


        public MongoRepository(IConfiguration configuration , IMongoClient mongoClient)
        {
           _mongoClient = mongoClient;
            var database = _mongoClient.GetDatabase(configuration["Mongo:DataBaseName"]);

            _model = database.GetCollection<T>(typeof(T).Name);
           
        }

         public T Create(T news)
        {
            _model.InsertOne(news);
            return news;

        }

        public List<T> GetAll()
        {
            var news = _model.AsQueryable<T>().ToList();
            return news;
        }

        public Option<T> GetById(string id)
        {
            var news = _model.Find<T>(news => news.Id == id).FirstOrDefault();
            return news;
        }

        public  void Remove(string id)
        {
            _model.DeleteOne(news => news.Id == id);
            
        }

        public  void Update(string id, T newsIn)
        {
            _model.ReplaceOne<T>(news => news.Id == id, newsIn);
            

        }
       
    }
}
