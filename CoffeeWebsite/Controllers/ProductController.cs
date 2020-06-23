using CoffeeWebsite.Business;
using CoffeeWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace CoffeeWebsite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int productId = 0)
        {
            if (productId == 0)
            {
                return RedirectToAction("Menu", "Home");
            }

            var product = ProductService.Instance.GetProductById(productId);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy ra tất cả sản phẩm thuộc cùng cateogry và loại bỏ sản phẩm hiển thị
            int productCategory = (int)product.ProductCateID;
            var productRelatives = ProductService.Instance.GetProductByCategoryId(productCategory);
            productRelatives.RemoveAll(x => x.ProductID == product.ProductID);

            ViewData["ProductRelatives"] = productRelatives;

            return View(product);
        }

        public ActionResult Ratings(int score, int productId)
        {
            string userName = User.Identity.Name;

            ProductService.Instance.Ratings(score, productId, userName);

            return RedirectToAction("Index", "Product", new { productId = productId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddCart(ProductModel productAddCart)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View();
            }

            productAddCart.UserName = User.Identity.Name;

            List<ProductModel> products = new List<ProductModel>();

            HttpCookie cookie = Request.Cookies.Get("CART");

            if (cookie == null)
            {
                cookie = new HttpCookie("CART");
                products.Add(productAddCart);
            }
            else
            {
                string value = cookie.Value;
                products = JsonConvert.DeserializeObject<List<ProductModel>>(value);

                var isInCartAlready = products.FindIndex(x => x.ProductID == productAddCart.ProductID);

                if (isInCartAlready > -1)
                {
                    products[isInCartAlready].Quantity += 1;
                }
                else
                {
                    products.Add(productAddCart);
                }
            }

            cookie.Value = JsonConvert.SerializeObject(products);
            cookie.Expires = DateTime.Now.AddMinutes(15);

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index","Cart");
        }
    }
}