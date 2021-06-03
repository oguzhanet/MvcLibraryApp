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
            var result = (string)Session["Mail"];
            var member = db.Members.FirstOrDefault(x => x.Mail == result);
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
            return View();
        }
    }
}