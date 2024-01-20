namespace OnlineShopping.Areas.Seller.Models
{
    public class OrderSearch
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? OrderCode { get; set; }
    }
}
