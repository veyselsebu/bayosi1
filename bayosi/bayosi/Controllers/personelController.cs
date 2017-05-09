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
    public class personelController : Controller
    {
        private barinak_otomasyonEntities3 db = new barinak_otomasyonEntities3();

        // GET: /personel/
        public ActionResult Index()
        {
            var personel = db.personel.Include(p => p.meslek);
            return View(personel.ToList());
        }

        // GET: /personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = db.personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: /personel/Create
        public ActionResult Create()
        {
            ViewBag.meslek_id = new SelectList(db.meslek, "meslek_id", "meslek_adi");
            return View();
        }

        // POST: /personel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="tc_no,isim,soyisim,tel_no,adres,meslek_id,resim")] personel personel)
        {
            if (ModelState.IsValid)
            {
                db.personel.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.meslek_id = new SelectList(db.meslek, "meslek_id", "meslek_adi", personel.meslek_id);
            return View(personel);
        }

        // GET: /personel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = db.personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.meslek_id = new SelectList(db.meslek, "meslek_id", "meslek_adi", personel.meslek_id);
            return View(personel);
        }

        // POST: /personel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="tc_no,isim,soyisim,tel_no,adres,meslek_id,resim")] personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.meslek_id = new SelectList(db.meslek, "meslek_id", "meslek_adi", personel.meslek_id);
            return View(personel);
        }

        // GET: /personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = db.personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: /personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personel personel = db.personel.Find(id);
            db.personel.Remove(personel);
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
