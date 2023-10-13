using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        public string? ReplyContent { get; set; }
        public int CommentID { get; set; }
        public Comment? Comment { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }

    }
}
