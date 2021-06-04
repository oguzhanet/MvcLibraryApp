using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class MessageController : Controller
    {
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        // GET: Message
        public ActionResult Index()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var result = db.Messages.Where(x=>x.Receiver==memberMail.ToString()).ToList();
            return View(result);
        }

        public ActionResult NewMessage()
        {
            return View();
        }
    }
}