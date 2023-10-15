namespace OnlineShopping.Models
{
    public class AddReplyToReplyViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserID { get; set; }
        public int ReplyID { get; set; }
        public int ProductId { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}
