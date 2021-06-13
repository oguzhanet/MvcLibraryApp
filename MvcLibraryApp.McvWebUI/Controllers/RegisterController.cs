using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Members members)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = members.Password;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            members.Password = result;
            members.Role = "C";
            db.Members.Add(members);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}