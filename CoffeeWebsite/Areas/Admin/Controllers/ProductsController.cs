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
    public class ProductsController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductCategory);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Include(x => x.ProductCategory).SingleOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductCateID = new SelectList(db.ProductCategories, "ProductCateID", "CateName");
            return View(new Product());
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductCateID,UploadFile,ProductName,Discount,Description,IsActive")] Product product)
        {
            string pathSaveToDb = string.Empty;

            if (product.UploadFile != null)
            {
                string fileName = Path.GetFileName(product.UploadFile.FileName); //dibethien.jpg

                string path = Server.MapPath("~/Assets/Uploads"); //Tạo đường dẫn vào project

                product.UploadFile.SaveAs(Path.Combine(path, fileName)); //Lưu hình ảnh vào trong project

                pathSaveToDb = "/Assets/Uploads/" + fileName; //Lấy đường dẫn trong prject ra 

                product.image = pathSaveToDb;// "/Assets/Uploads/dibethien.jpg" 
            }

            if (ModelState.IsValid)
            {
                product.CreatedBy = User.Identity.Name;
                product.CreatedDate = DateTime.Now;
                product.ModifyDate = DateTime.Now;
                product.ModifyBy = User.Identity.Name;
            
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCateID = new SelectList(db.ProductCategories, "ProductCateID", "CateName", product.ProductCateID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Include(x => x.ProductCategory).SingleOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductCateID = new SelectList(db.ProductCategories, "ProductCateID", "CateName", product.ProductCateID);

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductCateID,ProductName,Discount,Description,UploadFile,IsActive")] Product product)
        {
            Product productFromDB = db.Products.Find(product.ProductID);

            string pathSaveToDb = string.Empty;

            if (product.UploadFile != null)
            {
                string fileName = Path.GetFileName(product.UploadFile.FileName);

                string path = Server.MapPath("~/Assets/Uploads");

                product.UploadFile.SaveAs(Path.Combine(path, fileName));

                pathSaveToDb  = "/Assets/Uploads/" + fileName;

                productFromDB.image = pathSaveToDb;
            }

            if (ModelState.IsValid)
            {
                productFromDB.ProductCateID = product.ProductCateID;
                productFromDB.ProductName = product.ProductName;
                productFromDB.Discount = product.Discount;
                productFromDB.Description = product.Description;
                productFromDB.ModifyDate = DateTime.Now;
                productFromDB.ModifyBy = User.Identity.Name;

                db.Entry(productFromDB).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ProductCateID = new SelectList(db.ProductCategories, "ProductCateID", "CateName", product.ProductCateID);

            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Include(x => x.ProductCategory).SingleOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);

            product.IsActive = false;
            product.ModifyDate = DateTime.Now;
            product.ModifyBy = User.Identity.Name;

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
