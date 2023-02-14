using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniSatis(SATISLAR p)
        {
            db.SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}