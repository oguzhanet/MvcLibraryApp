using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            var result = (string)Session["Mail"];
            //var member = db.Members.FirstOrDefault(x => x.Mail == result);
            var member = db.Announcements.ToList();

            var memberName = db.Members.Where(x => x.Mail == result).Select(z => z.MemberName + " " + z.MemberLastName).FirstOrDefault();
            ViewBag.memberName = memberName;

            var memberImage = db.Members.Where(x => x.Mail == result).Select(z => z.Image).FirstOrDefault();
            ViewBag.memberImage = memberImage;

            var memberNickName = db.Members.Where(x => x.Mail == result).Select(z => z.NickName).FirstOrDefault();
            ViewBag.memberNickName = memberNickName;

            var memberShool = db.Members.Where(x => x.Mail == result).Select(z => z.School).FirstOrDefault();
            ViewBag.memberShool = memberShool;

            var memberPhone = db.Members.Where(x => x.Mail == result).Select(z => z.Phone).FirstOrDefault();
            ViewBag.memberPhone = memberPhone;

            var memberMail = db.Members.Where(x => x.Mail == result).Select(z => z.Mail).FirstOrDefault();
            ViewBag.memberMail = memberMail;

            var memberId = db.Members.Where(x => x.Mail == result).Select(z => z.Id).FirstOrDefault();
            var memberBookCount = db.Movements.Where(x => x.MemberId == memberId).Count();
            ViewBag.memberBookCount = memberBookCount;

            var memberMessage = db.Messages.Where(x => x.Receiver == result).Count();
            ViewBag.memberMessage = memberMessage;

            var memberAnnouncement = db.Announcements.Count();
            ViewBag.memberAnnouncement = memberAnnouncement;

            return View(member);
        }

        [HttpPost]
        public ActionResult Index(Members members)
        {
            var result = (string)Session["Mail"];
            var member = db.Members.FirstOrDefault(x => x.Mail == result);
            member.MemberName = members.MemberName;
            member.MemberLastName = members.MemberLastName;
            member.NickName = members.NickName;
            member.Phone = members.Phone;
            member.School = members.School;
            member.Image = members.Image;
            member.Password = members.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyBook()
        {
            var result = (string)Session["Mail"];
            var result1 = db.Members.Where(x => x.Mail == result.ToString()).Select(c => c.Id).FirstOrDefault();
            var result2 = db.Movements.Where(x => x.MemberId == result1).ToList();
            return View(result2);
        }

        public PartialViewResult PanelPartial()
        {
            return PartialView();
        }

        public PartialViewResult PanelPartial2()
        {
            var result = (string)Session["Mail"];
            var id = db.Members.Where(x => x.Mail == result).Select(z => z.Id).FirstOrDefault();
            var memberFind = db.Members.Find(id);
            return PartialView("PanelPartial2",memberFind);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}