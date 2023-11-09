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
    public class EfStoreNotificationDal : GenericRepository<StoreNotification>, IStoreNotificationDal
    {
        public List<StoreNotification> GetListWithUser()
        {
            using(Context context = new Context())
            {
                return context.StoreNotifications
                    .Include(x=>x.User)
                    .OrderByDescending(x=>x.StoreNotificationDate)
                    .ToList();
            }
        }
    }
}
