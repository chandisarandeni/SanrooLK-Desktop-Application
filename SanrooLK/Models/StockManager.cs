using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class StockManager
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("stockManagerID")]
        public string StockManagerID { get; set; }

        [BsonElement("stockManagerUsername")]
        public string StockManagerUsername { get; set; }

        [BsonElement("stockManagerPassword")]
        public string StockManagerPassword { get; set; }

        [BsonElement("stockManagerGrantedDate")]
        public DateTime StockManagerGrantedDate { get; set; }

        [BsonElement("stockManagerRevokedDate")]
        public DateTime? StockManagerRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
