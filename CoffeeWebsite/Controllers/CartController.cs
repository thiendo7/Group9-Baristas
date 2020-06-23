using CoffeeWebsite.Business;
using CoffeeWebsite.Commons;
using CoffeeWebsite.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CoffeeWebsite.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            CartModel cartModel = new CartModel();

            HttpCookie cookie = Request.Cookies.Get("CART");

            if (cookie == null)
            {
                return RedirectToAction("Menu", "Home");
            }

            cartModel = BuildModel(cookie, cartModel);

            if (cartModel == null)
            {
                return RedirectToAction("Menu", "Home");
            }

            return View(cartModel);
        }

        public CartModel BuildModel(HttpCookie cookie, CartModel cartModel)
        {
            List<ProductModel> productsInCookie = JsonConvert.DeserializeObject<List<ProductModel>>(cookie.Value);

            if (productsInCookie == null || productsInCookie.Count == 0)
            {
                return null;
            }

            cartModel.Account = AccountService.Instance.GetUserByUsername(productsInCookie[0].UserName);
            cartModel.Payments = ShareService.Instance.GetPayments();

            List<CartItemModel> cartItems = new List<CartItemModel>();
            foreach (ProductModel item in productsInCookie)
            {
                CartItemModel cartItem = new CartItemModel
                {
                    Product = ProductService.Instance.ConvertProductModelToProduct(item),
                    Quantity = item.Quantity
                };

                cartItems.Add(cartItem);
            }

            cartModel.CartItems = cartItems;

            double total = 0;
            foreach (var cartItem in cartModel.CartItems)
            {
                var priceProduct = cartItem.Product.HaveSizes.First().Prices.GetValueOrDefault();
                var discountOfProduct = cartItem.Product.Discount.GetValueOrDefault();
                var quantity = cartItem.Quantity;

                total += (double)priceProduct * (1 - discountOfProduct) * quantity;
            }

            cartModel.TotalCart = total;
            cartModel.TotalFinal = total;

            return cartModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(CartModel model)
        {
            HttpCookie cookie = Request.Cookies.Get("CART");

            if (cookie == null)
            {
                return RedirectToAction("Menu", "Home");
            }

            model = BuildModel(cookie, model);

            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View("Index", model);
            }

            if (model.PaymentId == 0)
            {
                ViewBag.Message = "Bạn chưa chọn phương thức thanh toán";

                return View("Index", model);
            }

            ///Nếu true thì thanh toán ngược lại check mã giảm giá
            if (!model.IsSubmit)
            {
                if (model.DiscountCode == null)
                {
                    ViewBag.Message = "Bạn chưa nhập mã giảm giá";

                    return View("Index", model);
                }

                Discount discount = ShareService.Instance.GetDiscountByCode(model.DiscountCode);

                model.TotalDiscountByCode = model.TotalCart * (double)discount.DiscountPercent;
                model.TotalFinal = model.TotalCart - model.TotalDiscountByCode;

               
            }
            else
            {
                CartService.Instance.Payment(model);

                Response.Cookies.Remove("CART");

                return RedirectToAction("Index", "Home");
            }           

            return View("Index", model);
        }

        public ActionResult RemoveItem(int productId)
        {
            HttpCookie cookie = Request.Cookies.Get("CART");

            if (cookie == null)
            {
                return RedirectToAction("Menu", "Home");
            }

            List<ProductModel> productsInCookie = JsonConvert.DeserializeObject<List<ProductModel>>(cookie.Value);

            productsInCookie.RemoveAll(x => x.ProductID == productId);

            cookie.Value = JsonConvert.SerializeObject(productsInCookie);
            cookie.Expires = DateTime.Now.AddMinutes(15);

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Cart");
        }
    }
}