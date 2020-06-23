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
    public class AccountsController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.AccountType).Where(x => x.UserName != User.Identity.Name);
            return View(accounts.ToList());
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
