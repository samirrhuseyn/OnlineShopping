namespace OnlineShopping.Models
{
    public class AddComplaintViewModel
    {
        public string? Reason { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public string? SalesCode { get; set; }
        public string? ProductCode { get; set; }
    }
}
