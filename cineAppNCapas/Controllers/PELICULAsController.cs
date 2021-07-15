using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cineAppNCapas.Models;

namespace cineAppNCapas.Controllers
{
    public class PELICULAsController : Controller
    {
        private dbCineNCapasaEntities db = new dbCineNCapasaEntities();

        // GET: PELICULAs
        public ActionResult Index()
        {
            return View(db.PELICULA.ToList());
        }

        // GET: PELICULAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULA pELICULA = db.PELICULA.Find(id);
            if (pELICULA == null)
            {
                return HttpNotFound();
            }
            return View(pELICULA);
        }

        // GET: PELICULAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PELICULAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,fecha,duracion,clasificacion,estudio,director,genero")] PELICULA pELICULA)
        {
            if (ModelState.IsValid)
            {
                db.PELICULA.Add(pELICULA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pELICULA);
        }

        // GET: PELICULAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULA pELICULA = db.PELICULA.Find(id);
            if (pELICULA == null)
            {
                return HttpNotFound();
            }
            return View(pELICULA);
        }

        // POST: PELICULAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,fecha,duracion,clasificacion,estudio,director,genero")] PELICULA pELICULA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pELICULA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pELICULA);
        }

        // GET: PELICULAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PELICULA pELICULA = db.PELICULA.Find(id);
            if (pELICULA == null)
            {
                return HttpNotFound();
            }
            return View(pELICULA);
        }

        // POST: PELICULAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PELICULA pELICULA = db.PELICULA.Find(id);
            db.PELICULA.Remove(pELICULA);
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
