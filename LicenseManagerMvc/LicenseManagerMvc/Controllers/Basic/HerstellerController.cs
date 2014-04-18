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
    public class HerstellerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Hersteller/
        public ActionResult Index()
        {
            return View(db.Herstellers.ToList());
        }

        // GET: /Hersteller/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hersteller hersteller = db.Herstellers.Find(id);
            if (hersteller == null)
            {
                return HttpNotFound();
            }
            return View(hersteller);
        }

        // GET: /Hersteller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Hersteller/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HerstellerId,Name,Homepage,Sonstiges")] Hersteller hersteller)
        {
            if (ModelState.IsValid)
            {
                db.Herstellers.Add(hersteller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hersteller);
        }

        // GET: /Hersteller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hersteller hersteller = db.Herstellers.Find(id);
            if (hersteller == null)
            {
                return HttpNotFound();
            }
            return View(hersteller);
        }

        // POST: /Hersteller/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HerstellerId,Name,Homepage,Sonstiges")] Hersteller hersteller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hersteller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hersteller);
        }

        // GET: /Hersteller/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hersteller hersteller = db.Herstellers.Find(id);
            if (hersteller == null)
            {
                return HttpNotFound();
            }
            return View(hersteller);
        }

        // POST: /Hersteller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hersteller hersteller = db.Herstellers.Find(id);
            db.Herstellers.Remove(hersteller);
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
