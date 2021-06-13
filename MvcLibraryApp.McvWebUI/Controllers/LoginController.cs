using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace MvcLibraryApp.McvWebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login      
        LibraryAppDbEntities db = new LibraryAppDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Members members)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = members.Password;
            string result1 = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            members.Password = result1;
            var result = db.Members.FirstOrDefault(x => x.Mail == members.Mail && x.Password == result1);
            if (result !=null)
            {
                FormsAuthentication.SetAuthCookie(result.Mail, false);
                Session["Mail"] = result.Mail.ToString();
                //TempData["Numara"] = result.Id.ToString();
                //TempData["İsim"] = result.MemberName.ToString();
                //TempData["Soyİsim"] = result.MemberLastName.ToString();
                //TempData["Kullanıcı"] = result.NickName.ToString();
                //TempData["Şifre"] = result.Password.ToString();
                //TempData["Eğitim"] = result.School.ToString();
                //TempData["Telefon"] = result.Phone.ToString();
                return RedirectToAction("Index", "Panel");
            }
            return View();
        }
    }
}