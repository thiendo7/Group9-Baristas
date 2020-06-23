using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeWebsite.Models;

namespace CoffeeWebsite.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.NewsCategory);
            return View(news.ToList());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = db.News.Include(n => n.NewsCategory).SingleOrDefault(x => x.NewsID == id);

            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.NewsCateID = new SelectList(db.NewsCategories, "NewsCateID", "NewsCateName");
            return View(new News());
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsID,NewsCateID,NewsName,UploadFile,Content,Image,IsActive")] News news)
        {
            string pathSaveToDb = string.Empty;

            if (news.UploadFile != null)
            {
                string fileName = Path.GetFileName(news.UploadFile.FileName);

                string path = Server.MapPath("~/Assets/Uploads");

                news.UploadFile.SaveAs(Path.Combine(path, fileName));

                pathSaveToDb = "/Assets/Uploads/" + fileName;

                news.Image = pathSaveToDb;
            }

            if (ModelState.IsValid)
            {
                news.CreatedBy = User.Identity.Name;
                news.CreatedDate = DateTime.Now;
                news.ModifyDate = DateTime.Now;
                news.ModifyBy = User.Identity.Name;              

                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NewsCateID = new SelectList(db.NewsCategories, "NewsCateID", "NewsCateName", news.NewsCateID);

            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = db.News.Include(n => n.NewsCategory).SingleOrDefault(x => x.NewsID == id);

            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.NewsCateID = new SelectList(db.NewsCategories, "NewsCateID", "NewsCateName", news.NewsCateID);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsID,NewsCateID,NewsName,UploadFile,Content,Image,IsActive")] News news)
        {
            News newFromDB = db.News.Find(news.NewsID);

            string pathSaveToDb = string.Empty;

            if (news.UploadFile != null)
            {
                string fileName = Path.GetFileName(news.UploadFile.FileName);

                string path = Server.MapPath("~/Assets/Uploads");

                news.UploadFile.SaveAs(Path.Combine(path, fileName));

                pathSaveToDb = "/Assets/Uploads/" + fileName;

                newFromDB.Image = pathSaveToDb;
            }

            if (ModelState.IsValid)
            {
                newFromDB.NewsCateID = news.NewsCateID;
                newFromDB.NewsName = news.NewsName;
                newFromDB.IsActive = news.IsActive;
                newFromDB.Content = news.Content;
                newFromDB.ModifyDate = DateTime.Now;
                newFromDB.ModifyBy = User.Identity.Name;
      

                db.Entry(newFromDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewsCateID = new SelectList(db.NewsCategories, "NewsCateID", "NewsCateName", news.NewsCateID);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = db.News.Include(n => n.NewsCategory).SingleOrDefault(x => x.NewsID == id);

            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);

            news.IsActive = false;
            news.ModifyBy = User.Identity.Name;
            news.ModifyDate = DateTime.Now;

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
