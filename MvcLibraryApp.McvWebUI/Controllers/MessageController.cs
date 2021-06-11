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
            var result = db.Messages.Where(x => x.Receiver == memberMail.ToString()).ToList();
            return View(result);
        }

        public ActionResult SerderMessage()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var result = db.Messages.Where(x => x.Sender == memberMail.ToString()).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Messages messages)
        {
            var memberMail = (string)Session["Mail"].ToString();
            messages.Sender = memberMail.ToString();
            messages.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Messages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("SerderMessage");
        }

        public PartialViewResult Partial()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var result1 = db.Messages.Where(x => x.Receiver == memberMail).Count();
            ViewBag.result1 = result1;

            var result2 = db.Messages.Where(x => x.Sender == memberMail).Count();
            ViewBag.result2 = result2;
            return PartialView();
        }
    }
}