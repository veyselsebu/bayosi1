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
    public class meslekController : yoneticibase
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /meslek/
        public ActionResult Index()
        {
            return View(db.meslek.ToList());
        }

        // GET: /meslek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meslek meslek = db.meslek.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // GET: /meslek/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /meslek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="meslek_id,meslek_adi,meslek_açiklama")] meslek meslek)
        {
            if (ModelState.IsValid)
            {
                db.meslek.Add(meslek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meslek);
        }

        // GET: /meslek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meslek meslek = db.meslek.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // POST: /meslek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="meslek_id,meslek_adi,meslek_açiklama")] meslek meslek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meslek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meslek);
        }

        // GET: /meslek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            meslek meslek = db.meslek.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // POST: /meslek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            meslek meslek = db.meslek.Find(id);
            db.meslek.Remove(meslek);
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
