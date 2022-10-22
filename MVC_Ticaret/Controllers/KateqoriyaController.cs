using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize]

    public class KateqoriyaController : Controller
    {
        // GET: Kateqoriya
        Context c = new Context();
        public ActionResult Index()
        {
            var melumatlar = c.Kateqoriyas.ToList();
            return View(melumatlar);
        }
        [HttpGet]
        public ActionResult YeniKateqoriya()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKateqoriya(Kateqoriya k)
        {
            c.Kateqoriyas.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KateqoriyaSil(int id)
        {
            var ks = c.Kateqoriyas.Find(id);
            c.Kateqoriyas.Remove(ks);
            c.SaveChanges();
            return RedirectToAction("Index", "Kateqoriya");
        }
        public ActionResult KateqoriyaGetir(int id)
        {
            var kg = c.Kateqoriyas.Find(id);
            return View("KateqoriyaGetir", kg);
        }
        public ActionResult KateqoriyaGuncelle(Kateqoriya kt)
        {
            var kgn = c.Kateqoriyas.Find(kt.KateqoriyaID);
            kgn.KateqoriyaAd = kt.KateqoriyaAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}