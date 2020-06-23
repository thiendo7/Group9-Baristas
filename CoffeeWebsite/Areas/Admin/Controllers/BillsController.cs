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
    public class BillsController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/Bills
        public ActionResult Index()
        {
            var bills = db.Bills.Include(b => b.Account).Include(b => b.Payment);
            return View(bills.ToList());
        }

        // GET: Admin/Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bill bill = db.Bills.Include(b => b.Account).Include(b => b.Payment).SingleOrDefault(x => x.BillID == id);

            if (bill == null)
            {
                return HttpNotFound();
            }

            bill.BillDetails = db.BillDetails.Include(x => x.Product).Where(x => x.BillID == id).ToList();

            return View(bill);
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
