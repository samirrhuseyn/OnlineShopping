using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ReplyToReply
    {
        public int ReplyToReplyID { get; set; }
        public string? ReplyToReplyContent { get; set; }
        public DateTime ReplyToReplyDateTime { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public int ReplyID { get; set; }
        public Reply? Reply { get; set; }
    }
}
