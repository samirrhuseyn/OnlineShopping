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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public Product GetByIdWithCategory(int id)
        {
            using(var context = new Context())
            {
                return context.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.ProductID == id);
            }
        }

        public List<Product> GetListWithCategoryName()
        {
            using (var context = new Context())
            {
                return context.Products
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();
            }
        }
    }
}
