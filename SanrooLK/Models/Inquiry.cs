using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Inquiry
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("inquiryID")]
        public string InquiryID { get; set; }

        [BsonElement("inquiryDescription")]
        public string InquiryDescription { get; set; }

        [BsonElement("inquiryDate")]
        public DateTime InquiryDate { get; set; }

        [BsonElement("inquiryStatus")]
        public string InquiryStatus { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }

        [BsonElement("salesManagerID")]
        public string SalesManagerID { get; set; }
    }
}
