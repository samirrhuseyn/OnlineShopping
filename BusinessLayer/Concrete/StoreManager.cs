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
    public class StoreManager : IStoreService
    {
        IStoreDal _storeDal;

        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }

        public void TAdd(Store t)
        {
            _storeDal.Insert(t);
        }

        public void TDelete(Store t)
        {
            _storeDal.Delete(t);
        }

        public Store TGetByID(int id)
        {
            return _storeDal.GetByID(id);
        }

        public List<Store> TGetList()
        {
            return _storeDal.GetList();
        }

        public void TUpdate(Store t)
        {
            _storeDal.Update(t);
        }
    }
}
