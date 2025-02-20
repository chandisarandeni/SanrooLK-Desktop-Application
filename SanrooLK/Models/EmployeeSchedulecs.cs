using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class EmployeeSchedule
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("scheduleID")]
        public string ScheduleID { get; set; }

        [BsonElement("scheduleDate")]
        public DateTime ScheduleDate { get; set; }

        [BsonElement("scheduleDetails")]
        public string ScheduleDetails { get; set; }

        [BsonElement("scheduleDescription")]
        public string ScheduleDescription { get; set; }

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
