using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP1Examen.Models;

namespace ASP1Examen.Controllers
{
    public class VillesController : Controller
    {
        private ASP1ModuleEntities db = new ASP1ModuleEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.VilleSet.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Ville ville = db.VilleSet.Find(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Ville ville)
        {
            if (ModelState.IsValid)
            {
                db.VilleSet.Add(ville);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ville);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ville ville = db.VilleSet.Find(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Ville ville)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ville).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ville);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ville ville = db.VilleSet.Find(id);
            if (ville == null)
            {
                return HttpNotFound();
            }
            return View(ville);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ville ville = db.VilleSet.Find(id);
            db.VilleSet.Remove(ville);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BatchDelete()
        {
            var ids = Request.Params["Batch"].Split(',').Where(s => s != "false").Select(s => int.Parse(s));

            foreach (var id in ids)
            {
                var ville = db.VilleSet.Find(id);
                db.VilleSet.Remove(ville);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}