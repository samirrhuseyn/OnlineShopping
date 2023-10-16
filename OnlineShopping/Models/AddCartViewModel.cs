namespace OnlineShopping.Models
{
    public class AddCartViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string? UserID { get; set; }
        public int ProductID { get; set; }
    }
}
