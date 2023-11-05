using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public List<Notification> NotificationListWithType(string id)
        {
            using (Context context = new Context())
            {
                return context.Notifications
                    .Include(x => x.NotificationType)
                    .Where(x => x.UserID == id)
                    .OrderByDescending(x => x.NotificationDate)
                    .ToList();
            }
        }
    }
}
