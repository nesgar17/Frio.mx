namespace Frio.mx.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Frio.mx.Helpers;
    using Frio.mx.Models;

    public class TemporadasController : Controller
    {
        private DataContext db = new DataContext();

      
        public ActionResult Index()
        {
            var temporadas = db.Temporadas.Include(t => t.Torneo);
            return View(temporadas.ToList().OrderBy(t => t.Torneo));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var temporada = db.Temporadas.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        public ActionResult Create()
        {
            ViewBag.TorneoId = new SelectList(CombosHelper.GetTorneos(), "TorneoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Temporadas.Add(temporada);
                var response = DbHelper.SaveChanges(db);
                if (response.Successfully)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);


            }

            ViewBag.TorneoId = new SelectList(CombosHelper.GetTorneos(), "TorneoId", "Nombre", temporada.TorneoId);
            return View(temporada);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var temporada = db.Temporadas.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.TorneoId = new SelectList(CombosHelper.GetTorneos(), "TorneoId", "Nombre", temporada.TorneoId);
            return View(temporada);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                var response =  DbHelper.SaveChanges(db);
                if (response.Successfully)
                {
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError(string.Empty, response.Message);

            }
            ViewBag.TorneoId = new SelectList(CombosHelper.GetTorneos(), "TorneoId", "Nombre", temporada.TorneoId);
            return View(temporada);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var temporada = db.Temporadas.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var temporada = db.Temporadas.Find(id);
            db.Temporadas.Remove(temporada);
            var response = DbHelper.SaveChanges(db);
            if (response.Successfully)
            {
                return RedirectToAction("Index");

            }
            ModelState.AddModelError(string.Empty, response.Message);

            return View(temporada);
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
