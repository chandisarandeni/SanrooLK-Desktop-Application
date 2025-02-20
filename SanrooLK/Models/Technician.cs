using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Technician
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("technicianID")]
        public string TechnicianID { get; set; }

        [BsonElement("technicianUsername")]
        public string TechnicianUsername { get; set; }

        [BsonElement("technicianPassword")]
        public string TechnicianPassword { get; set; }

        [BsonElement("technicianGrantedDate")]
        public DateTime TechnicianGrantedDate { get; set; }

        [BsonElement("technicianRevokedDate")]
        public DateTime? TechnicianRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
