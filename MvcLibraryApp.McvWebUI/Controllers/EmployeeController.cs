using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;
using PagedList;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index(int page=1)
        {
            var result = db.Employees.ToList().ToPagedList(page, 10);
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = db.Employees.Find(id);
            db.Employees.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            var result = db.Employees.Find(id);
            return View("GetById", result);
        }

        public ActionResult Update(Employees employees)
        {
            var result = db.Employees.Find(employees.Id);
            result.EmployeeName = employees.EmployeeName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}