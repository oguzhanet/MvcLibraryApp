using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibraryApp.McvWebUI.Models.Entity;
using System.Web.Security;

namespace MvcLibraryApp.McvWebUI.Controllers
{
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
                Session["Numara"] = result.Id.ToString();
                Session["İsim"] = result.MemberName.ToString();
                Session["Soyİsim"] = result.MemberLastName.ToString();
                Session["Kullanıcı"] = result.NickName.ToString();
                Session["Şifre"] = result.Password.ToString();
                Session["Eğitim"] = result.School.ToString();
                Session["Telefon"] = result.Phone.ToString();
                return RedirectToAction("Index", "Panel");
            }
            return View();
        }
    }
}