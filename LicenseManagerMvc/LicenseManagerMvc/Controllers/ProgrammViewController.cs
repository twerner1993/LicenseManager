using LicenseManagerMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LicenseManagerMvc.Controllers
{
    public class ProgrammViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /ProgrammView/
        public ActionResult Index()
        {
            var programms = db.Programms.Include(p => p.Genre).Include(p => p.Hersteller);

            List<ProgrammViewModel> programmViews = programmToProgrammViewModel(programms);
            return View(programmViews);
        }

        //
        // GET: /ProgrammView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programm prog = db.Programms.Find(id);
            if (prog == null)
            {
                return HttpNotFound();
            }

            return View(programmToProgrammViewModel(prog));
        }

        //
        // GET: /ProgrammView/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        //
        // POST: /ProgrammView/Create
        [HttpPost]
        public ActionResult Create([Bind(Include="ProgrammId,HerstellerName,GenreId,Name,Beschreibung")] ProgrammViewModel programmview)
        {
            try
            {
                if (!new HerstellerController().Exists(programmview.HerstellerName))
                {
                    new HerstellerController().Create(
                        new Hersteller
                        {
                            Name = programmview.HerstellerName
                        });
                }

                Hersteller hersteller = db.Herstellers.Where(h => h.Name == programmview.HerstellerName).Single();
                Genre genre = db.Genres.Find(programmview.GenreId);

                Programm programm = new Programm
                {
                    HerstellerId = hersteller.HerstellerId,
                    Hersteller = hersteller,
                    Genre = genre,
                    GenreId = genre.GenreId,
                    Name = programmview.Name,
                    Beschreibung = programmview.Beschreibung
                };

                //return new ProgrammController().Create(programm);

                db.Programms.Add(programm);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ProgrammView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ProgrammView/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ProgrammView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ProgrammView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected ProgrammViewModel programmToProgrammViewModel(Programm programm)
        {
            ProgrammViewModel programmView = new ProgrammViewModel
            {
                Genre = programm.Genre,
                Hersteller = programm.Hersteller,
                ProgrammId = programm.ProgrammId,
                Name = programm.Name,
                Beschreibung = programm.Beschreibung,
                Lizenzs = programm.Lizenzs
            };
            return programmView;
        }

        protected List<ProgrammViewModel> programmToProgrammViewModel(IEnumerable<Programm> programms)
        {
            List<ProgrammViewModel> programmViews = new List<ProgrammViewModel>();
            foreach (Programm item in programms)
            {
                programmViews.Add(programmToProgrammViewModel(item));
            }
            return programmViews;
        }
    }
}
