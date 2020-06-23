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
    public class ProductSizesController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/ProductSizes
        public ActionResult Index()
        {
            return View(db.ProductSizes.ToList());
        }

        // GET: Admin/ProductSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.ProductSizes.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // GET: Admin/ProductSizes/Create
        public ActionResult Create()
        {
            return View(new ProductSize());
        }

        // POST: Admin/ProductSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductSizeID,SizeName,IsActive")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                productSize.CreatedBy = User.Identity.Name;
                productSize.CreatedDate = DateTime.Now;
                productSize.ModifyDate = DateTime.Now;
                productSize.ModifyBy = User.Identity.Name;

                db.ProductSizes.Add(productSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productSize);
        }

        // GET: Admin/ProductSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = db.ProductSizes.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: Admin/ProductSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductSizeID,SizeName,IsActive")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                ProductSize product = db.ProductSizes.Find(productSize.ProductSizeID);

                product.ModifyDate = DateTime.Now;
                product.ModifyBy = User.Identity.Name;
                product.SizeName = productSize.SizeName;
                product.IsActive = productSize.IsActive;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productSize);
        }

        // GET: Admin/ProductSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductSize productSize = db.ProductSizes.Find(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: Admin/ProductSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSize productSize = db.ProductSizes.Find(id);

            productSize.ModifyDate = DateTime.Now;
            productSize.ModifyBy = User.Identity.Name;
            productSize.IsActive = false;

            db.Entry(productSize).State = EntityState.Modified;
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
