using AutoMapper;
using LanguageExt;
using PortalNews.Application.DTO.NewsDataTransferObject;
using PortalNews.Application.Exceptions;
using PortalNews.Application.Services.Interfaces;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;


namespace PortalNews.Application.Services.Implementations
{
    public class NewsService : INewsService
    {

        private readonly IMapper _mapper;

        private readonly INewsRepository _news;

        public NewsService(IMapper mapper , INewsRepository news)
        {
            _mapper = mapper;
            _news = news;
        }

        public List<FindNewsDTO> FindAll()
        {
            return _mapper.Map<List<FindNewsDTO>>(_news.GetAll().ToList());
        }

        public Option<FindNewsDTO> FindById(string id)
        {
            var result = _news.GetById(id);
            return result.Match(Some: entity => _mapper.Map<FindNewsDTO>(entity) ,
                               None: () => throw new ResourceNotFoundException("Resource not found"));
           
        }

        public FindNewsDTO Save(NewsDTO newsDTO)
        {
            var entity = _mapper.Map<News>(newsDTO);
            return _mapper.Map< FindNewsDTO>(_news.Create(entity));
        }
       

        public void Update(string id, NewsDTO newsDTO)
        {
            FindById(id);
            var entity = _mapper.Map<News>(newsDTO);
            entity.Id = id;
         
            _news.Update(entity.Id, entity);
        }

        public void Delete(string id)
        {
            FindById(id);
            _news.Remove(id);
        }

     

    }
}
