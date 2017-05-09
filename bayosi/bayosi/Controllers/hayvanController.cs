using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bayosi.Models;
using bayosi.utils;

namespace bayosi.Controllers
{
    public class hayvanController : baseController
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /hayvan/
        public ActionResult Index()
        {
            var hayvan = db.hayvan.Include(h => h.cikis_sebebi).Include(h => h.gelis_sebebi).Include(h => h.irk).Include(h => h.tur);
            return View(hayvan.ToList());
        }

        // GET: /hayvan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hayvan hayvan = db.hayvan.Find(id);
            if (hayvan == null)
            {
                return HttpNotFound();
            }
            return View(hayvan);
        }

        // GET: /hayvan/Create
        public ActionResult Create()
        {
            ViewBag.cikis_sebebi_id = new SelectList(db.cikis_sebebi, "cikis_sebebi_id", "cikis_sebebi1");
            ViewBag.gelis_sebebi_id = new SelectList(db.gelis_sebebi, "gelis_sebebi_id", "gelis_sebebi1");
            ViewBag.ırk_ıd = new SelectList(db.irk, "irk_id", "irk_adi");
            ViewBag.tur_id = new SelectList(db.tur, "tur_id", "tur_aciklama");
            return View();
        }

        // POST: /hayvan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="kupe_no,tur_id,ırk_ıd,gelis_sebebi_id,cikis_sebebi_id,hayvan_ad,hayvan_resim,barinak_gelis_tarihi,barinak_cikis_tarihi,sahip_isim,sahip_adress,sahip_telno")] hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                db.hayvan.Add(hayvan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cikis_sebebi_id = new SelectList(db.cikis_sebebi, "cikis_sebebi_id", "cikis_sebebi1", hayvan.cikis_sebebi_id);
            ViewBag.gelis_sebebi_id = new SelectList(db.gelis_sebebi, "gelis_sebebi_id", "gelis_sebebi1", hayvan.gelis_sebebi_id);
            ViewBag.ırk_ıd = new SelectList(db.irk, "irk_id", "irk_adi", hayvan.ırk_ıd);
            ViewBag.tur_id = new SelectList(db.tur, "tur_id", "tur_aciklama", hayvan.tur_id);
            return View(hayvan);
        }

        // GET: /hayvan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hayvan hayvan = db.hayvan.Find(id);
            if (hayvan == null)
            {
                return HttpNotFound();
            }
            ViewBag.cikis_sebebi_id = new SelectList(db.cikis_sebebi, "cikis_sebebi_id", "cikis_sebebi1", hayvan.cikis_sebebi_id);
            ViewBag.gelis_sebebi_id = new SelectList(db.gelis_sebebi, "gelis_sebebi_id", "gelis_sebebi1", hayvan.gelis_sebebi_id);
            ViewBag.ırk_ıd = new SelectList(db.irk, "irk_id", "irk_adi", hayvan.ırk_ıd);
            ViewBag.tur_id = new SelectList(db.tur, "tur_id", "tur_aciklama", hayvan.tur_id);
            return View(hayvan);
        }

        // POST: /hayvan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="kupe_no,tur_id,ırk_ıd,gelis_sebebi_id,cikis_sebebi_id,hayvan_ad,hayvan_resim,barinak_gelis_tarihi,barinak_cikis_tarihi,sahip_isim,sahip_adress,sahip_telno")] hayvan hayvan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hayvan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cikis_sebebi_id = new SelectList(db.cikis_sebebi, "cikis_sebebi_id", "cikis_sebebi1", hayvan.cikis_sebebi_id);
            ViewBag.gelis_sebebi_id = new SelectList(db.gelis_sebebi, "gelis_sebebi_id", "gelis_sebebi1", hayvan.gelis_sebebi_id);
            ViewBag.ırk_ıd = new SelectList(db.irk, "irk_id", "irk_adi", hayvan.ırk_ıd);
            ViewBag.tur_id = new SelectList(db.tur, "tur_id", "tur_aciklama", hayvan.tur_id);
            return View(hayvan);
        }

        // GET: /hayvan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hayvan hayvan = db.hayvan.Find(id);
            if (hayvan == null)
            {
                return HttpNotFound();
            }
            return View(hayvan);
        }

        // POST: /hayvan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hayvan hayvan = db.hayvan.Find(id);
            db.hayvan.Remove(hayvan);
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
