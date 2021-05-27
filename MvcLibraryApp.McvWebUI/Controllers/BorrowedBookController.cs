using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class BorrowedBookController : Controller
    {
        // GET: BorrowedBook
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index()
        {
            var result = db.Movements.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Lend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Lend(Movements movements)
        {
            db.Movements.Add(movements);
            db.SaveChanges();
            return View();
        }

        public ActionResult Borrow(int id)
        {
            var result = db.Movements.Find(id);
            return View("Borrow", result);
        }
    }
}