using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSaleDal : GenericRepository<Sale>, ISaleDal
    {
        public Sale GetById(string id)
        {
            using(Context context = new Context())
            {
                return context.Set<Sale>().Find(id);
            }
        }
    }
}
