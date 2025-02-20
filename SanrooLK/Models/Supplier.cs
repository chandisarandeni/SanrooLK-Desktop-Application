using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SanrooLK.Models
{
    public class Supplier
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("supplierID")]
        public string SupplierID { get; set; }

        [BsonElement("supplierName")]
        public string SupplierName { get; set; }

        [BsonElement("supplierAddress")]
        public string SupplierAddress { get; set; }

        [BsonElement("supplierCompanyName")]
        public string SupplierCompanyName { get; set; }

        [BsonElement("supplierCompanyAddress")]
        public string SupplierCompanyAddress { get; set; }

        [BsonElement("supplierContact")]
        public string SupplierContact { get; set; }

        [BsonElement("supplierAdditional")]
        public string SupplierAdditional { get; set; }
    }
}
