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
    public class BookingTablesController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/BookingTables
        public ActionResult Index()
        {
            return View(db.BookingTables.ToList());
        }

        // POST: Admin/BookingTables/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingTable bookingTable = db.BookingTables.Find(id);

            bookingTable.IsActive = false;

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
