namespace OnlineShopping.Models
{
    public class AddCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime CommentDateTime { get; set; }
    }
}
