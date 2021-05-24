using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index()
        {
            var result = db.Members.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Members members)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Members.Add(members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}