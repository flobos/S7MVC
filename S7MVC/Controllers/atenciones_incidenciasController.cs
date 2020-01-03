using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S7MVC.Models;


namespace S7MVC.Controllers
{
    public class atenciones_incidenciasController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: atenciones_incidencias
        public ActionResult Index()

        {
            Int64 _usu_idn = Convert.ToInt64(Session["usu_idn"]);

            ViewBag.usu_idn = _usu_idn;

            var _atenciones_incidencias = from a in db.atenciones_incidencias
                                          join b in db.atenciones on a.ate_idn equals b.ate_idn
                                          orderby a.ate_inc_fecha_ingreso descending
                                          where b.usu_idn == _usu_idn
                                          select a;
            return View(_atenciones_incidencias.ToList());
        }



        public ActionResult Index_funcionario()
        {
         
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index_muestra_incidencias(string v_rut, string v_fecha)
        {

            var _atenciones = from a in db.atenciones_incidencias
                              join b in db.atenciones on a.ate_idn equals b.ate_idn
                              join c in db.usuarios on b.usu_idn equals c.usu_idn
                              orderby a.ate_inc_fecha_ingreso descending
                              where c.usu_id_nacional == v_rut.Trim()
                              select a;
            

            return View(_atenciones.ToList());
        }


        public ActionResult Index_usuarios(int usu_idn)
        {
            var _atenciones_incidencias = from a in db.atenciones_incidencias
                                          join b in db.atenciones on a.ate_idn equals b.ate_idn
                                          orderby a.ate_inc_fecha_ingreso descending
                                          where b.usu_idn == usu_idn
                                          select a;
            return PartialView("_Index_usuarios", _atenciones_incidencias);
        }


        // GET: atenciones_incidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones_incidencias atenciones_incidencias = db.atenciones_incidencias.Find(id);
            if (atenciones_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(atenciones_incidencias);
        }

        // GET: atenciones_incidencias/Create
        public ActionResult Create()
        {
            ViewBag.ate_idn = new SelectList(db.atenciones, "ate_idn", "ate_idn");
            ViewBag.inc_idn = new SelectList(db.incidencias, "inc_idn", "inc_nombre");
            ViewBag.usu_pro_idn = new SelectList(db.usuarios_productos, "usu_pro_idn", "usu_pro_idn");
            return View();
        }

        // POST: atenciones_incidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ate_inc_idn,ate_idn,usu_pro_idn,inc_idn,ate_inc_fecha_ingreso,ate_inc_observacion,ate_inc_resuelta,ate_inc_resolucion,ate_inc_fecha_resuelta")] atenciones_incidencias atenciones_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.atenciones_incidencias.Add(atenciones_incidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ate_idn = new SelectList(db.atenciones, "ate_idn", "ate_idn", atenciones_incidencias.ate_idn);
            ViewBag.inc_idn = new SelectList(db.incidencias, "inc_idn", "inc_nombre", atenciones_incidencias.inc_idn);
            ViewBag.usu_pro_idn = new SelectList(db.usuarios_productos, "usu_pro_idn", "usu_pro_idn", atenciones_incidencias.usu_pro_idn);
            return View(atenciones_incidencias);
        }

        // GET: atenciones_incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones_incidencias atenciones_incidencias = db.atenciones_incidencias.Find(id);
            if (atenciones_incidencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.ate_idn = new SelectList(db.atenciones, "ate_idn", "ate_idn", atenciones_incidencias.ate_idn);
            ViewBag.inc_idn = new SelectList(db.incidencias, "inc_idn", "inc_nombre", atenciones_incidencias.inc_idn);
            ViewBag.usu_pro_idn = new SelectList(db.usuarios_productos, "usu_pro_idn", "usu_pro_idn", atenciones_incidencias.usu_pro_idn);
            return View(atenciones_incidencias);
        }

        // POST: atenciones_incidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ate_inc_idn,ate_idn,usu_pro_idn,inc_idn,ate_inc_fecha_ingreso,ate_inc_observacion,ate_inc_resuelta,ate_inc_resolucion,ate_inc_fecha_resuelta")] atenciones_incidencias atenciones_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atenciones_incidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ate_idn = new SelectList(db.atenciones, "ate_idn", "ate_idn", atenciones_incidencias.ate_idn);
            ViewBag.inc_idn = new SelectList(db.incidencias, "inc_idn", "inc_nombre", atenciones_incidencias.inc_idn);
            ViewBag.usu_pro_idn = new SelectList(db.usuarios_productos, "usu_pro_idn", "usu_pro_idn", atenciones_incidencias.usu_pro_idn);
            return View(atenciones_incidencias);
        }

        // GET: atenciones_incidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones_incidencias atenciones_incidencias = db.atenciones_incidencias.Find(id);
            if (atenciones_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(atenciones_incidencias);
        }

        // POST: atenciones_incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            atenciones_incidencias atenciones_incidencias = db.atenciones_incidencias.Find(id);
            db.atenciones_incidencias.Remove(atenciones_incidencias);
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
