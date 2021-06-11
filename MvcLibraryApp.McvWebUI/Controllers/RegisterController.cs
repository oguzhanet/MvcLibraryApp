using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Members members)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            db.Members.Add(members);
            db.SaveChanges();
            return View();
        }
    }
}