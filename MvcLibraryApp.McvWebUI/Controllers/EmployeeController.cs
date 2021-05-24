using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index()
        {
            var result = db.Employees.ToList();
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

    }
}