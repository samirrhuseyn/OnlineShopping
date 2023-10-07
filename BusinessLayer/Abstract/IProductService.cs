using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetListAllWithCategory();
        Product GetByIdWIthCategory(int id);
        List<Product> GetProductListByStoreID(int id);
        void ApplyDisscount(int categoryID, int interest);
        void ApplyDisscountByCode(string productCode, int interest);
    }
}
