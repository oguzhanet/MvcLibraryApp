using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index()
        {
            var result = db.Writers.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writers writers)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Writers.Add(writers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = db.Writers.Find(id);
            db.Writers.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            var result = db.Writers.Find(id);
            return View("GetById", result);
        }

        public ActionResult Update(Writers writers)
        {
            var result = db.Writers.Find(writers.Id);
            result.WriterName = writers.WriterName;
            result.WriterLastName = writers.WriterLastName;
            result.Detail = writers.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}