namespace Frio.mx.Controllers
{
    using Frio.mx.Helpers;
    using Frio.mx.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class TorneosController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult Index()
        {
            
            return View(db.Torneos
                .ToList()
                .OrderBy(t => t.Nombre));
        }


        public ActionResult AgregarEquipo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var torneo = db.Torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }

            var equipotorneo = new Equipo
            {
                TorneoId = torneo.TorneoId,
            };

            return View(equipotorneo);
        }

        [HttpPost]
        public ActionResult AgregarEquipo(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipos.Add(equipo);
                var response = DbHelper.SaveChanges(db);
                if (equipo.EscudoFile != null)
                {

                    var folder = "~/Content/Escudos";
                    var file = string.Format("{0}{1}.jpg", equipo.EquipoId, equipo.Nombre);
                    var responsefile = FileHelper.UploadPhoto(equipo.EscudoFile, folder, file);
                    if (responsefile)
                    {
                        var pic = string.Format("{0}/{1}", folder, file);
                        equipo.Escudo = pic;
                        db.Entry(equipo).State = EntityState.Modified;
                        db.SaveChanges();

                    }

                }
                if (response.Successfully)
                {
                    return RedirectToAction(string.Format("Details/{0}", equipo.TorneoId));

                }

                ModelState.AddModelError(string.Empty, response.Message);

            }



            return View(equipo);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var torneo = db.Torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Torneos.Add(torneo);
                var response = DbHelper.SaveChanges(db);
                if (torneo.LogoFile != null)
                {

                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}{1}.jpg", torneo.TorneoId, torneo.Nombre);
                    var responsefile = FileHelper.UploadPhoto(torneo.LogoFile, folder, file);
                    if (responsefile)
                    {
                        var pic = string.Format("{0}/{1}", folder, file);
                        torneo.Logo = pic;
                        db.Entry(torneo).State = EntityState.Modified;
                        db.SaveChanges();

                    }

                }
                if (response.Successfully)
                {
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError(string.Empty, response.Message);

            }



            return View(torneo);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var torneo = db.Torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo).State = EntityState.Modified;
                var response = DbHelper.SaveChanges(db);
                if (torneo.LogoFile != null)
                {

                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}{1}.jpg", torneo.TorneoId, torneo.Nombre);
                    var responsefile = FileHelper.UploadPhoto(torneo.LogoFile, folder, file);
                    if (responsefile)
                    {
                        var pic = string.Format("{0}/{1}", folder, file);
                        torneo.Logo = pic;
                        db.Entry(torneo).State = EntityState.Modified;
                        db.SaveChanges();

                    }

                }
                if (response.Successfully)
                {
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            return View(torneo);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var torneo = db.Torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var torneo = db.Torneos.Find(id);
            db.Torneos.Remove(torneo);
            var response = DbHelper.SaveChanges(db);
            if (response.Successfully)
            {
                return RedirectToAction("Index");

            }
            ModelState.AddModelError(string.Empty, response.Message);

            return View(torneo);
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
