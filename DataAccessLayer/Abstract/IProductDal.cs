using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetListWithCategoryName();
        Product GetByIdWithCategory(int id);
        List<Product> GetProductListByStore(int ID);
        void UpdateByCategoryID(int categoryID, int interest, int storyID);
        void UpdateByProductCode(string productCode, int interest, int storyID);
    }
}
