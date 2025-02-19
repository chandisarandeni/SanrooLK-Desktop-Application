using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class SystemAdmin
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("adminID")]
        public string AdminID { get; set; }

        [BsonElement("adminUsername")]
        public string AdminUsername { get; set; }

        [BsonElement("adminPassword")]
        public string AdminPassword { get; set; }

        [BsonElement("adminGrantedDate")]
        public DateTime AdminGrantedDate { get; set; }

        [BsonElement("adminRevokedDate")]
        public DateTime? AdminRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
