using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeWebsite.Models;

namespace CoffeeWebsite.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsCategoriesController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/NewsCategories
        public ActionResult Index()
        {
            return View(db.NewsCategories.ToList());
        }

        // GET: Admin/NewsCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NewsCategory newsCategory = db.NewsCategories.Find(id);

            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // GET: Admin/NewsCategories/Create
        public ActionResult Create()
        {
            return View(new NewsCategory());
        }

        // POST: Admin/NewsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsCateID,NewsCateName,IsActive")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                newsCategory.ModifyBy = User.Identity.Name;
                newsCategory.ModifyDate = DateTime.Now;
                newsCategory.CreatedBy = User.Identity.Name;
                newsCategory.CreatedDate = DateTime.Now;

                db.NewsCategories.Add(newsCategory);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(newsCategory);
        }

        // GET: Admin/NewsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NewsCategory newsCategory = db.NewsCategories.Find(id);

            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // POST: Admin/NewsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsCateID,NewsCateName,IsActive")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                NewsCategory newsCate = db.NewsCategories.Find(newsCategory.NewsCateID);

                newsCate.NewsCateName = newsCategory.NewsCateName;
                newsCate.IsActive = newsCate.IsActive;
                newsCate.ModifyBy = User.Identity.Name;
                newsCate.ModifyDate = DateTime.Now;

                db.Entry(newsCate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsCategory);
        }

        // GET: Admin/NewsCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            NewsCategory newsCategory = db.NewsCategories.Find(id);

            if (newsCategory == null)
            {
                return HttpNotFound();
            }
            return View(newsCategory);
        }

        // POST: Admin/NewsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsCategory newsCategory = db.NewsCategories.Find(id);

            newsCategory.IsActive = false;
            newsCategory.ModifyBy = User.Identity.Name;
            newsCategory.ModifyDate = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
