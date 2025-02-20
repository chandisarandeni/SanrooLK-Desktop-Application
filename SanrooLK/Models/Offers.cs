using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Offer
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("offerID")]
        public string OfferID { get; set; }

        [BsonElement("offerDescription")]
        public string OfferDescription { get; set; }

        [BsonElement("offerType")]
        public string OfferType { get; set; }

        [BsonElement("offerStartDate")]
        public DateTime OfferStartDate { get; set; }

        [BsonElement("offerEndDate")]
        public DateTime OfferEndDate { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
