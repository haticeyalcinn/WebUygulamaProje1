using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Utiliy;
using WebUygulamaProje1.Models;//veri çekme adımı için


namespace WebUygulamaProje1.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;//veri çekme adımı için

        public KitapTuruController(UygulamaDbContext context)//veri çekme adımı için
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index() 
        {
            List<KitapTuru> objKitapTuruList = _uygulamaDbContext.KitapTurleri.ToList();//veri çekme adımı için
            return View(objKitapTuruList);//objKitapTuruList Model olarak view e gönderilir.

        }

        public IActionResult Ekle()
        {
            return View();//View içi boş oldğundan KitapTuru/View/Ekle arıyor Bulursa onu gösterir,bulamazsa hata verir
        }


        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapturu)
        {
            if (ModelState.IsValid)//Form verilerinin,modelde belirtilen doğrulama kurallarına uygun olup olmadığını kontrol eder.
            {
                _uygulamaDbContext.KitapTurleri.Add(kitapturu);
                _uygulamaDbContext.SaveChanges();//SaveChanges yapmazsanız bilgiler veritabanına eklenmez
                return RedirectToAction("Index", "KitapTuru");//, kullanıcının KitapTuruController kontrolöründeki Index aksiyonuna yönlendirilmesini sağlar.

            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null|| id==0)//Bu şartlar olursa NotFound ekranı gösterir
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);//Bu id ye uyan satırları nesneye dönüştürüp getir
            if(kitapTuruVt==null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);
        }


        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapturu)
        {
            if (ModelState.IsValid)//Form verilerinin,modelde belirtilen doğrulama kurallarına uygun olup olmadığını kontrol eder.
            {
                _uygulamaDbContext.KitapTurleri.Update(kitapturu);
                _uygulamaDbContext.SaveChanges();//SaveChanges yapmazsanız bilgiler veritabanına eklenmez
                return RedirectToAction("Index", "KitapTuru");//, kullanıcının KitapTuruController kontrolöründeki Index aksiyonuna yönlendirilmesini sağlar.

            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)//Bu şartlar olursa NotFound ekranı gösterir
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);//Bu id ye uyan satırları nesneye dönüştürüp getir
            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);
        }
    }
}
