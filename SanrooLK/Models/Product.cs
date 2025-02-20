using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SanrooLK.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("productID")]
        public string ProductID { get; set; }

        [BsonElement("productName")]
        public string ProductName { get; set; }

        [BsonElement("productCategory")]
        public string ProductCategory { get; set; }

        [BsonElement("productSKU")]
        public string ProductSKU { get; set; }

        [BsonElement("productBrand")]
        public string ProductBrand { get; set; }

        [BsonElement("productPrice")]
        public decimal ProductPrice { get; set; }

        [BsonElement("productQuantity")]
        public int ProductQuantity { get; set; }

        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }

        [BsonElement("stockManagerID")]
        public string StockManagerID { get; set; }

        [BsonElement("stockKeeperID")]
        public string StockKeeperID { get; set; }

        [BsonElement("supplierID")]
        public string SupplierID { get; set; }
    }
}
