using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        public ActionResult Index()
        {
            var member = db.AdminLogins.ToList();
            return View(member);
        }
    }
}