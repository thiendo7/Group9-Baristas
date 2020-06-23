using CoffeeWebsite.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeWebsite.Business
{
    public class ProductService
    {
        private static ProductService instance;

        public static ProductService Instance
        {
            get { if (instance == null) instance = new ProductService(); return instance; }
            private set => instance = value;
        }

        public List<ProductCategory> GetAllProductCategory()
        {
            using (var db = new BaristasEntities())
            {
                return db.ProductCategories
                    .Where(x => x.IsActive == true)
                    .ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using(var db = new BaristasEntities())
            {
                var product = db.Products
                    .FirstOrDefault(x => x.ProductID == productId && x.IsActive == true);

                //GetSizes
                product.HaveSizes = db.HaveSizes
                    .Where(x => x.ProductID == product.ProductID)
                    .ToList();

                //GetSizeDetail
                foreach(var item in product.HaveSizes)
                {
                    item.ProductSize = db.ProductSizes.FirstOrDefault(x => x.ProductSizeID == item.ProductSizeID);
                }

                return product;
            }
        }

        public void Ratings(int score, int productId, string userName)
        {
            using(var db = new BaristasEntities())
            {
                Account user = AccountService.Instance.GetUserByUsername(userName);

                Rating rating = new Rating
                {
                    AccountID = user.AccountID,
                    NumberStar = (double)score,
                    ProductID = productId
                };

                db.Ratings.Add(rating);
                db.SaveChanges();
            }
        }

        public List<Product> GetAllProduct()
        {
            using (var db = new BaristasEntities())
            {
                return db.Products.Include("ProductCategory")
                    .Where(x =>  x.IsActive == true)
                    .ToList();
            }
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            using(var db = new BaristasEntities())
            {
                /// Get Product by category
                var products = db.Products
                    .Where(x => x.ProductCateID == categoryId && x.IsActive == true)
                    .ToList();

                foreach(var product in products)
                {
                    /// Get Price
                    product.HaveSizes = db.HaveSizes
                        .Where(x => x.ProductID == product.ProductID)
                        .OrderBy(x => x.Prices)
                        .ToList();

                    /// Get Rating Product
                    product.Ratings = db.Ratings
                        .Where(x => x.ProductID == product.ProductID)
                        .ToList();
                }
                return products;
            }
        }

        public Product ConvertProductModelToProduct(ProductModel productInCookie)
        {
            using(var db = new BaristasEntities())
            {
                Product item = db.Products.FirstOrDefault(x => x.ProductID == productInCookie.ProductID && x.IsActive == true);

                /// Nếu không tìm thấy sản phẩm trong db thì tiếp tục
                if (item == null) return null;

                /// Get Category Product
                item.ProductCategory = db.ProductCategories
                    .FirstOrDefault(x => x.ProductCateID == productInCookie.ProductCateID && x.IsActive == true);

                /// Get All Size Product
                item.HaveSizes = db.HaveSizes
                    .Where(x => x.ProductID == productInCookie.ProductID)
                    .ToList();

                /// Chỉ lấy Size được chọn trong Cart
                item.HaveSizes = item.HaveSizes.Where(x => x.ProductSizeID == productInCookie.ProductSizeId).ToList();

                return item;
            }
        }
    }
}