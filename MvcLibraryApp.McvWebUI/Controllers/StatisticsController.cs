using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
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