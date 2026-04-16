namespace WinFormsApp4
{
    public class SaleRecord
    {
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Details { get; set; }

        public SaleRecord(int saleNumber, DateTime saleDate, int itemCount, decimal totalAmount, string details)
        {
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            ItemCount = itemCount;
            TotalAmount = totalAmount;
            Details = details;
        }
    }
}
