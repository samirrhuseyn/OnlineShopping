namespace OnlineShopping.Areas.Admin.Models
{
    public class AddNotificationByID
    {
        public string? NotificationTitle { get; set; }
        public string? NotificationContent { get; set; }
        public DateTime? NotificationDate { get; set; }
        public int NotificationTypeTypeID { get; set; }
        public string UserID { get; set; }

    }
}
