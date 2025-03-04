using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Views.AdminOperations.Models
{
    public class Inquiry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

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

        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
