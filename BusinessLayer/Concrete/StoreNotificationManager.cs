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
    public class StoreNotificationManager : IStoreNotificationService
    {
        IStoreNotificationDal _storeNotificationDal;

        public StoreNotificationManager(IStoreNotificationDal storeNotificationDal)
        {
            _storeNotificationDal = storeNotificationDal;
        }

        public List<StoreNotification> GetListWithUser()
        {
            return _storeNotificationDal.GetListWithUser();
        }

        public void TAdd(StoreNotification t)
        {
            _storeNotificationDal.Insert(t);
        }

        public void TDelete(StoreNotification t)
        {
            _storeNotificationDal.Delete(t);
        }

        public StoreNotification TGetByID(int id)
        {
            return _storeNotificationDal.GetByID(id);
        }

        public List<StoreNotification> TGetList()
        {
            return _storeNotificationDal.GetList();
        }

        public void TUpdate(StoreNotification t)
        {
            _storeNotificationDal.Update(t);
        }
    }
}
