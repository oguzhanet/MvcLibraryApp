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
            var result = db.Categories.Where(x=>x.Status==true).ToList();
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

        public ActionResult Delete(int id)
        {
            var result = db.Categories.Find(id);
            //db.Categories.Remove(result);
            result.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            var result = db.Categories.Find(id);
            return View("GetById", result);
        }

        public ActionResult Update(Categories categories)
        {
            var result = db.Categories.Find(categories.Id);
            result.CategoryName = categories.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}