using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SanrooLK.Models
{
    public class GRN
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("grnID")]
        public string GrnID { get; set; }

        [BsonElement("unitPrice")]
        public decimal UnitPrice { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("stockManagerID")]
        public string StockManagerID { get; set; }

        [BsonElement("supplierID")]
        public string SupplierID { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
