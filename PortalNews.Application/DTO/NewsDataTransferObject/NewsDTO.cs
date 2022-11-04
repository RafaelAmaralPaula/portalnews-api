using PortalNews.Domain.Enums;

namespace PortalNews.Application.DTO.NewsDataTransferObject
{
    public class NewsDTO
    {
        public string Hat { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string Img { get; set; }
        public string Link { get; set; }
        public Status Status { get; set; }
    }
}
