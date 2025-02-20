using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class MaintenanceOfficer
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("maintenanceOfficerID")]
        public string MaintenanceOfficerID { get; set; }

        [BsonElement("maintenanceOfficerUsername")]
        public string MaintenanceOfficerUsername { get; set; }

        [BsonElement("maintenanceOfficerPassword")]
        public string MaintenanceOfficerPassword { get; set; }

        [BsonElement("maintenanceOfficerGrantedDate")]
        public DateTime MaintenanceOfficerGrantedDate { get; set; }

        [BsonElement("maintenanceOfficerRevokedDate")]
        public DateTime? MaintenanceOfficerRevokedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
