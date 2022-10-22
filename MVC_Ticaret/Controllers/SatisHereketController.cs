using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize]

    public class SatisHereketController : Controller
    {
        // GET: SatisHereket
        Context c = new Context();
        public ActionResult Index()
        {
            var melumatlar = c.SatisHerekets.ToList();
            return View(melumatlar);
        }
        [HttpGet]
        public ActionResult SatisEt()
        {
            List<SelectListItem> satismusteri = (from sam in c.Musterilers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = sam.MusteriAd + " " + sam.MusteriSoyad,
                                                     Value = sam.MusteriID.ToString()
                                                 }).ToList();
            ViewBag.sms = satismusteri;

            List<SelectListItem> satismehsul = (from sme in c.Mehsullars.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = "Məhsul: " + sme.MehsulAd + " / " + " Marka: " + sme.Marka + " / " + "Məhsul qiyməti: " + sme.SatisQiymet + "AZN",
                                                    Value = sme.MehsulID.ToString()
                                                }).ToList();
            ViewBag.smh = satismehsul;

            List<SelectListItem> satisisci = (from sai in c.Iscilers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = sai.IsciAd + " " + sai.IsciSoyad,
                                                  Value = sai.IsciID.ToString()
                                              }).ToList();
            ViewBag.si = satisisci;
            return View();
        }
        [HttpPost]
        public ActionResult SatisEt(SatisHereket sh)
        {
            sh.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHerekets.Add(sh);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SHGetir(int id)
        {
            List<SelectListItem> satismusteri = (from sam in c.Musterilers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = sam.MusteriAd + " " + sam.MusteriSoyad,
                                                     Value = sam.MusteriID.ToString()
                                                 }).ToList();
            ViewBag.sms = satismusteri;

            List<SelectListItem> satismehsul = (from sme in c.Mehsullars.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = "Məhsul: " + sme.MehsulAd + " / " + " Marka: " + sme.Marka + " / " + "Məhsul qiyməti: " + sme.SatisQiymet + "AZN",
                                                    Value = sme.MehsulID.ToString()
                                                }).ToList();
            ViewBag.smh = satismehsul;

            List<SelectListItem> satisisci = (from sai in c.Iscilers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = sai.IsciAd + " " + sai.IsciSoyad,
                                                  Value = sai.IsciID.ToString()
                                              }).ToList();
            ViewBag.si = satisisci;

            var melumatlar = c.SatisHerekets.Find(id);
            return View("SHGetir", melumatlar);
        }


    }
}