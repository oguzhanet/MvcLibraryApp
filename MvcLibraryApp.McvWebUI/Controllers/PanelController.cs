using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Members members)
        {
            var result = (string)Session["Mail"];
            var member = db.Members.FirstOrDefault(x => x.Mail == result);
            member.Password = members.Password;
            db.SaveChanges();
            return View();
        }
    }
}