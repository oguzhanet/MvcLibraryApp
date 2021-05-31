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
            var result = db.Movements.Where(x => x.Status == false).ToList();
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
            return RedirectToAction("Index");
        }

        public ActionResult Borrow(Movements movements)
        {
            var result = db.Movements.Find(movements.Id);
            DateTime result1 = DateTime.Parse(result.ReturnDate.ToString());
            DateTime result2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan result3 = result2 - result1;
            ViewBag.result3 = result3.TotalDays;
            return View("Borrow", result);
        }

        public ActionResult Update(Movements movements)
        {
            var result = db.Movements.Find(movements.Id);
            result.MemberReturnDate = movements.MemberReturnDate;
            result.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}