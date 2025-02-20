using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class NewsLetterAndAnnouncements
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("newsID")]
        public string NewsID { get; set; }

        [BsonElement("newsContent")]
        public string NewsContent { get; set; }

        [BsonElement("newsDateOfPublished")]
        public DateTime NewsDateOfPublished { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
