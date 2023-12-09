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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public List<Order> GetOrdersByUser()
        {
            using(Context context = new Context())
            {
                return context.Orders
                    .Include(x=>x.OrderStatus)
                    .Include(x=>x.Adress)
                    .Include(x=>x.Product)
                    .Include(x=>x.User)
                    .OrderByDescending(x=>x.OrderDateTime)
                    .ToList();
            }
        }

        Order IOrderDal.GetOrderById(int id)
        {
            using (Context context = new Context())
            {
                return context.Orders
                    .Include(x => x.Product)
                    .FirstOrDefault(x => x.OrderId == id);
            }
        }
    }
}
