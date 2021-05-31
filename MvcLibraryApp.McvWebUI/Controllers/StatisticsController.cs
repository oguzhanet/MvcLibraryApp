using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index()
        {
            var result = db.Penalties.Sum(x => x.Money)*25/100;
            ViewBag.result = result;

            var result1 = db.Members.Count();
            ViewBag.result1 = result1;

            var result2 = db.Books.Count();
            ViewBag.result2 = result2;

            var result3 = db.Books.Where(x=>x.Status==false).Count();
            ViewBag.result3 = result3;

            return View();
        }

        public ActionResult Air()
        {
            return View();
        }

        public ActionResult AirCard()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength >0)
            {
                string result = Path.Combine(Server.MapPath("~/Templates/web2/resimler/"),
                    Path.GetFileName(file.FileName));
                file.SaveAs(result);
            }
            return RedirectToAction("Gallery");
        }
    }
}