using CoffeeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Business
{
    public class CategoryService
    {
        private static CategoryService instance;

        public static CategoryService Instance
        {
            get { if (instance == null) instance = new CategoryService(); return instance; }
            private set => instance = value;
        }

        public ProductCategory AddCategory(ProductCategoryModel product)
        {
            throw new NotImplementedException();
        }

        public ProductCategory UpdateCategory(ProductCategoryModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetProductCategories()
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            throw new NotImplementedException();
        }

        public ProductCategory DeleteProductCategory(int productCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}