using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class SalesManager
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("salesManagerID")]
        public string SalesManagerID { get; set; }

        [BsonElement("salesManagerUsername")]
        public string SalesManagerUsername { get; set; }

        [BsonElement("salesManagerPassword")]
        public string SalesManagerPassword { get; set; }

        [BsonElement("salesManagerGrantedDate")]
        public DateTime SalesManagerGrantedDate { get; set; }

        [BsonElement("salesManagerRevokedDate")]
        public DateTime? SalesManagerRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
