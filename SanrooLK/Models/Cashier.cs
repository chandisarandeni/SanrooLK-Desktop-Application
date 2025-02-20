using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Cashier
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("cashierID")]
        public string CashierID { get; set; }

        [BsonElement("cashierUsername")]
        public string CashierUsername { get; set; }

        [BsonElement("cashierPassword")]
        public string CashierPassword { get; set; }

        [BsonElement("cashierGrantedDate")]
        public DateTime CashierGrantedDate { get; set; }

        [BsonElement("cashierRevokedDate")]
        public DateTime? CashierRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
