using LanguageExt;


namespace PortalNews.Infratructure.Persistences.Interfaces
{
    public interface IMongoRepository<T>
    {
        List<T> GetAll();
       
        Option<T> GetById(string id);
        
        T Create(T news);
        
        void Update(string id, T newsIn);
        
        void Remove(string id);

        

    }
}
