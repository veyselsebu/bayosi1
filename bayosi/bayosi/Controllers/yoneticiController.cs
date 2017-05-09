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
    public class yoneticiController : Controller
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /yonetici/
        public ActionResult cikis()
        {
            Session["yonetici"] = null;


            return RedirectToAction("Index", "yonetici");
        }


        public ActionResult giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult giris(yonetici Model)
        {
            var yonetici = db.yonetici.FirstOrDefault(x => x.yoneticiAd == Model.yoneticiAd && x.sifre == Model.sifre);
            if (yonetici != null)
            {
                Session["yonetici"] = yonetici;
                return RedirectToAction("yont", "ilac");
            }
            return RedirectToAction("giris", "yonetici");
            //ViewBag.HATA("kullanici adi veya sifre hatai");
            //return View();
        }
        public ActionResult Index()
        {
            return View(db.yonetici.ToList());
        }

        // GET: /yonetici/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yonetici yonetici = db.yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // GET: /yonetici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /yonetici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="yoneticiAd,sifre,mail")] yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.yonetici.Add(yonetici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yonetici);
        }

        // GET: /yonetici/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yonetici yonetici = db.yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: /yonetici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="yoneticiAd,sifre,mail")] yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yonetici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yonetici);
        }

        // GET: /yonetici/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yonetici yonetici = db.yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: /yonetici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            yonetici yonetici = db.yonetici.Find(id);
            db.yonetici.Remove(yonetici);
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
