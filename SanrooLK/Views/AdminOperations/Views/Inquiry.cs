using System;

namespace SanrooLK.Views.AdminOperations.Views
{
    public class Inquiry
    {
        public string InquiryID { get; set; }
        public string InquiryDescription { get; set; }
        public DateTime InquiryDate { get; set; }
        public string InquiryStatus { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public string SalesManagerID { get; set; }
        public int Quantity { get; set; }

        // Optional: Constructor to initialize the Inquiry
        public Inquiry(string inquiryID, string inquiryDescription, DateTime inquiryDate, string inquiryStatus, string customerID, string productID, string salesManagerID, int quantity)
        {
            InquiryID = inquiryID;
            InquiryDescription = inquiryDescription;
            InquiryDate = inquiryDate;
            InquiryStatus = inquiryStatus;
            CustomerID = customerID;
            ProductID = productID;
            SalesManagerID = salesManagerID;
            Quantity = quantity;
        }
    }
}
