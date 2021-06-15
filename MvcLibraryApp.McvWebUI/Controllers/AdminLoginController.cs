using MvcLibraryApp.McvWebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminLogins adminLogins)
        {
            var result = db.AdminLogins.FirstOrDefault(x => x.Email == adminLogins.Email &&
              x.Password == adminLogins.Password);

            if (result !=null)
            {
                FormsAuthentication.SetAuthCookie(result.Email, false);
                Session["Email"] = result.Email.ToString();
                return RedirectToAction("Index", "Statistics");
            }

            ViewBag.ErrorMessage = "Email veya Şifreniz Yanlış!";
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}