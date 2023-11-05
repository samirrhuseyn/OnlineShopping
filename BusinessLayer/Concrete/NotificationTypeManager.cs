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
    public class NotificationTypeManager : INotificationTypeService
    {
        INotificationTypeDal _notificationTypeDal;

        public NotificationTypeManager(INotificationTypeDal notificationTypeDal)
        {
            _notificationTypeDal = notificationTypeDal;
        }

        public void TAdd(NotificationType t)
        {
            _notificationTypeDal.Insert(t);
        }

        public void TDelete(NotificationType t)
        {
            _notificationTypeDal.Delete(t);
        }

        public NotificationType TGetByID(int id)
        {
            return _notificationTypeDal.GetByID(id);
        }

        public List<NotificationType> TGetList()
        {
            return _notificationTypeDal.GetList();
        }

        public void TUpdate(NotificationType t)
        {
            _notificationTypeDal.Update(t);
        }
    }
}
