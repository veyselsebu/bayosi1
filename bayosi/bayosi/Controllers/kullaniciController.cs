using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bayosi.Models;

namespace bayosi.Controllers
{
    public class kullaniciController : Controller
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /kullanici/

        public ActionResult cikis()
        {
            Session["kullaniciadi"] = null;


            return RedirectToAction("Index", "Home");
        }
       
        
        public ActionResult giris()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult giris(kullanici Model)
        {
            var KULLANICI = db.kullanici.FirstOrDefault(x => x.kullaniciAdi == Model.kullaniciAdi && x.parola == Model.parola);
            if(KULLANICI!=null)
            {
                Session["kullaniciAdi"] = KULLANICI.tcNo;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ERR", "Home");
            //ViewBag.HATA("kullanici adi veya sifre hatai");
            //return View();
        }
        public ActionResult Index()
        {
            var kullanici = db.kullanici.Include(k => k.personel);
            return View(kullanici.ToList());
        }

        // GET: /kullanici/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: /kullanici/Create
        public ActionResult Create()
        {
            ViewBag.tcNo = new SelectList(db.personel, "tc_no", "isim");
            return View();
        }

        // POST: /kullanici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="kullaniciAdi,parola,tcNo")] kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tcNo = new SelectList(db.personel, "tc_no", "isim", kullanici.tcNo);
            return View(kullanici);
        }

        // GET: /kullanici/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.tcNo = new SelectList(db.personel, "tc_no", "isim", kullanici.tcNo);
            return View(kullanici);
        }

        // POST: /kullanici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="kullaniciAdi,parola,tcNo")] kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tcNo = new SelectList(db.personel, "tc_no", "isim", kullanici.tcNo);
            return View(kullanici);
        }

        // GET: /kullanici/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: /kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            kullanici kullanici = db.kullanici.Find(id);
            db.kullanici.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
