﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void ApplyDisscount(int categoryID, int interest, int storyID)
        {
            _productDal.UpdateByCategoryID(categoryID, interest, storyID);
        }

		public void ApplyDisscountByCode(string productCode, int interest, int storyID)
		{
			_productDal.UpdateByProductCode(productCode, interest, storyID);
		}

		public Product GetByIdWIthCategory(int id)
        {
            return _productDal.GetByIdWithCategory(id);
        }

        public Product GetByProductCode(string productCode)
        {
            return _productDal.GetProductIdByCode(productCode);
        }

        public List<Product> GetListAllWithCategory()
        {
            return _productDal.GetListWithCategoryName();
        }

        public List<Product> GetProductListByStoreID(int id)
        {
            return _productDal.GetProductListByStore(id);
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
