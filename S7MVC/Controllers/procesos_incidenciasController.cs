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
    public class procesos_incidenciasController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: procesos_incidencias
        public ActionResult Index()
        {
            return View(db.procesos_incidencias.ToList());
        }


        public ActionResult index_solucion(int ate_inc_idn) {


            int _solucion_existe = (from a in db.atenciones_procesos_incidencias
                           where a.ate_inc_idn == ate_inc_idn && a.pro_ges_inc_idn == 35
                           select a).Count();


            

            if (_solucion_existe > 0)
            {

              var  _solucion = from a in db.atenciones_procesos_incidencias
                                where a.ate_inc_idn == ate_inc_idn && a.pro_ges_inc_idn == 33
                                select a;

                return PartialView("_index_solucion", _solucion.ToList());
            }
            else {

             var   _solucion = from a in db.atenciones_procesos_incidencias
                                where a.ate_inc_idn == ate_inc_idn && a.pro_ges_inc_idn == 0
                                select a;
                return PartialView("_index_solucion", _solucion.ToList());

            }

           
        }

        // GET: procesos_incidencias
        public ActionResult Index_seccion_procesos_incidencias(int ate_inc_idn)
        {


            Int64 _pro_inc_idn_max;

            ViewBag.ate_inc_idn = ate_inc_idn;

            _pro_inc_idn_max = (Int64)(from a in db.procesos_gestiones_incidencias
                                     join b in db.atenciones_procesos_incidencias on a.pro_ges_inc_idn equals b.pro_ges_inc_idn
                                     join c in db.atenciones_incidencias on b.ate_inc_idn equals c.ate_inc_idn
                                     join d in db.atenciones on c.ate_idn equals d.ate_idn
                                     where c.ate_inc_idn == ate_inc_idn
                                     select a.pro_inc_idn).Max();

            




            ViewBag._pro_inc_idn_max = _pro_inc_idn_max;

            var _procesos_incidencias = from a in db.procesos_incidencias
                                        orderby a.pro_inc_idn ascending
                                        select a;    

            return View(_procesos_incidencias.ToList());

        }


        // GET: procesos_incidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesos_incidencias procesos_incidencias = db.procesos_incidencias.Find(id);
            if (procesos_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(procesos_incidencias);
        }

        // GET: procesos_incidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: procesos_incidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pro_inc_idn,pro_inc_nombre")] procesos_incidencias procesos_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.procesos_incidencias.Add(procesos_incidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procesos_incidencias);
        }

        // GET: procesos_incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesos_incidencias procesos_incidencias = db.procesos_incidencias.Find(id);
            if (procesos_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(procesos_incidencias);
        }

        // POST: procesos_incidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pro_inc_idn,pro_inc_nombre")] procesos_incidencias procesos_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procesos_incidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procesos_incidencias);
        }

        // GET: procesos_incidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesos_incidencias procesos_incidencias = db.procesos_incidencias.Find(id);
            if (procesos_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(procesos_incidencias);
        }

        // POST: procesos_incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            procesos_incidencias procesos_incidencias = db.procesos_incidencias.Find(id);
            db.procesos_incidencias.Remove(procesos_incidencias);
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
