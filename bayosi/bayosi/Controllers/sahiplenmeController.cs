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
    public class sahiplenmeController : baseController
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /sahiplenme/
        public ActionResult Index()
        {
            var sahiplenme = db.sahiplenme.Include(s => s.hayvan);
            return View(sahiplenme.ToList());
        }

        // GET: /sahiplenme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sahiplenme sahiplenme = db.sahiplenme.Find(id);
            if (sahiplenme == null)
            {
                return HttpNotFound();
            }
            return View(sahiplenme);
        }

        // GET: /sahiplenme/Create
        public ActionResult Create()
        {
            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "hayvan_ad");
            return View();
        }

        // POST: /sahiplenme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="sahiplenme_id,kupe_no,sahiplenen_tc,ad,soyad,ev_tel,cep_tel,adress,sahiplenme_tarihi")] sahiplenme sahiplenme)
        {
            if (ModelState.IsValid)
            {
         
                db.sahiplenme.Add(sahiplenme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "hayvan_ad", sahiplenme.kupe_no);
            return View(sahiplenme);
        }

        // GET: /sahiplenme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sahiplenme sahiplenme = db.sahiplenme.Find(id);
            if (sahiplenme == null)
            {
                return HttpNotFound();
            }
            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "hayvan_ad", sahiplenme.kupe_no);
            return View(sahiplenme);
        }

        // POST: /sahiplenme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="sahiplenme_id,kupe_no,sahiplenen_tc,ad,soyad,ev_tel,cep_tel,adress,sahiplenme_tarihi")] sahiplenme sahiplenme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sahiplenme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "hayvan_ad", sahiplenme.kupe_no);
            return View(sahiplenme);
        }

        // GET: /sahiplenme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sahiplenme sahiplenme = db.sahiplenme.Find(id);
            if (sahiplenme == null)
            {
                return HttpNotFound();
            }
            return View(sahiplenme);
        }

        // POST: /sahiplenme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sahiplenme sahiplenme = db.sahiplenme.Find(id);
            db.sahiplenme.Remove(sahiplenme);
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
