using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Feedback
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("feedbackID")]
        public string FeedbackID { get; set; }

        [BsonElement("feedbackType")]
        public string FeedbackType { get; set; }

        [BsonElement("feedbackDescription")]
        public string FeedbackDescription { get; set; }

        [BsonElement("feedbackStatus")]
        public string FeedbackStatus { get; set; }

        [BsonElement("feedbackDate")]
        public DateTime FeedbackDate { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
