namespace SanrooLK.Views.AdminOperations.Views
{
    public class Sale
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal FinalPrice { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }  // Added for customer name
        public int Quantity { get; set; }
        public string RowColor => Quantity % 2 == 0 ? "#FFFFFF" : "#F5F5F5";
    }
}
