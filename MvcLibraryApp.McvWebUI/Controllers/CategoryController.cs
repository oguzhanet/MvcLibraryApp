using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index()
        {
            var result = db.Categories.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Categories categories)
        {
            db.Categories.Add(categories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}