using MvcQuizSonDeneme.Models.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcQuizSon.Controllers
{
    public class KayitOlController : Controller
    {
        MvcQuizYeniEntities db = new MvcQuizYeniEntities();
        // GET: KayitOl
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult yeniKullanici()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniKullanici(kullaniciBilgileri p)
        {
            db.kullaniciBilgileri.Add(p);
            db.SaveChanges();
           
            return RedirectToAction("KategoriSecimEkrani", "MemoryKart");
        }
    }
}