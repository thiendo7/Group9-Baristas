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
    public class ProductCategoriesController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/ProductCategories
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        // GET: Admin/ProductCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Create
        public ActionResult Create()
        {
            return View(new ProductCategory());
        }

        // POST: Admin/ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCateID,CateName,IsActive")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                productCategory.CreatedBy = User.Identity.Name;
                productCategory.CreatedDate = DateTime.Now;
                productCategory.ModifyDate = DateTime.Now;
                productCategory.ModifyBy = User.Identity.Name;

                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCateID,CateName,IsActive")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                ProductCategory productCate = db.ProductCategories.Find(productCategory.ProductCateID);

                productCate.ModifyDate = DateTime.Now;
                productCate.ModifyBy = User.Identity.Name;
                productCate.CateName = productCategory.CateName;
                productCate.IsActive = productCategory.IsActive;

                db.Entry(productCate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: Admin/ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: Admin/ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productCategory = db.ProductCategories.Find(id);

            productCategory.ModifyDate = DateTime.Now;
            productCategory.ModifyBy = User.Identity.Name;
            productCategory.IsActive = false;

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
