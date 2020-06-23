using CoffeeWebsite.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeWebsite.Business
{
    public class ShareService
    {
        private static ShareService instance;

        public static ShareService Instance
        {
            get { if (instance == null) instance = new ShareService(); return instance; }
            private set => instance = value;
        }

        public BookingTable AddBooking(BookingTableModel model)
        {
            BookingTable booking = new BookingTable
            {
                BookingDate = model.BookingDate,
                BookingTime = model.BookingTime,
                CustomerName = model.CustomerName,
                IsActive = true,
                NumberCustomer = model.NumberCustomer,
                Phone = model.Phone
            };

            using(var db = new BaristasEntities())
            {
                db.BookingTables.Add(booking);

                if (db.SaveChanges() > 0)
                {
                    return booking;
                }
            }

            return null;
        }

        public FeedBack AddFeedBack(FeedBackModel model)
        {
            FeedBack feedBack = new FeedBack
            {
                Age = model.Age,
                Another = model.Another,
                Email = model.Email,
                CustomerName = model.CustomerName,
                Job = model.Job
            };

            using (var db = new BaristasEntities())
            {
                db.FeedBacks.Add(feedBack);

                if (db.SaveChanges() > 0)
                {
                    return feedBack;
                }
            }

            return null;
        }

        public List<News> GetNews()
        {
            using(var db = new BaristasEntities())
            {
                return db.News
                    .Where(x => x.IsActive == true)
                    .ToList();
            }
        }

        public List<News> GetNewsByCategory(int newCategoryId)
        {
            using (var db = new BaristasEntities())
            {
                var news = db.News
                    .Where(x => x.NewsCateID == newCategoryId && x.IsActive == true)
                    .ToList();

                foreach(var item in news)
                {
                    item.NewsCategory = db.NewsCategories.Find(item.NewsCateID);
                    item.TagsNews = db.TagsNews.Where(x => x.NewsID == item.NewsID).ToList();
                }

                return news;
            }
        }

        public List<NewsCategory> GetNewsCategories()
        {
            using (var db = new BaristasEntities())
            {
                var categories = db.NewsCategories
                    .Where(x => x.IsActive == true)
                    .ToList();

                foreach(var category in categories)
                {
                    category.News = db.News
                        .Where(x => x.NewsCateID == category.NewsCateID && x.IsActive == true)
                        .ToList();
                }

                return categories;
            }
        }

        public List<Tag> GetTags()
        {
            using(var db = new BaristasEntities())
            {
                return db.Tags.ToList();
            }
        }

        public Discount GetDiscountByCode(string discountCode)
        {
            using(var db = new BaristasEntities())
            {
                return db.Discounts.FirstOrDefault(x => x.DiscountCode == discountCode);
            }
        }

        public List<Payment> GetPayments()
        {
            using (var db = new BaristasEntities())
            {
                return db.Payments.ToList();
            }
        }

        public Tag GetTagsByTagName(string searchTag)
        {
            using (var db = new BaristasEntities())
            {
                return db.Tags.FirstOrDefault(x => x.TagsName == searchTag);
            }
        }

        public News GetNewsDetailById(int newId)
        {
            using (var db = new BaristasEntities())
            {
                return db.News.FirstOrDefault(x => x.NewsID == newId);
            }
        }
    }
}