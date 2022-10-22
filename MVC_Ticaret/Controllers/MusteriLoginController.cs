using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Ticaret.Models.Sinifler;


namespace MVC_Ticaret.Controllers
{
    [Authorize]
    public class MusteriLoginController : Controller
    {
        // GET: MusteriLogin
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MusterliPanel()
        {
            var seher = (string)Session["MusteriSeher"];
            var ad = (string)Session["MusteriAd"];
            var soyad = (string)Session["MusteriSoyad"];
            var mail = (string)Session["MusteriMail"];
            var sekil = (string)Session["MusteriFoto"];

            var melumatlar = c.Musterilers.Where(x => x.MusteriMail == mail).ToList();

            return View(melumatlar);
        }
        [Authorize]
        public ActionResult MusteriSifaris()
        {
            var mail = (string)Session["MusteriMail"];
            var id = c.Musterilers.Where(x => x.MusteriMail == mail).Select(y => y.MusteriID).FirstOrDefault();
            var sifaris = c.SatisHerekets.Where(x => x.MusteriID == id).ToList();
            return View(sifaris);
        }
        public ActionResult MusteriKarqo()
        {
            var mail = (string)Session["MusteriMail"];
            var id = c.Musterilers.Where(x => x.MusteriMail == mail).Select(y => y.MusteriID).FirstOrDefault();
            var karqo = c.Karqos.Where(x => x.MusteriID == id).ToList();
            return View(karqo);
        }
        public ActionResult MusteriKarqoDetallar(string id)
        {
            var karqoseriya = c.KarqoDetallars.Select(x => x.KarqoSeriya).FirstOrDefault();
            ViewBag.kser = karqoseriya;
            var detallar = c.KarqoDetallars.Where(x => x.KarqoSeriya == id).ToList();
            return View(detallar);
        }
        public ActionResult Mesajlar()
        {
            var mail = (string)Session["MusteriMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alan == mail).ToList();
            return View(mesajlar);
        }

        public ActionResult GedenMesajlar()
        {
            var mail = (string)Session["MusteriMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderen == mail).ToList();
            return View(mesajlar);
        }

        public ActionResult DetalMesaj(int id)
        {
            var mesajdetal = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            return View(mesajdetal);
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["MusteriMail"];
            var gonderilenmesaj = c.Mesajlars.Count(x => x.Gonderen == mail).ToString();
            ViewBag.m1 = gonderilenmesaj;
            
            var gelenmesaj = c.Mesajlars.Count(x => x.Alan == mail).ToString();
            ViewBag.m2 = gelenmesaj;
            return PartialView();
        }

        public PartialViewResult PartialUser()
        {
            var mail = (string)Session["MusteriMail"];
            var user = c.Musterilers.Where(x => x.MusteriMail == mail).Select(y => y.MusteriAd + " " + y.MusteriSoyad).FirstOrDefault();
            ViewBag.u = user;

            var sekil = c.Musterilers.Where(x => x.MusteriMail == mail).Select(y => y.MusteriFoto).FirstOrDefault();
            ViewBag.s = sekil;
            return PartialView();
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["MusteriMail"];
            m.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(m);
            m.Gonderen = mail;
            c.SaveChanges();
            return View();
        }
        
    }
}