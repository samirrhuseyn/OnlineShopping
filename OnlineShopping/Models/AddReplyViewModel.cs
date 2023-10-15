namespace OnlineShopping.Models
{
    public class AddReplyViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserID { get; set; }
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}
