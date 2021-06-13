using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;
using PagedList;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        LibraryAppDbEntities db = new LibraryAppDbEntities();
        public ActionResult Index(int page=1)
        {
            var result = db.Members.ToList().ToPagedList(page, 10);
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Members members)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            members.Role = "C";
            db.Members.Add(members);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = db.Members.Find(id);
            db.Members.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetById(int id)
        {
            var result = db.Members.Find(id);
            return View("GetById", result);
        }

        public ActionResult Update(Members members)
        {
            var result = db.Members.Find(members.Id);
            result.MemberName = members.MemberName;
            result.MemberLastName = members.MemberLastName;
            result.Mail = members.Mail;
            result.Phone = members.Phone;
            result.School = members.School;
            result.Image = members.Image;
            result.IdentityNumber = members.IdentityNumber;
            result.NickName = members.NickName;
            result.Password = members.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MemberBook(int id)
        {
            var result = db.Movements.Where(x => x.MemberId == id).ToList();
            var memberBook = db.Members.Where(x => x.Id == id).Select(z =>
                  z.MemberName + " " + z.MemberLastName).FirstOrDefault();
            ViewBag.memberBook = memberBook;
            return View(result);
        }
    }
}