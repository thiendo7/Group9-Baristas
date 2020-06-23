using Antlr.Runtime.Misc;
using CoffeeWebsite.Business;
using CoffeeWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CoffeeWebsite.Controllers
{

    public class AccountController : Controller
    {
        BaristasEntities db = new BaristasEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Có lỗi đã xảy ra! Xin vui lòng thử lại";
                return View();
            }

            var account = AccountService.Instance.GetAccountLogin(model);

            if (account == null)
            {
                ViewBag.Message = "Mật khẩu hoặc tài khoản không đúng";
                return View();
            }

            Authenticate(account);

            return RedirectToAction("Index","Home");

            
        }

        public void Authenticate(Account account)
        {
            FormsAuthentication.SetAuthCookie(account.UserName, false);

            var authTicket = new FormsAuthenticationTicket(1, 
                account.UserName, 
                DateTime.Now, 
                DateTime.Now.AddMinutes(30), 
                false, account.AccountType.AccountTypeName);

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            HttpContext.Response.Cookies.Add(authCookie);

        }
        
        

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View();
            }

            if (!model.IsMatchPassword)
            {
                ViewBag.Message = "Mật khẩu nhập lại chưa chính xác !";
                return View();
            }

            Account account = AccountService.Instance.CreateAccount(model);

            if (account == null)
            {
                ViewBag.Message = "Đã có lỗi xảy ra! Xin vui lòng thử lại sau !";
                return View();
            }

            Authenticate(account);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View();
            }

            string username = User.Identity.Name;

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult AccountProfile()
        {
            string username = User.Identity.Name;

            Account account = AccountService.Instance.GetUserByUsername(username);

            return View(account);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AccountPurchase()
        {
            string username = User.Identity.Name;

            Account account = AccountService.Instance.GetUserByUsername(username);

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AccountProfile(AccountModel model)
        {
            string username = User.Identity.Name;

            Account account = AccountService.Instance.GetUserByUsername(username);

            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View(account);
            }

            int result = AccountService.Instance.UpdateProfile(model, username);

            return RedirectToAction("AccountProfile", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string username = User.Identity.Name;

            Account account = AccountService.Instance.GetUserByUsername(username);

            if (!ModelState.IsValid)
            {
                ViewBag.Message =
                           ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)
                               .Aggregate("", (current, item) => current + item.ErrorMessage + "</br>");

                return View("AccountProfile", account);
            }

            if (!model.IsMatchPassword)
            {
                ViewBag.Message = "Mật khẩu nhập lại chưa chính xác !";
                return View("AccountProfile", account);
            }

            string message = AccountService.Instance.ChangePassword(username, model);

            if (message == "SUCCESS")
            {
                return RedirectToAction("AccountProfile", "Account");
            }

            ViewBag.Message = message;
            return View("AccountProfile", account);
        }
    }
}