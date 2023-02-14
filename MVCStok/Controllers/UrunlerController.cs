using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniUrun(Urunler p1)
        {
            var ktg = db.Kategoriler.Where(m => m.KATEGORIID == p1.Kategoriler.KATEGORIID).FirstOrDefault();
            p1.Kategoriler = ktg;
            db.Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View(urun);
        }

        public ActionResult Guncelle(Urunler p1)
        {
            var urun = db.Urunler.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.Stok = p1.Stok;
            urun.FIYAT = p1.FIYAT;
            var k = db.Kategoriler.Where(m => m.KATEGORIID == p1.Kategoriler.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = k.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}