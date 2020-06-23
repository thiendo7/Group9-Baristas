using CoffeeWebsite.Business;
using CoffeeWebsite.Commons;
using CoffeeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CoffeeWebsite.Controllers
{
    /// <summary>
    /// documents: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-3.1
    /// </summary>
    public class HomeController : Controller
    {
        public const int pageSize = 3;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking(BookingTableModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View();
            }

            BookingTable booking = ShareService.Instance.AddBooking(model);

            if (booking != null)
            {
                ViewBag.SuccessMessage = "Cám ơn bạn đã sử dụng dịch vụ của chúng tôi.";
                return View();
            }

            ViewBag.Message = "Đã có lỗi xảy ra! Xin vui lòng thử lại";
            return View();
        }

        [HttpGet]
        public ActionResult FeedBack()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeedBack(FeedBackModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View();
            }

            FeedBack feedBack = ShareService.Instance.AddFeedBack(model);

            if (feedBack != null)
            {
                ViewBag.SuccessMessage = "Cám ơn bạn đã sử dụng dịch vụ của chúng tôi.";
                return View();
            }

            ViewBag.Message = "Đã có lỗi xảy ra! Xin vui lòng thử lại";
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult News(int? searchCategory, int? currentFilter, string sortOrder = "date_desc", int pageIndex = 1)
        {    
            if (searchCategory != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchCategory = currentFilter;
            }

            var tags = ShareService.Instance.GetTags();
            var newCategories = ShareService.Instance.GetNewsCategories();

            if (searchCategory == null)
            {
                searchCategory = newCategories[0].NewsCateID;
            }
       
            var news = ShareService.Instance.GetNewsByCategory(searchCategory.GetValueOrDefault());

            switch (sortOrder)
            {
                case "date_asc":
                    news = news.OrderBy(s => s.CreatedDate).ToList();
                    break;
                case "date_desc":
                    news = news.OrderByDescending(s => s.CreatedDate).ToList();
                    break;
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentCategory"] = searchCategory;
            ViewData["PageIndex"] = pageIndex;
            ViewData["NewCategories"] = newCategories;
            ViewData["Tags"] = tags;

            var pageListNew = PaginatedList<News>.CreateAsync(news, pageIndex, pageSize);

            return View(pageListNew);
        }

        [HttpGet]
        public ActionResult NewsDetail(int newId = 0)
        {
            if (newId == 0)
            {
                return RedirectToAction("News", "Home");
            }

            var newsDetail = ShareService.Instance.GetNewsDetailById(newId);

            if (newsDetail == null)
            {
                return RedirectToAction("News", "Home");
            }

            var tags = ShareService.Instance.GetTags();
            var newCategories = ShareService.Instance.GetNewsCategories();
         
            // Lấy ra tất cả tin tức thuộc cùng cateogry và loại bỏ tin tức đang hiển thị
            int newCategory = (int)newsDetail.NewsCateID;
            var newRelatives = ShareService.Instance.GetNewsByCategory(newCategory);
            newRelatives.RemoveAll(x => x.NewsID == newsDetail.NewsID);

            ViewData["NewRelatives"] = newRelatives;
            ViewData["NewCategories"] = newCategories;
            ViewData["Tags"] = tags;
            return View(newsDetail);
        }

        [HttpGet]
        public ActionResult Menu(int? searchCategory, int? currentFilter, string sortOrder = "date_desc", int pageIndex = 1)
        {
            if (searchCategory != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchCategory = currentFilter;
            }

            var productCategories = ProductService.Instance.GetAllProductCategory();

            if (searchCategory == null)
            {
                searchCategory = productCategories[0].ProductCateID;
            }

            var products = ProductService.Instance.GetProductByCategoryId(searchCategory.GetValueOrDefault());

            switch (sortOrder)
            {
                case "price_desc":
                    products = products.OrderByDescending(s => s.HaveSizes.ElementAt(0).Prices).ToList();
                    break;
                case "date_asc":
                    products = products.OrderBy(s => s.CreatedDate).ToList();
                    break;
                case "date_desc":
                    products = products.OrderByDescending(s => s.CreatedDate).ToList();
                    break;
                case "price_asc":
                    products = products.OrderBy(s => s.HaveSizes.ElementAt(0).Prices).ToList();
                    break;
            }

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentCategory"] = searchCategory;
            ViewData["PageIndex"] = pageIndex;
            ViewData["ProductCategories"] = productCategories;
            ViewData["SelectedCategory"] = searchCategory;

            var pageListProduct = PaginatedList<Product>.CreateAsync(products, pageIndex, pageSize);

            return View(pageListProduct);
        }
    }
}