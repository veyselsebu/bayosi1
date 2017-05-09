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
    public class ilacController : yoneticibase
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /ilac/
        public ActionResult yont()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.ilac.ToList());
        }

        // GET: /ilac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilac ilac = db.ilac.Find(id);
            if (ilac == null)
            {
                return HttpNotFound();
            }
            return View(ilac);
        }

        // GET: /ilac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ilac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ilac_id,ilac_ad,aciklama")] ilac ilac)
        {
            if (ModelState.IsValid)
            {
                db.ilac.Add(ilac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilac);
        }

        // GET: /ilac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilac ilac = db.ilac.Find(id);
            if (ilac == null)
            {
                return HttpNotFound();
            }
            return View(ilac);
        }

        // POST: /ilac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ilac_id,ilac_ad,aciklama")] ilac ilac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilac);
        }

        // GET: /ilac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilac ilac = db.ilac.Find(id);
            if (ilac == null)
            {
                return HttpNotFound();
            }
            return View(ilac);
        }

        // POST: /ilac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ilac ilac = db.ilac.Find(id);
            db.ilac.Remove(ilac);
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
