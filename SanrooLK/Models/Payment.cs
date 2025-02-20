using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Payment
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("paymentID")]
        public string PaymentID { get; set; }

        [BsonElement("paymentAmount")]
        public decimal PaymentAmount { get; set; }

        [BsonElement("paymentDate")]
        public DateTime PaymentDate { get; set; }

        [BsonElement("paymentMethod")]
        public string PaymentMethod { get; set; }

        [BsonElement("cashierID")]
        public string CashierID { get; set; }

        [BsonElement("customerID")]
        public string CustomerID { get; set; }

        [BsonElement("checkoutID")]
        public string CheckoutID { get; set; }
    }
}
