using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize(Roles = "B")]

    public class MusterilerController : Controller
    {
        // GET: Musteriler
        Context c = new Context();
        public ActionResult Index()
        {
            var melumatlar = c.Musterilers.ToList();
            return View(melumatlar);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Musteriler m)
        {
            c.Musterilers.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var musterisil = c.Musterilers.Find(id);
            c.Musterilers.Remove(musterisil);
            c.SaveChanges();
            return RedirectToAction("Index", "Musteriler");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = c.Musterilers.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult MusteriGuncelle(Musteriler m)
        {
            var mg = c.Musterilers.Find(m.MusteriID);
            mg.MusteriAd = m.MusteriAd;
            mg.MusteriSoyad = m.MusteriSoyad;
            mg.MusteriSeher = m.MusteriSeher;
            mg.MusteriMail = m.MusteriMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var melumatlar = c.SatisHerekets.Where(x => x.MusteriID == id).ToList();
            var musteri = c.Musterilers.Where(x => x.MusteriID == id).Select(y => y.MusteriAd + " " + y.MusteriSoyad).FirstOrDefault();
            ViewBag.mus = musteri;
            return View(melumatlar);
        }
    }
}