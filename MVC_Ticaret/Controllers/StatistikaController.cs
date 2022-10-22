using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize]

    public class StatistikaController : Controller
    {
        // GET: Statistika
        Context c = new Context();
        public ActionResult Index()
        {
            var musteri = c.Musterilers.Count().ToString();
            var mehsul = c.Mehsullars.Count().ToString();
            var isci = c.Iscilers.Count().ToString();
            var ktq = c.Kateqoriyas.Count().ToString();
            var stok = c.Mehsullars.Sum(x => x.Stok).ToString();
            var markasay = (from x in c.Mehsullars select x.Marka).Distinct().Count().ToString();
            var kritik = c.Mehsullars.Count(x => x.Stok <= 10).ToString();
            var maxqiymet = (from x in c.Mehsullars orderby x.SatisQiymet descending select x.Marka).FirstOrDefault();
            var minqiymet = (from x in c.Mehsullars orderby x.SatisQiymet ascending select x.Marka).FirstOrDefault();
            var xiaomi = c.Mehsullars.Where(x => x.Marka == "Xiaomi").Sum(y=>y.Stok).ToString();
            var lenovo = c.Mehsullars.Where(x => x.Marka == "Lenovo").Sum(y => y.Stok).ToString();
            var maxmarka = c.Mehsullars.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var kassapul = c.SatisHerekets.Sum(x => x.UmumiXerc).ToString();
            var encoxsatilan = c.Mehsullars.Where(m => m.MehsulID == (c.SatisHerekets.GroupBy(x => x.MehsulID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.MehsulAd).FirstOrDefault();
            DateTime bugun = DateTime.Today;
            var bugunsatis = c.SatisHerekets.Count(x => x.Tarix == bugun).ToString();
            var bugunkassa = c.SatisHerekets.Where(y => y.Tarix == bugun).Sum(x => x.UmumiXerc).ToString();
            ViewBag.d1 = musteri;
            ViewBag.d2 = mehsul;
            ViewBag.d3 = isci;
            ViewBag.d4 = ktq;
            ViewBag.d5 = stok;
            ViewBag.d6 = markasay;
            ViewBag.d7 = kritik;
            ViewBag.d8 = maxqiymet;
            ViewBag.d9 = minqiymet;
            ViewBag.d10 = xiaomi;
            ViewBag.d11 = lenovo;
            ViewBag.d12 = maxmarka;
            ViewBag.d13 = encoxsatilan;
            ViewBag.d14 = kassapul;
            ViewBag.d15 = bugunsatis;
            ViewBag.d16 = bugunkassa;
            return View();
        }
        public ActionResult RahatCedveller()
        {
            var sorgu = from x in c.Musterilers
                        group x by x.MusteriSeher into g
                        select new QrupSinif
                        {
                            Seher = g.Key,
                            UmumiSay = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Iscilers
                         group x by x.Sobeler.SobeAd into g
                         select new QrupSobe
                         {
                             Sobe = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
    }
}