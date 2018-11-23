using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Goof_.Models;

namespace Goof_.Controllers
{
    public class MascotasController : Controller
    {
        private Goof_Db db = new Goof_Db();

        // GET: Mascotas
		[Authorize]
        public ActionResult Index()
        {

            var mascotas = db.Mascotas.Include(m => m.Usuarios);
            return View(mascotas.ToList());
        }


		public ActionResult Busqueda(string buscarMascota)
		{
			if (!String.IsNullOrEmpty(buscarMascota))
			{
				var mascotabusq = db.Mascotas.Include(m => m.Nombre.Contains(buscarMascota));
				mascotabusq = db.Mascotas.Include(m => m.Raza.Contains(buscarMascota));
				mascotabusq = db.Mascotas.Include(m => m.Genero.Contains(buscarMascota));
				return View(mascotabusq.ToList());
			}
			return RedirectToAction("Index");
		}

		public ActionResult Busqueda(int buscarMascota)
		{			
				var mascotabusq = db.Mascotas.Include(m => m.Edad.Equals(buscarMascota));
				return View(mascotabusq.ToList());
		
		}



		// GET: Mascotas/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

		// GET: Mascotas/Create
		[Authorize]
		public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NombreUsu");
            return View();
        }

		// POST: Mascotas/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Create(MascotaViewModel mascotas)
		{
			 
			
			if (ModelState.IsValid)
            {
				var idUser = 1;// ((Goof_.Models.Usuarios)Session["Auth"]).IdUsuario;

				db.Mascotas.Add(new Mascotas() { IdUsuario = idUser, Nombre = mascotas.Nombre, Genero = mascotas.Genero,
					Raza = mascotas.Raza, Papeles = mascotas.Papeles == true ? 1 : 0,
					Vacunas = mascotas.Vacunas == true ? 1 : 0, ColorPelo = mascotas.ColorPelo,
					Edad = mascotas.Edad, Peso = mascotas.Peso, LikeCount=0, } );
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NombreUsu",);
            return View();
        }

        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NombreUsu", mascotas.IdUsuario);
            return View(mascotas);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMascota,Nombre,Genero,Raza,Edad,ColorPelo,Peso,Vacunas,Papeles,LikeCount,IdUsuario")] Mascotas mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NombreUsu", mascotas.IdUsuario);
            return View(mascotas);
        }

        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascotas mascotas = db.Mascotas.Find(id);
            if (mascotas == null)
            {
                return HttpNotFound();
            }
            return View(mascotas);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascotas mascotas = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascotas);
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
