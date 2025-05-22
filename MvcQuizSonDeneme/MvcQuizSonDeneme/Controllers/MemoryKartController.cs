using MvcQuizSonDeneme.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace MvcQuizSon.Controllers
{
    public class MemoryKartController : Controller
    {

        MvcQuizYeniEntities db = new MvcQuizYeniEntities();
        // GET: MemoryKart
        public ActionResult Index()
        {
            var kart = db.SoruKarti.FirstOrDefault();
            return View(new List<SoruKarti> { kart });
        }



        [HttpGet]
        public ActionResult YeniKart()
        {
            var kategoriler = db.soruKategori
                                .Select(k => new SelectListItem
                                {
                                    Value = k.id.ToString(),
                                    Text = k.kategori
                                }).ToList();

            ViewBag.Kategoriler = kategoriler;

            var kullanicilar = db.kullaniciBilgileri
                        .Select(n => new SelectListItem
                        {
                            Value = n.id.ToString(),
                            Text=n.kullaniciAdi
                        }).ToList();
            

            ViewBag.Kullanicilar= kullanicilar;
return View();
        }
        [HttpPost]
        public ActionResult YeniKart(SoruKarti model)
        {
            if (ModelState.IsValid)
            {
                db.SoruKarti.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            ViewBag.Kategoriler = db.soruKategori
                                    .Select(k => new SelectListItem
                                    {
                                        Value = k.id.ToString(),
                                        Text = k.kategori
                                    }).ToList();


            ViewBag.Kullanicilar = db.kullaniciBilgileri
                .Select(n => new SelectListItem
                {
                    Value= n.id.ToString(),
                    Text=n.kullaniciAdi
                }).ToList();

            return View(model);
        }


        public ActionResult KartSil(int id)
        {
            
            var silinecekKart = db.SoruKarti.Find(id);
            if (silinecekKart != null)
            {
                db.SoruKarti.Remove(silinecekKart);
                db.SaveChanges();
            }

           
            var kartlar = db.SoruKarti.OrderBy(k => k.id).ToList();

            if (!kartlar.Any())
                return View("Index", new List<SoruKarti>());

            
            int index = 0;
            var aktifKart = kartlar[index];

            var sonrakiKartId = (index + 1 < kartlar.Count) ? kartlar[index + 1].id : kartlar[0].id;

            ViewBag.NextId = sonrakiKartId;
            ViewBag.Total = kartlar.Count;
            ViewBag.CurrentIndex = index + 1;

            return View("Index", new List<SoruKarti> { aktifKart });
        }

        public ActionResult KartBilgileriniGoruntule(int id)
        {
            var kartInfo = db.SoruKarti.Find(id);
            return View("KartBilgileriniGoruntule", kartInfo);
        }

        public ActionResult KartGuncelle(SoruKarti s)
        {
            var kart = db.SoruKarti.Find(s.id);
            kart.soru = s.soru;
            kart.cevap = s.cevap;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KartGoster(int? id, int? kategoriId)
        {
            var kartlar = db.SoruKarti
                            .Where(k => !kategoriId.HasValue || k.kategori == kategoriId)
                            .OrderBy(k => k.id)
                            .ToList();

            if (!kartlar.Any())
                return View("Index", new List<SoruKarti>());

            int index = 0;
            if (id.HasValue)
            {
                index = kartlar.FindIndex(k => k.id == id.Value);
                if (index == -1) index = 0;
            }

            var aktifKart = kartlar[index];
            int nextIndex = (index + 1) % kartlar.Count;

            ViewBag.NextId = kartlar[nextIndex].id;
            ViewBag.Total = kartlar.Count;
            ViewBag.CurrentIndex = index + 1;
            ViewBag.KategoriId = kategoriId;

            return View("Index", new List<SoruKarti> { aktifKart });
        }


        public ActionResult KategoriSecimEkrani()
        {
            var kategoriler = db.soruKategori.ToList();
            return View(kategoriler); 
        }


        public ActionResult YeniKategori()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniKategori(soruKategori s)
        {
            db.soruKategori.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
//kart güncelleme ve kart bilgileri görme kısımı okay
//kart silme de yapıyor



//kart ekleme kısımı kalmış ona başla
