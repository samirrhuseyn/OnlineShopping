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
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public Sale GetByID(string id)
        {
            return _saleDal.GetById(id);
        }

        public void TAdd(Sale t)
        {
            _saleDal.Insert(t);
        }

        public void TDelete(Sale t)
        {
            _saleDal.Delete(t);
        }

        public Sale TGetByID(int id)
        {
            throw new NotImplementedException();
            
        }

        public List<Sale> TGetList()
        {
            return _saleDal.GetList();
        }

        public void TUpdate(Sale t)
        {
            _saleDal.Update(t);
        }
    }
}
