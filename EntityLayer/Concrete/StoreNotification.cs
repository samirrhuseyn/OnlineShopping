using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class StoreNotification
    {
        [Key]
        public int StoreNotificationId { get; set; }
        public string? StoreNotificationTitle { get; set; }
        public DateTime? StoreNotificationDate { get; set; }
        public string? StoreNotificationContent { get; set; }
        public int StoreID { get; set; }
        public Store? Store { get; set; }
        public string? UserID { get; set; }
        public AppUser? User { get; set; }
        public bool IsRead { get; set; }
        public int ProductID { get; set; }

    }
}
