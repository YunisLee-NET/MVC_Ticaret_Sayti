using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MusteriLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriLogIn(Musteriler p)
        {
            var melumatlar = c.Musterilers.FirstOrDefault(x => x.MusteriMail == p.MusteriMail && x.MusteriSifre == p.MusteriSifre);
            if (melumatlar != null)
            {
                FormsAuthentication.SetAuthCookie(melumatlar.MusteriMail, false);
                Session["MusteriMail"] = melumatlar.MusteriMail.ToString();
                return RedirectToAction("MusterliPanel", "MusteriLogin"); 
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var melumatlar = c.Admins.FirstOrDefault(x => x.IstifadeciAd == a.IstifadeciAd && x.Sifre == a.Sifre);
            if (melumatlar != null)
            {
                FormsAuthentication.SetAuthCookie(melumatlar.IstifadeciAd, false);
                Session["IstifadeciAd"] = melumatlar.IstifadeciAd.ToString();
                return RedirectToAction("Index", "Sobeler");
            }
            else
            {
                return RedirectToAction("Index", "MusteriLogin");
            }
        }
    }
}