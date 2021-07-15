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
    public class ACCESOPREMIERsController : Controller
    {
        private dbCineNCapasaEntities db = new dbCineNCapasaEntities();

        // GET: ACCESOPREMIERs
        public ActionResult Index()
        {
            var aCCESOPREMIER = db.ACCESOPREMIER.Include(a => a.PERSONA).Include(a => a.PELICULA);
            return View(aCCESOPREMIER.ToList());
        }

        // GET: ACCESOPREMIERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCESOPREMIER aCCESOPREMIER = db.ACCESOPREMIER.Find(id);
            if (aCCESOPREMIER == null)
            {
                return HttpNotFound();
            }
            return View(aCCESOPREMIER);
        }

        // GET: ACCESOPREMIERs/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.PERSONA, "idPersona", "nombre");
            ViewBag.nombrePelicula = new SelectList(db.PELICULA, "nombre", "clasificacion");
            return View();
        }

        // POST: ACCESOPREMIERs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPremier,nombrePelicula,idPersona")] ACCESOPREMIER aCCESOPREMIER)
        {
            if (ModelState.IsValid)
            {
                db.ACCESOPREMIER.Add(aCCESOPREMIER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.PERSONA, "idPersona", "nombre", aCCESOPREMIER.idPersona);
            ViewBag.nombrePelicula = new SelectList(db.PELICULA, "nombre", "clasificacion", aCCESOPREMIER.nombrePelicula);
            return View(aCCESOPREMIER);
        }

        // GET: ACCESOPREMIERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCESOPREMIER aCCESOPREMIER = db.ACCESOPREMIER.Find(id);
            if (aCCESOPREMIER == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.PERSONA, "idPersona", "nombre", aCCESOPREMIER.idPersona);
            ViewBag.nombrePelicula = new SelectList(db.PELICULA, "nombre", "clasificacion", aCCESOPREMIER.nombrePelicula);
            return View(aCCESOPREMIER);
        }

        // POST: ACCESOPREMIERs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPremier,nombrePelicula,idPersona")] ACCESOPREMIER aCCESOPREMIER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCCESOPREMIER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.PERSONA, "idPersona", "nombre", aCCESOPREMIER.idPersona);
            ViewBag.nombrePelicula = new SelectList(db.PELICULA, "nombre", "clasificacion", aCCESOPREMIER.nombrePelicula);
            return View(aCCESOPREMIER);
        }

        // GET: ACCESOPREMIERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCESOPREMIER aCCESOPREMIER = db.ACCESOPREMIER.Find(id);
            if (aCCESOPREMIER == null)
            {
                return HttpNotFound();
            }
            return View(aCCESOPREMIER);
        }

        // POST: ACCESOPREMIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACCESOPREMIER aCCESOPREMIER = db.ACCESOPREMIER.Find(id);
            db.ACCESOPREMIER.Remove(aCCESOPREMIER);
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
