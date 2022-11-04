﻿using MongoDB.Bson.Serialization.Attributes;

namespace PortalNews.Domain
{
    public class Role : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        public Role() { }

        public Role(string name)
        {
            Name = name;
        }

    }
}
