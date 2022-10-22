using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ticaret.Models.Sinifler;

namespace MVC_Ticaret.Controllers
{
    [Authorize]

    public class IscilerController : Controller
    {
        // GET: Isciler
        Context c = new Context();
        public ActionResult Index()
        {
            var melumatlar = c.Iscilers.ToList();
            return View(melumatlar);
        }
        public ActionResult IsciSiyahi()
        {
            var sorgu = c.Iscilers.ToList();
            return View(sorgu);
        }
    }
}