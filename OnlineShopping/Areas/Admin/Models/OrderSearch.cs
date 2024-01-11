namespace OnlineShopping.Areas.Admin.Models
{
    public class OrderSearch
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Buyer { get; set; }
        public string? OrderCode { get; set; }
        public int? OrderStatusID { get; set;}

    }
}
