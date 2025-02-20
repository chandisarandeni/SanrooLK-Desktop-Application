using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Employee
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }

        [BsonElement("employeeName")]
        public string EmployeeName { get; set; }

        [BsonElement("employeeDoB")]
        public DateTime EmployeeDoB { get; set; }

        [BsonElement("employeeEmail")]
        public string EmployeeEmail { get; set; }

        [BsonElement("employeeContact")]
        public string EmployeeContact { get; set; }

        [BsonElement("employeeHireDate")]
        public DateTime EmployeeHireDate { get; set; }

        [BsonElement("employeeResignationDate")]
        public DateTime? EmployeeResignationDate { get; set; }  // Nullable for cases where it's not set

        [BsonElement("isActive")]
        public bool IsActive { get; set; }
    }
}
