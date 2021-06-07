using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;
using MvcLibraryApp.McvWebUI.Models.Classes;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    [AllowAnonymous]
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            BookAndAbout bookAndAbout = new BookAndAbout();
            bookAndAbout.Books = db.Books.ToList();
            bookAndAbout.Abouts = db.Abouts.ToList();
            //var result = db.Books.ToList();
            return View(bookAndAbout);
        }

        [HttpPost]
        public ActionResult Index(Contacts contacts)
        {
            db.Contacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}