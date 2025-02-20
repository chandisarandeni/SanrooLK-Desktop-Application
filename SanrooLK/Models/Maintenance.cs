using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Maintenance
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("maintenanceID")]
        public string MaintenanceID { get; set; }

        [BsonElement("maintenanceDescription")]
        public string MaintenanceDescription { get; set; }

        [BsonElement("maintenanceStatus")]
        public string MaintenanceStatus { get; set; }

        [BsonElement("scheduledDate")]
        public DateTime ScheduledDate { get; set; }

        [BsonElement("completedDate")]
        public DateTime? CompletedDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("maintenanceUpgrades")]
        public string MaintenanceUpgrades { get; set; }

        [BsonElement("maintenanceCost")]
        public decimal MaintenanceCost { get; set; }

        [BsonElement("technicianID")]
        public string TechnicianID { get; set; }

        [BsonElement("maintenanceOfficerID")]
        public string MaintenanceOfficerID { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }
    }
}
