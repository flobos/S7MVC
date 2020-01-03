using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S7MVC.Models;
using S7MVC.ViewModels;

namespace S7MVC.Controllers
{
    public class atencionesController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: atenciones
        public ActionResult Index()
        {
            var atenciones = db.atenciones.Include(a => a.empresas_usuarios_sedes);
            return View(atenciones.ToList());
        }

        // GET: atenciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones atenciones = db.atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        // GET: atenciones/Create
        public ActionResult Create(int usu_idn)
        {
            vm_atenciones_incidencias _vm_atenciones_incidencias = new vm_atenciones_incidencias();


            ViewBag.usu_idn = usu_idn;

            int _usu_idn = usu_idn;

            _vm_atenciones_incidencias.usu_idn = _usu_idn;


            var _productos = from a in db.usuarios_productos
                            join b in db.productos on a.pro_idn equals b.pro_idn
                            where a.usu_idn == _usu_idn
                             select new vm_usuarios_productos_combo()
                            {
                                usu_pro_idn = a.usu_pro_idn,
                                pro_nombre = b.pro_nombre
                            };

            var _incidencias = from a in db.incidencias
                               orderby a.inc_nombre
                               select a;

            var _tipo_incidencias = from a in db.tipos_incidencias
                               orderby a.tip_inc_nombre
                               select a;


            ViewBag.usu_pro_idn = new SelectList(_productos, "usu_pro_idn", "pro_nombre");
            ViewBag.inc_idn = new SelectList(_incidencias, "inc_idn", "inc_nombre");
            ViewBag.tip_inc_idn = new SelectList(_tipo_incidencias, "tip_inc_idn", "tip_inc_nombre");


            return View(_vm_atenciones_incidencias);
        }

        public JsonResult p_llena_combo_incidencias(int id)
        {

            var incidencias = from a in db.incidencias
                              where a.tip_inc_idn == id
                              select a;


            var _resultado = new SelectList(incidencias, "inc_idn", "inc_nombre");
            return Json(_resultado, JsonRequestBehavior.AllowGet);


        }



        // POST: atenciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vm_atenciones_incidencias _vm_atenciones_incidencias)
        {
            if (ModelState.IsValid)
            {

                atenciones_incidencias _atenciones_incidencias = new atenciones_incidencias();
                atenciones _atenciones = new atenciones();
                atenciones_procesos_incidencias _atenciones_procesos_incidencias = new atenciones_procesos_incidencias();


                _atenciones_procesos_incidencias.ate_pro_inc_fecha_ingreso = DateTime.Now;
                _atenciones_procesos_incidencias.ate_pro_inc_fecha_inicio_atencion = DateTime.Now;
                _atenciones_procesos_incidencias.emp_usu_sed_idn = 1;
                _atenciones_procesos_incidencias.pro_ges_inc_idn = 19;
                _atenciones_procesos_incidencias.ate_pro_inc_observacion = "--";


                _atenciones_incidencias.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias);

                _atenciones_incidencias.ate_inc_fecha_ingreso = DateTime.Now;
                _atenciones_incidencias.ate_inc_observacion = _vm_atenciones_incidencias.ate_inc_observacion.Trim();
                _atenciones_incidencias.usu_pro_idn = _vm_atenciones_incidencias.usu_pro_idn;
                _atenciones_incidencias.inc_idn = _vm_atenciones_incidencias.inc_idn;
                

              _atenciones.atenciones_incidencias.Add(_atenciones_incidencias);
                _atenciones.ate_fecha_ingreso = DateTime.Now;
                _atenciones.emp_usu_sed_idn = 1; //----
                _atenciones.ate_cerrada = false;
                _atenciones.usu_idn = _vm_atenciones_incidencias.usu_idn;

                db.atenciones.Add(_atenciones);
                db.SaveChanges();


                return RedirectToAction("index", "atenciones_incidencias", new { usu_idn = _atenciones.usu_idn });
            }

          
            return View();
        }

        // GET: atenciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones atenciones = db.atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_usu_sed_idn = new SelectList(db.empresas_usuarios_sedes, "emp_usu_sed_idn", "emp_usu_sed_idn", atenciones.emp_usu_sed_idn);
            return View(atenciones);
        }

        // POST: atenciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ate_idn,usu_idn,ate_fecha_ingreso,ate_cerrada,emp_usu_sed_idn")] atenciones atenciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atenciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_usu_sed_idn = new SelectList(db.empresas_usuarios_sedes, "emp_usu_sed_idn", "emp_usu_sed_idn", atenciones.emp_usu_sed_idn);
            return View(atenciones);
        }

        // GET: atenciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones atenciones = db.atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        // POST: atenciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            atenciones atenciones = db.atenciones.Find(id);
            db.atenciones.Remove(atenciones);
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
