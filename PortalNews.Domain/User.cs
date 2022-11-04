using MongoDB.Bson.Serialization.Attributes;

namespace PortalNews.Domain
{
    public class User : BaseEntity
    {

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password_hash")]
        public string PasswordHash { get; set; }

        [BsonElement("role_id")]
        public string RoleId { get;  set; }

  
    }
}
