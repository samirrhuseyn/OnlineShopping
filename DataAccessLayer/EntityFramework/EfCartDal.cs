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
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        public List<Cart> GetCartListByUserID()
        {
            using (Context context = new Context())
            {
                return context.Cart
                    .Include(x => x.Product)
                    .OrderByDescending(x => x.AddDateTime)
                    .ToList();
            }
        }
    }
}
