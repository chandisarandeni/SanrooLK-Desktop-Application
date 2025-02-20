using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SanrooLK.Models
{
    public class StockAlert
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("stockAlertID")]
        public string StockAlertID { get; set; }

        [BsonElement("stockAlertMessage")]
        public string StockAlertMessage { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
