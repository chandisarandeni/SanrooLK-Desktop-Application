using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Salary
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("salaryID")]
        public string SalaryID { get; set; }

        [BsonElement("salaryDescription")]
        public string SalaryDescription { get; set; }

        [BsonElement("salaryAmount")]
        public decimal SalaryAmount { get; set; }

        [BsonElement("salaryBonus")]
        public decimal SalaryBonus { get; set; }

        [BsonElement("salaryOverTime")]
        public decimal SalaryOverTime { get; set; }

        [BsonElement("salaryIssuedDate")]
        public DateTime SalaryIssuedDate { get; set; }

        [BsonElement("salaryStatus")]
        public string SalaryStatus { get; set; }

        [BsonElement("employeeID")]
        public string EmployeeID { get; set; }

        [BsonElement("adminID")]
        public string AdminID { get; set; }
    }
}
