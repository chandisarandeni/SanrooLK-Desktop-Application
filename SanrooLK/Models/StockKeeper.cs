using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class StockKeeper
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("stockKeeperID")]
        public string StockKeeperID { get; set; }

        [BsonElement("stockKeeperUsername")]
        public string StockKeeperUsername { get; set; }

        [BsonElement("stockKeeperPassword")]
        public string StockKeeperPassword { get; set; }

        [BsonElement("stockKeeperGrantedDate")]
        public DateTime StockKeeperGrantedDate { get; set; }

        [BsonElement("stockKeeperRevokedDate")]
        public DateTime? StockKeeperRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
