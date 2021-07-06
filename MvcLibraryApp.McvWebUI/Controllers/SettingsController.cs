using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        public ActionResult Index()
        {
            var member = db.AdminLogins.ToList();
            return View(member);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(AdminLogins admin)
        {
            db.AdminLogins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            var admin = db.AdminLogins.Find(id);
            return View("AdminUpdate",admin);
        }

        [HttpPost]
        public ActionResult AdminUpdate(AdminLogins admin)
        {
            var result = db.AdminLogins.Find(admin.Id);
            result.Email = admin.Email;
            result.AdminRole = admin.AdminRole;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            var result = db.AdminLogins.Find(id);
            db.AdminLogins.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}