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
    public class procesos_gestiones_incidenciasController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: procesos_gestiones_incidencias
        public ActionResult Index()
        {
            var procesos_gestiones_incidencias = db.procesos_gestiones_incidencias.Include(p => p.gestiones_incindecias).Include(p => p.procesos_incidencias);
            return View(procesos_gestiones_incidencias.ToList());
        }

        // GET: procesos_gestiones_incidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesos_gestiones_incidencias procesos_gestiones_incidencias = db.procesos_gestiones_incidencias.Find(id);
            if (procesos_gestiones_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(procesos_gestiones_incidencias);
        }

        // GET: procesos_gestiones_incidencias/Create
        public ActionResult Create()
        {
            ViewBag.ges_inc_idn = new SelectList(db.gestiones_incindecias, "ges_inc_idn", "ges_inc_nombre");
            ViewBag.pro_inc_idn = new SelectList(db.procesos_incidencias, "pro_inc_idn", "pro_inc_nombre");
            return View();
        }

        // POST: procesos_gestiones_incidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pro_ges_inc_idn,pro_inc_idn,ges_inc_idn")] procesos_gestiones_incidencias procesos_gestiones_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.procesos_gestiones_incidencias.Add(procesos_gestiones_incidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ges_inc_idn = new SelectList(db.gestiones_incindecias, "ges_inc_idn", "ges_inc_nombre", procesos_gestiones_incidencias.ges_inc_idn);
            ViewBag.pro_inc_idn = new SelectList(db.procesos_incidencias, "pro_inc_idn", "pro_inc_nombre", procesos_gestiones_incidencias.pro_inc_idn);
            return View(procesos_gestiones_incidencias);
        }

        // GET: procesos_gestiones_incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesos_gestiones_incidencias procesos_gestiones_incidencias = db.procesos_gestiones_incidencias.Find(id);
            if (procesos_gestiones_incidencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.ges_inc_idn = new SelectList(db.gestiones_incindecias, "ges_inc_idn", "ges_inc_nombre", procesos_gestiones_incidencias.ges_inc_idn);
            ViewBag.pro_inc_idn = new SelectList(db.procesos_incidencias, "pro_inc_idn", "pro_inc_nombre", procesos_gestiones_incidencias.pro_inc_idn);
            return View(procesos_gestiones_incidencias);
        }

        // POST: procesos_gestiones_incidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pro_ges_inc_idn,pro_inc_idn,ges_inc_idn")] procesos_gestiones_incidencias procesos_gestiones_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procesos_gestiones_incidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ges_inc_idn = new SelectList(db.gestiones_incindecias, "ges_inc_idn", "ges_inc_nombre", procesos_gestiones_incidencias.ges_inc_idn);
            ViewBag.pro_inc_idn = new SelectList(db.procesos_incidencias, "pro_inc_idn", "pro_inc_nombre", procesos_gestiones_incidencias.pro_inc_idn);
            return View(procesos_gestiones_incidencias);
        }

        // GET: procesos_gestiones_incidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            procesos_gestiones_incidencias procesos_gestiones_incidencias = db.procesos_gestiones_incidencias.Find(id);
            if (procesos_gestiones_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(procesos_gestiones_incidencias);
        }

        // POST: procesos_gestiones_incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            procesos_gestiones_incidencias procesos_gestiones_incidencias = db.procesos_gestiones_incidencias.Find(id);
            db.procesos_gestiones_incidencias.Remove(procesos_gestiones_incidencias);
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
