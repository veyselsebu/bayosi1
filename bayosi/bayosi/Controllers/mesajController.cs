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
    public class mesajController : baseController
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /mesaj/
        public ActionResult Index()
        {
            return View(db.mesaj.ToList());
        }

        // GET: /mesaj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesaj mesaj = db.mesaj.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // GET: /mesaj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /mesaj/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="mesaj_id,mesaj_baslik,icerik")] mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                db.mesaj.Add(mesaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mesaj);
        }

        // GET: /mesaj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesaj mesaj = db.mesaj.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // POST: /mesaj/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="mesaj_id,mesaj_baslik,icerik")] mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mesaj);
        }

        // GET: /mesaj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesaj mesaj = db.mesaj.Find(id);
            if (mesaj == null)
            {
                return HttpNotFound();
            }
            return View(mesaj);
        }

        // POST: /mesaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mesaj mesaj = db.mesaj.Find(id);
            db.mesaj.Remove(mesaj);
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
