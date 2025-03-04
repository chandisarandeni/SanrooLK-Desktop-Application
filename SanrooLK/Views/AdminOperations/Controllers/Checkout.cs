namespace SanrooLK.Views.AdminOperations.Controllers
{
    public class Checkout
    {
        public string CheckoutID { get; set; }
        public string CheckoutDate { get; set; }
        public double UnitTotal { get; set; }
        public double DiscountPrice { get; set; }
        public double FinalPrice { get; set; }
    }
}
