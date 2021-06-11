using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}