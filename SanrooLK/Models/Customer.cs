using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("customerName")]
        public string CustomerName { get; set; }

        [BsonElement("customerDoB")]
        public DateTime CustomerDoB { get; set; }

        [BsonElement("customerNIC")]
        public string CustomerNIC { get; set; }

        [BsonElement("customerAddress")]
        public string CustomerAddress { get; set; }

        [BsonElement("customerContact")]
        public string CustomerContact { get; set; }

        [BsonElement("customerEmail")]
        public string CustomerEmail { get; set; }

        [BsonElement("customerPassword")]
        public string CustomerPassword { get; set; }

        [BsonElement("registrationDate")]
        public DateTime RegistrationDate { get; set; }
    }
}
