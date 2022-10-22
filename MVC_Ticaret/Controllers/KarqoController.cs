using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize]

    public class KarqoController : Controller
    {
        // GET: Karqo
        Context c = new Context();
        public ActionResult Index()
        {
            var melumatlar = c.Karqos.Where(x => x.YesNo == true).ToList();
            return View(melumatlar);
        }
        [HttpGet]
        public ActionResult YeniKarqo()
        {
            Random rnd = new Random();
            string[] simvollar = { "A", "B", "C", "D", "E" };
            int s1, s2, s3;
            s1 = rnd.Next(0, 4);
            s2 = rnd.Next(0, 4);
            s3 = rnd.Next(0, 4);
            int k1, k2, k3;
            k1 = rnd.Next(100, 1000);
            k2 = rnd.Next(10, 99);
            k3 = rnd.Next(10, 99);
            string kod = simvollar[s1] + simvollar[s2] + simvollar[s3] + k1.ToString() + k2.ToString() + k3.ToString();
            ViewBag.kkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKarqo(Karqo k)
        {
            c.Karqos.Add(k);
            k.YesNo = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KarqoDetallar(string id)
        {
            var karqoseriya = c.KarqoDetallars.Select(x => x.KarqoSeriya).FirstOrDefault();
            ViewBag.kser = karqoseriya;
            var detallar = c.KarqoDetallars.Where(x => x.KarqoSeriya == id).ToList();
            return View(detallar);
        }
        public ActionResult KarqoGetir(string id)
        {
            var karqoseriya = c.KarqoDetallars.Select(x => x.KarqoSeriya).FirstOrDefault();
            ViewBag.kser = karqoseriya;
            //var kg = c.KarqoDetallars.Where(x => x.KarqoSeriya == id).ToList();
            var kg=c.KarqoDetallars.Find(id);
            return View("KarqoGetir", kg);
        }
    }
}