using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class StoreMessage
    {
        [Key]
        public int MessageID { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageBody { get; set;}
        public int StoreID { get; set; }
        public Store? Store { get; set; }
        public string? UserID { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
