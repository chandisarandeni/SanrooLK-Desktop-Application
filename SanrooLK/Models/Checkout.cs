using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SanrooLK.Models
{
    public class Checkout
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB auto-generated ID

        [BsonElement("checkoutID")]
        public string CheckoutID { get; set; }

        [BsonElement("checkoutDate")]
        public DateTime CheckoutDate { get; set; }

        [BsonElement("unitTotal")]
        public decimal UnitTotal { get; set; }

        [BsonElement("discountPrice")]
        public decimal DiscountPrice { get; set; }

        [BsonElement("finalPrice")]
        public decimal FinalPrice { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }
    }
}
