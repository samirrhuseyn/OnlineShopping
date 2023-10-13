using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string? Content { get; set; }
        public DateTime CommentDateTime { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public List<Reply>? Reply { get; set; }
    }
}
