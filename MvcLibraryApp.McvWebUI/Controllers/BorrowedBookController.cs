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
            List<SelectListItem> result1 = (from member in db.Members.ToList()
                                            select new SelectListItem
                                            {
                                                Text = member.MemberName + " " +member.MemberLastName,
                                                Value = member.Id.ToString()
                                            }).ToList();
            ViewBag.result1 = result1;

            List<SelectListItem> result2 = (from book in db.Books.Where(x=>x.Status==true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = book.BookName,
                                                Value = book.Id.ToString()
                                            }).ToList();
            ViewBag.result2 = result2;

            List<SelectListItem> result3 = (from Employee in db.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = Employee.EmployeeName,
                                                Value = Employee.Id.ToString()
                                            }).ToList();
            ViewBag.result3 = result3;
            return View();
        }

        [HttpPost]
        public ActionResult Lend(Movements movements)
        {
            var result1 = db.Members.Where(x => x.Id == movements.Members.Id).FirstOrDefault();
            var result2 = db.Books.Where(x => x.Id == movements.Books.Id).FirstOrDefault();
            var result3 = db.Employees.Where(x => x.Id == movements.Employees.Id).FirstOrDefault();
            movements.Members = result1;
            movements.Books = result2;
            movements.Employees = result3;
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