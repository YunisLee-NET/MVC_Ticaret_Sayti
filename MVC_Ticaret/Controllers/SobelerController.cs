using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize(Roles = "A")]

    public class SobelerController : Controller
    {
        // GET: Sobeler
        Context c = new Context();
        public ActionResult Index()
        {
            var melumatlar = c.Sobelers.Where(x => x.SobeVeziyyet == true).ToList();
            return View(melumatlar);
        }
        [HttpGet]
        public ActionResult YeniSobe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSobe(Sobeler s)
        {
            c.Sobelers.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SobeSil(int id)
        {
            var sb = c.Sobelers.Find(id);
            sb.SobeVeziyyet = false;
            c.SaveChanges();
            return RedirectToAction("Index", "Sobeler");
        }
        public ActionResult SobeGetir(int id)
        {
            var sg = c.Sobelers.Find(id);
            return View("SobeGetir", sg);
        }
        public ActionResult SobeGuncelle(Sobeler su)
        {
            var sgn = c.Sobelers.Find(su.SobeID);
            sgn.SobeAd = su.SobeAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SobeDetal(int id)
        {
            var detal = c.Iscilers.Where(x => x.SobeID == id).ToList();
            var sobead = c.Sobelers.Where(x => x.SobeID == id).Select(y => y.SobeAd).FirstOrDefault();
            ViewBag.sbad = sobead;
            var iscisay = c.Iscilers.Where(x => x.SobeID == id).Count();
            ViewBag.say = iscisay;
            return View(detal);
        }
        public ActionResult SobeSatis(int id)
        {
            var sobeisci = c.Iscilers.Where(x => x.IsciID == id).Select(y => y.IsciAd + " " + y.IsciSoyad).FirstOrDefault();
            ViewBag.sbi = sobeisci;
            var melumatlar = c.SatisHerekets.Where(x => x.IsciID == id).ToList();
            return View(melumatlar);
        }
    }
}