using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LicenseManagerMvc.Models;

namespace LicenseManagerMvc.Controllers
{
    public class ProgrammController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Programm/
        public ActionResult Index()
        {
            var programms = db.Programms.Include(p => p.Genre).Include(p => p.Hersteller);
            return View(programms.ToList());
        }

        // GET: /Programm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programm programm = db.Programms.Find(id);
            if (programm == null)
            {
                return HttpNotFound();
            }
            return View(programm);
        }

        // GET: /Programm/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.HerstellerId = new SelectList(db.Herstellers, "HerstellerId", "Name");
            return View();
        }

        // POST: /Programm/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProgrammId,HerstellerId,GenreId,Name,Beschreibung")] Programm programm)
        {
            if (ModelState.IsValid)
            {
                db.Programms.Add(programm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", programm.GenreId);
            ViewBag.HerstellerId = new SelectList(db.Herstellers, "HerstellerId", "Name", programm.HerstellerId);
            return View(programm);
        }

        // GET: /Programm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programm programm = db.Programms.Find(id);
            if (programm == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", programm.GenreId);
            ViewBag.HerstellerId = new SelectList(db.Herstellers, "HerstellerId", "Name", programm.HerstellerId);
            return View(programm);
        }

        // POST: /Programm/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProgrammId,HerstellerId,GenreId,Name,Beschreibung")] Programm programm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", programm.GenreId);
            ViewBag.HerstellerId = new SelectList(db.Herstellers, "HerstellerId", "Name", programm.HerstellerId);
            return View(programm);
        }

        // GET: /Programm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programm programm = db.Programms.Find(id);
            if (programm == null)
            {
                return HttpNotFound();
            }
            return View(programm);
        }

        // POST: /Programm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programm programm = db.Programms.Find(id);
            db.Programms.Remove(programm);
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
