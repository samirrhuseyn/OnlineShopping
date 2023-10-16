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
    public class CartManager : ICartService
    {

        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public List<Cart> GetListByUserID()
        {
            return _cartDal.GetCartListByUserID();
        }

        public void TAdd(Cart t)
        {
            _cartDal.Insert(t);
        }

        public void TDelete(Cart t)
        {
            _cartDal.Delete(t);
        }

        public Cart TGetByID(int id)
        {
            return _cartDal.GetByID(id);
        }

        public List<Cart> TGetList()
        {
            return _cartDal.GetList();
        }

        public void TUpdate(Cart t)
        {
            _cartDal.Update(t);
        }
    }
}
