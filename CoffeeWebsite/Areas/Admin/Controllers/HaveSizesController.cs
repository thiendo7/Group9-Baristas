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
    public class HaveSizesController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/HaveSizes
        public ActionResult Index()
        {
            var haveSizes = db.HaveSizes.Include(h => h.Product).Include(h => h.ProductSize);

            return View(haveSizes.ToList());
        }

        // GET: Admin/HaveSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HaveSize haveSize = db.HaveSizes.Include(x => x.Product).Include(x => x.ProductSize).SingleOrDefault(x => x.HaveSizeID == id);

            if (haveSize == null)
            {
                return HttpNotFound();
            }
            return View(haveSize);
        }

        // GET: Admin/HaveSizes/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.ProductSizeID = new SelectList(db.ProductSizes, "ProductSizeID", "SizeName");

            return View(new HaveSize());
        }

        // POST: Admin/HaveSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HaveSizeID,ProductID,ProductSizeID,Prices")] HaveSize haveSize)
        {
            if (ModelState.IsValid)
            {
                db.HaveSizes.Add(haveSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", haveSize.ProductID);
            ViewBag.ProductSizeID = new SelectList(db.ProductSizes, "ProductSizeID", "SizeName", haveSize.ProductSizeID);

            return View(haveSize);
        }

        // GET: Admin/HaveSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HaveSize haveSize = db.HaveSizes.Include(x => x.Product).Include(x => x.ProductSize).SingleOrDefault(x => x.HaveSizeID == id);

            if (haveSize == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", haveSize.ProductID);
            ViewBag.ProductSizeID = new SelectList(db.ProductSizes, "ProductSizeID", "SizeName", haveSize.ProductSizeID);

            return View(haveSize);
        }

        // POST: Admin/HaveSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HaveSizeID,ProductID,ProductSizeID,Prices")] HaveSize haveSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(haveSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", haveSize.ProductID);
            ViewBag.ProductSizeID = new SelectList(db.ProductSizes, "ProductSizeID", "SizeName", haveSize.ProductSizeID);

            return View(haveSize);
        }

        // GET: Admin/HaveSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HaveSize haveSize = db.HaveSizes.Include(x => x.Product).Include(x => x.ProductSize).SingleOrDefault(x => x.HaveSizeID == id);

            if (haveSize == null)
            {
                return HttpNotFound();
            }

            return View(haveSize);
        }

        // POST: Admin/HaveSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HaveSize haveSize = db.HaveSizes.Find(id);

            db.HaveSizes.Remove(haveSize);
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
