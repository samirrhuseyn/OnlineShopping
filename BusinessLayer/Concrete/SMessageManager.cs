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
    public class SMessageManager : ISMessageService
    {
        ISMessageDal _sMessageDal;

        public SMessageManager(ISMessageDal sMessageDal)
        {
            _sMessageDal = sMessageDal;
        }

        public List<StoreMessage> GetListStoreMessages()
        {
            return _sMessageDal.GetListMessage();
        }

        public StoreMessage GetMessage(int id)
        {
            return _sMessageDal.GetMessageWithUser(id);
        }

        public void TAdd(StoreMessage t)
        {
            _sMessageDal.Insert(t);
        }

        public void TDelete(StoreMessage t)
        {
            _sMessageDal.Delete(t);
        }

        public StoreMessage TGetByID(int id)
        {
            return _sMessageDal.GetByID(id);
        }

        public List<StoreMessage> TGetList()
        {
            return _sMessageDal.GetList();
        }

        public void TUpdate(StoreMessage t)
        {
            _sMessageDal.Update(t);
        }
    }
}
