using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MvcQuizSonDeneme.Models.EntityFramework;

namespace MvcQuizSon.Controllers
{
    public class GirisController : Controller
    {
        MvcQuizYeniEntities db = new MvcQuizYeniEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(kullaniciBilgileri t)
        {
            var bilgiler = db.kullaniciBilgileri
                .FirstOrDefault(x => x.kullaniciAdi == t.kullaniciAdi && x.sifre == t.sifre);

            if (bilgiler == null)
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre yanlış!";
                return View("Index");
            }
            FormsAuthentication.SetAuthCookie(bilgiler.kullaniciAdi, false);
            return RedirectToAction("KategoriSecimEkrani", "MemoryKart");
        }
    }
}
