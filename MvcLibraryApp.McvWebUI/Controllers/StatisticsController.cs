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

        public ActionResult LinqCard()
        {
            var result1 = db.Books.Count();
            ViewBag.result1 = result1;

            var result2 = db.Members.Count();
            ViewBag.result2 = result2;

            var result3 = db.Penalties.Sum(x => x.Money) * 25 / 100;
            ViewBag.result3 = result3;

            var result4 = db.Books.Where(x => x.Status == false).Count();
            ViewBag.result4 = result4;

            var result5 = db.Categories.Count();
            ViewBag.result5 = result5;

            var result6 = db.EnFazlaKitapAlanUye().FirstOrDefault();
            ViewBag.result6 = result6;

            var result7 = db.EnFazlaOkunanKitap().FirstOrDefault();
            ViewBag.result7 = result7;

            var result8 = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.result8 = result8;

            //var result9 = db.Books.GroupBy(x => x.PublishingHouse).OrderByDescending(y => y.Count()).Select(z =>
            //      new { z.Key }).FirstOrDefault();
            var result9 = db.EnFazlaKitapYayınevi().FirstOrDefault();
            ViewBag.result9 = result9;

            var result10 = db.EnFazlaKİtapVerenPersonel().FirstOrDefault();
            ViewBag.result10 = result10;

            var result11 = db.Contacts.Count();
            ViewBag.result11 = result11;

            var result12 = db.Movements.Where(x => x.DateOfIssue == DateTime.Today).Count();
            ViewBag.result12 = result12;

            return View();
        }
    }
}