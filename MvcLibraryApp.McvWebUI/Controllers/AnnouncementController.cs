using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class AnnouncementController : Controller
    {
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        // GET: Announcement
        public ActionResult Index()
        {
            var result = db.Announcements.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Announcements announcements)
        {
            announcements.Date = DateTime.Parse(DateTime.Today.ToString());
            db.Announcements.Add(announcements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = db.Announcements.Find(id);
            db.Announcements.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(Announcements announcements)
        {
            var result = db.Announcements.Find(announcements.Id);
            return View("Detail",result);
        }

        public ActionResult GetById(int id)
        {
            var result = db.Announcements.Find(id);
            return View("GetById", result);
        }

        public ActionResult Update(Announcements announcements)
        {
            var result = db.Announcements.Find(announcements.Id);
            result.AnnouncementCategory = announcements.AnnouncementCategory;
            result.AnnouncementContent = announcements.AnnouncementContent;
            announcements.Date = DateTime.Parse(DateTime.Today.ToString());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MemberPage()
        {
            var result = db.Announcements.ToList();
            return View(result);
        }

        public ActionResult MemberDetail(Announcements announcements)
        {
            var result = db.Announcements.Find(announcements.Id);
            return View("MemberDetail", result);
        }
    }
}