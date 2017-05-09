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
    public class tedaviController : baseController
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /tedavi/
        public ActionResult Index()
        {
            var tedavi = db.tedavi.Include(t => t.hayvan).Include(t => t.ilac).Include(t => t.personel);
            return View(tedavi.ToList());
        }

        // GET: /tedavi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tedavi tedavi = db.tedavi.Find(id);
            if (tedavi == null)
            {
                return HttpNotFound();
            }
            return View(tedavi);
        }

        // GET: /tedavi/Create
        public ActionResult Create()
        {
            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "kupe_no");
            ViewBag.ilac_id = new SelectList(db.ilac, "ilac_id", "ilac_ad");
            ViewBag.personel_tc_no = new SelectList(db.personel, "tc_no", "isim");
            return View();
        }

        // POST: /tedavi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="tedavi_id,kupe_no,personel_tc_no,ilac_id,doz,aciklama")] tedavi tedavi)
        {
            if (ModelState.IsValid)
            {
                db.tedavi.Add(tedavi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "kupe_no", tedavi.kupe_no);
            ViewBag.ilac_id = new SelectList(db.ilac, "ilac_id", "ilac_ad", tedavi.ilac_id);
            ViewBag.personel_tc_no = new SelectList(db.personel, "tc_no", "isim"+"soyisim" , tedavi.personel_tc_no);
            return View(tedavi);
        }

        // GET: /tedavi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tedavi tedavi = db.tedavi.Find(id);
            if (tedavi == null)
            {
                return HttpNotFound();
            }
            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "hayvan_ad", tedavi.kupe_no);
            ViewBag.ilac_id = new SelectList(db.ilac, "ilac_id", "ilac_ad", tedavi.ilac_id);
            ViewBag.personel_tc_no = new SelectList(db.personel, "tc_no", "isim", tedavi.personel_tc_no);
            return View(tedavi);
        }

        // POST: /tedavi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="tedavi_id,kupe_no,personel_tc_no,ilac_id,doz,aciklama")] tedavi tedavi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tedavi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kupe_no = new SelectList(db.hayvan, "kupe_no", "hayvan_ad", tedavi.kupe_no);
            ViewBag.ilac_id = new SelectList(db.ilac, "ilac_id", "ilac_ad", tedavi.ilac_id);
            ViewBag.personel_tc_no = new SelectList(db.personel, "tc_no", "isim", tedavi.personel_tc_no);
            return View(tedavi);
        }

        // GET: /tedavi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tedavi tedavi = db.tedavi.Find(id);
            if (tedavi == null)
            {
                return HttpNotFound();
            }
            return View(tedavi);
        }

        // POST: /tedavi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tedavi tedavi = db.tedavi.Find(id);
            db.tedavi.Remove(tedavi);
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
