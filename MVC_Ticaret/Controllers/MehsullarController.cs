using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize]

    public class MehsullarController : Controller
    {
        // GET: Mehsullar
        Context c = new Context();
        public ActionResult Index()
        {
            var mehsulmelumat = c.Mehsullars.Where(x => x.Veziyyet == true).ToList();
            return View(mehsulmelumat);
        }
        [HttpGet]
        public ActionResult YeniMehsul()
        {
            List<SelectListItem> kateqoriya = (from m in c.Kateqoriyas.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = m.KateqoriyaAd,
                                                   Value = m.KateqoriyaID.ToString()
                                               }).ToList();
            ViewBag.kq = kateqoriya;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMehsul(Mehsullar m)
        {
            c.Mehsullars.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MehsulSil(int id)
        {
            var ms = c.Mehsullars.Find(id);
            ms.Veziyyet = false;
            c.SaveChanges();
            return RedirectToAction("Index", "Mehsullar");
        }
        public ActionResult MehsulGetir(int id)
        {
            List<SelectListItem> ktgr = (from x in c.Kateqoriyas.ToList()
                                         select new SelectListItem
                                         {
                                             Value = x.KateqoriyaID.ToString(),
                                             Text = x.KateqoriyaAd
                                         }).ToList();
            ViewBag.vbktqr = ktgr;
            var mehsul = c.Mehsullars.Find(id);
            return View("MehsulGetir", mehsul);
        }
        public ActionResult MehsulYenile(Mehsullar m)
        {
            var mhsl = c.Mehsullars.Find(m.MehsulID);
            mhsl.MehsulAd = m.MehsulAd;
            mhsl.Marka = m.Marka;
            mhsl.Stok = m.Stok;
            mhsl.AlisQiymet = m.AlisQiymet;
            mhsl.SatisQiymet = m.SatisQiymet;
            mhsl.Veziyyet = m.Veziyyet;
            mhsl.MehsulFoto = m.MehsulFoto;
            mhsl.KateqoriyaID = m.KateqoriyaID;
            c.SaveChanges();
            return RedirectToAction("Index", "Mehsullar");
        }
        [HttpGet]
        public ActionResult MehsulSat(int id)
        {
            List<SelectListItem> m1 = (from sai in c.Iscilers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = sai.IsciAd + " " + sai.IsciSoyad,
                                                  Value = sai.IsciID.ToString()
                                              }).ToList();
            ViewBag.m1 = m1;
            var m2 = c.Mehsullars.Find(id);
            ViewBag.m2 = m2.MehsulID;
            ViewBag.sq1 = m2.SatisQiymet;
            ViewBag.say = m2.Stok;
            return View();
        }
        [HttpPost]
        public ActionResult MehsulSat(SatisHereket p)
        {
            p.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHerekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Mehsullar");
        }
    }
}