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
    public class FeedBacksController : Controller
    {
        private BaristasEntities db = new BaristasEntities();

        // GET: Admin/FeedBacks
        public ActionResult Index()
        {
            return View(db.FeedBacks.ToList());
        }
    }
}
