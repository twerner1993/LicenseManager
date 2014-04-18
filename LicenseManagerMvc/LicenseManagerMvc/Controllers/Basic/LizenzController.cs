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
    public class LizenzController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Lizenz/
        public ActionResult Index()
        {
            var lizenzs = db.Lizenzs.Include(l => l.Programm);
            return View(lizenzs.ToList());
        }

        // GET: /Lizenz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lizenz lizenz = db.Lizenzs.Find(id);
            if (lizenz == null)
            {
                return HttpNotFound();
            }
            return View(lizenz);
        }

        // GET: /Lizenz/Create
        public ActionResult Create()
        {
            ViewBag.ProgrammId = new SelectList(db.Programms, "ProgrammId", "Name");
            return View();
        }

        // POST: /Lizenz/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LizenzId,ProgrammId,Edition,Schluessel")] Lizenz lizenz)
        {
            if (ModelState.IsValid)
            {
                db.Lizenzs.Add(lizenz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrammId = new SelectList(db.Programms, "ProgrammId", "Name", lizenz.ProgrammId);
            return View(lizenz);
        }

        // GET: /Lizenz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lizenz lizenz = db.Lizenzs.Find(id);
            if (lizenz == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrammId = new SelectList(db.Programms, "ProgrammId", "Name", lizenz.ProgrammId);
            return View(lizenz);
        }

        // POST: /Lizenz/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LizenzId,ProgrammId,Edition,Schluessel")] Lizenz lizenz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lizenz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrammId = new SelectList(db.Programms, "ProgrammId", "Name", lizenz.ProgrammId);
            return View(lizenz);
        }

        // GET: /Lizenz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lizenz lizenz = db.Lizenzs.Find(id);
            if (lizenz == null)
            {
                return HttpNotFound();
            }
            return View(lizenz);
        }

        // POST: /Lizenz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lizenz lizenz = db.Lizenzs.Find(id);
            db.Lizenzs.Remove(lizenz);
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
