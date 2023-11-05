using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        

        public List<Notification> GetListWihType(string id)
        {
            return _notificationDal.NotificationListWithType(id);
        }

        public void TAdd(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public Notification TGetByID(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public List<Notification> TGetList()
        {
            return _notificationDal.GetList();
        }

        public void TUpdate(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}
