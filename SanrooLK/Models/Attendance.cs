using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Attendance
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("attendanceID")]
        public string AttendanceID { get; set; }

        [BsonElement("attendanceDate")]
        public DateTime AttendanceDate { get; set; }

        [BsonElement("attendanceTimeIn")]
        public DateTime AttendanceTimeIn { get; set; }

        [BsonElement("attendanceTimeOut")]
        public DateTime AttendanceTimeOut { get; set; }

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }
    }
}
