using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Invoice
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("invoiceID")]
        public string InvoiceID { get; set; }

        [BsonElement("invoiceDate")]
        public DateTime InvoiceDate { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
