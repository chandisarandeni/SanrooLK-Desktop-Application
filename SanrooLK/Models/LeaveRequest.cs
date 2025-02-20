using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class LeaveRequest
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("leaveRequestID")]
        public string LeaveRequestID { get; set; }

        [BsonElement("Reason")]
        public string Reason { get; set; }

        [BsonElement("StartDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("EndDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("leaveRequestStatus")]
        public string LeaveRequestStatus { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }

        [BsonElement("adminID")]
        public string AdminID { get; set; }
    }
}
