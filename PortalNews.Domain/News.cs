using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PortalNews.Domain.Enums;

namespace PortalNews.Domain
{
    public class News : BaseEntity
    {
        public News(string hat, string title, string text, string author, string img, string link, Status status)
        {
            Hat = hat;
            Title = title;
            Text = text;
            Author = author;
            Img = img;
            Link = link;
            PublishDate = DateTime.Now;
            Status = status;
        }

        [BsonElement("hat")]
        public string Hat { get;  set; }

        [BsonElement("title")]
        public string Title { get;  set; }

        [BsonElement("text")]
        public string Text { get;  set; }

        [BsonElement("author")]
        public string Author { get;  set; }

        [BsonElement("img")]
        public string Img { get;  set; }

        [BsonElement("link")]
        public string Link { get;  set; }

        [BsonElement("publish_date")]
        public DateTime PublishDate { get;  set; }

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public Status Status { get;  set; }

    }
}
