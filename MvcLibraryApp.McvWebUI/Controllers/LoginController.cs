using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;
using System.Web.Security;

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
            var result = db.Members.FirstOrDefault(x => x.Mail == members.Mail && x.Password == members.Password);
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