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
    public class atenciones_procesos_incidenciasController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: atenciones_procesos_incidencias
        public ActionResult Index(int ate_inc_idn)
        {
            var _atenciones_procesos_incidencias = from a in db.atenciones_procesos_incidencias
                                                   where a.ate_inc_idn == ate_inc_idn
                                                   orderby a.ate_pro_inc_fecha_ingreso descending
                                                   select a;

           
            return View(_atenciones_procesos_incidencias.ToList());
        }

        public ActionResult Index_funcionario(int ate_inc_idn)
        {
            var _atenciones_procesos_incidencias = from a in db.atenciones_procesos_incidencias
                                                   where a.ate_inc_idn == ate_inc_idn
                                                   orderby a.ate_pro_inc_fecha_ingreso descending
                                                   select a;


            return PartialView("_Index_funcionario", _atenciones_procesos_incidencias.ToList());
        }


        public ActionResult Index_funcionario_cerrada(int ate_inc_idn)
        {
            var _atenciones_procesos_incidencias = from a in db.atenciones_procesos_incidencias
                                                   where a.ate_inc_idn == ate_inc_idn
                                                   orderby a.ate_pro_inc_fecha_ingreso descending
                                                   select a;


            return View(_atenciones_procesos_incidencias.ToList());
        }




        public ActionResult Index_funcionario_nogestiona(int ate_inc_idn)
        {

            ViewBag.ate_inc_idn = ate_inc_idn;

            var _atenciones_procesos_incidencias = from a in db.atenciones_procesos_incidencias
                                                   where a.ate_inc_idn == ate_inc_idn
                                                   orderby a.ate_pro_inc_fecha_ingreso descending
                                                   select a;


            return View(_atenciones_procesos_incidencias.ToList());
        }

        public ActionResult Index_procesos_incidencias(int pro_inc_idn, int ate_inc_idn)
        {

            int _max_pro_ges_inc_idn;

            var _procesos_incidencias = from a in db.procesos_gestiones_incidencias
                                        join b in db.atenciones_procesos_incidencias on a.pro_ges_inc_idn equals b.pro_ges_inc_idn
                                        join c in db.atenciones_incidencias on b.ate_inc_idn equals c.ate_inc_idn
                                        orderby b.ate_pro_inc_fecha_ingreso descending
                                        where b.ate_inc_idn == ate_inc_idn && a.pro_inc_idn == pro_inc_idn

                                        select b;

             _max_pro_ges_inc_idn =  (from a in db.procesos_gestiones_incidencias
                                      join b in db.atenciones_procesos_incidencias on a.pro_ges_inc_idn equals b.pro_ges_inc_idn
                                      join c in db.atenciones_incidencias on b.ate_inc_idn equals c.ate_inc_idn
                                      orderby b.ate_pro_inc_fecha_ingreso descending
                                      where b.ate_inc_idn == ate_inc_idn && a.pro_inc_idn == pro_inc_idn
                                      select b.pro_ges_inc_idn).Max();

            ViewBag.max_pro_ges_inc_idn = _max_pro_ges_inc_idn;
            ViewBag.ate_inc_idn = ate_inc_idn;





            return PartialView("_Index_procesos_incidencias", _procesos_incidencias.ToList());
        }

        public ActionResult acepta_procesos_incidencias(int acepta, int ate_inc_idn)
        {

            if (acepta == 1) {

                atenciones_procesos_incidencias _atenciones_procesos_incidencias = new atenciones_procesos_incidencias();

                _atenciones_procesos_incidencias.pro_ges_inc_idn = 39;
                _atenciones_procesos_incidencias.ate_pro_inc_fecha_ingreso = DateTime.Now;
                _atenciones_procesos_incidencias.ate_pro_inc_observacion = "Aceptada por Alumno";
                _atenciones_procesos_incidencias.ate_inc_idn = ate_inc_idn;
                _atenciones_procesos_incidencias.emp_usu_sed_idn = 1;
                db.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias);
                db.SaveChanges();

            } else if(acepta == 0)
            {

                atenciones_procesos_incidencias _atenciones_procesos_incidencias = new atenciones_procesos_incidencias();
                _atenciones_procesos_incidencias.pro_ges_inc_idn = 40;
                _atenciones_procesos_incidencias.ate_pro_inc_fecha_ingreso = DateTime.Now;
                _atenciones_procesos_incidencias.ate_pro_inc_observacion = "Rechazada por Alumno";
                _atenciones_procesos_incidencias.ate_inc_idn = ate_inc_idn;
                _atenciones_procesos_incidencias.emp_usu_sed_idn = 1;
                db.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias);
                db.SaveChanges();


            }



            return RedirectToAction("Index_Menu_Incidencias", "Home");
        }


        // GET: atenciones_procesos_incidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones_procesos_incidencias atenciones_procesos_incidencias = db.atenciones_procesos_incidencias.Find(id);
            if (atenciones_procesos_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(atenciones_procesos_incidencias);
        }

        // GET: atenciones_procesos_incidencias/Create
        public ActionResult Create()
        {
            ViewBag.ate_inc_idn = new SelectList(db.atenciones_incidencias, "ate_inc_idn", "ate_inc_observacion");
            ViewBag.emp_usu_sed_idn = new SelectList(db.empresas_usuarios_sedes, "emp_usu_sed_idn", "emp_usu_sed_idn");
            ViewBag.pro_ges_inc_idn = new SelectList(db.procesos_gestiones_incidencias, "pro_ges_inc_idn", "pro_ges_inc_idn");
            return View();
        }






        public ActionResult Create_funcionario(int ate_inc_idn)
        {

            ViewBag.ate_inc_idn = ate_inc_idn;


            int _cerrada = (from a in db.atenciones_procesos_incidencias
                            where a.ate_inc_idn == ate_inc_idn && a.pro_ges_inc_idn == 35
                            select a).Count();

            

            if (_cerrada != 0) {



                atenciones_incidencias atenciones_incidencias = db.atenciones_incidencias.Find(ate_inc_idn);

                atenciones_incidencias.ate_inc_resuelta = true;
                atenciones_incidencias.ate_inc_fecha_resuelta = DateTime.Now;

                db.SaveChanges();



                return RedirectToAction("Index_funcionario_cerrada", "atenciones_procesos_incidencias", new { ate_inc_idn = ate_inc_idn });

            }




            int emp_usu_sed_idn = Convert.ToInt16(Session["emp_usu_sed_idn"]);

            int _existe = (from a in db.atenciones_procesos_incidencias
                          where a.ate_inc_idn == ate_inc_idn && a.emp_usu_sed_idn == emp_usu_sed_idn
                           select a).Count();


            if (_existe == 0) {


                return RedirectToAction("Index_funcionario_nogestiona", "atenciones_procesos_incidencias", new { ate_inc_idn = ate_inc_idn });

            }


            
            atenciones_procesos_incidencias _atenciones_procesos_incidencias = new atenciones_procesos_incidencias();
             _atenciones_procesos_incidencias.ate_inc_idn = ate_inc_idn;




            var _max_gestion = (from a in db.atenciones_procesos_incidencias
                            join b in db.procesos_gestiones_incidencias on a.pro_ges_inc_idn equals b.pro_ges_inc_idn
                            orderby b.pro_ges_inc_idn descending
                            where a.ate_inc_idn == ate_inc_idn
                            select b).Take(1).FirstOrDefault();

           var _gestiones = from a in db.procesos_gestiones_incidencias
                            join b in db.gestiones_incindecias on a.ges_inc_idn equals b.ges_inc_idn
                            where a.pro_inc_idn == _max_gestion.pro_inc_idn


                            select new vm_combo_gestiones
                            {
                                pro_ges_inc_idn = a.pro_ges_inc_idn,
                                ges_inc_nombre = b.ges_inc_nombre
                                
                            };


            var _usuario = from a in db.empresas_usuarios_sedes
                             join b in db.usuarios on a.usu_idn equals b.usu_idn
                           


                             select new vm_combo_usuarios_empresa
                             {
                                 emp_usu_sed_idn = a.emp_usu_sed_idn,
                                 usu_nombres = b.usu_apellidos + " " + b.usu_nombres

                             };





            ViewBag.emp_usu_sed_idn = new SelectList(_usuario, "emp_usu_sed_idn", "usu_nombres");
            ViewBag.pro_ges_inc_idn = new SelectList(_gestiones, "pro_ges_inc_idn", "ges_inc_nombre");
            return View(_atenciones_procesos_incidencias);
        }

        // POST: atenciones_procesos_incidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_funcionario(atenciones_procesos_incidencias atenciones_procesos_incidencias)
        {


            atenciones_procesos_incidencias _atenciones_procesos_incidencias = new atenciones_procesos_incidencias();
             _atenciones_procesos_incidencias.emp_usu_sed_idn = atenciones_procesos_incidencias.emp_usu_sed_idn;
            _atenciones_procesos_incidencias.ate_pro_inc_observacion = atenciones_procesos_incidencias.ate_pro_inc_observacion;
            _atenciones_procesos_incidencias.ate_pro_inc_fecha_ingreso = DateTime.Now;
            _atenciones_procesos_incidencias.ate_pro_inc_fecha_inicio_atencion = DateTime.Now;
            _atenciones_procesos_incidencias.ate_pro_inc_fecha_termino_atencion = DateTime.Now;
            _atenciones_procesos_incidencias.pro_ges_inc_idn = atenciones_procesos_incidencias.pro_ges_inc_idn;
            _atenciones_procesos_incidencias.ate_inc_idn = atenciones_procesos_incidencias.ate_inc_idn;

            int conta_salto;


                conta_salto = (from a in db.procesos_gestiones_incidencias_saltos
                              where a.pro_ges_inc_idn == _atenciones_procesos_incidencias.pro_ges_inc_idn
                              select a.pro_ges_inc_sal).Count() ;


            if (conta_salto > 0) {


                int _proceso_id;

                _proceso_id = (from a in db.procesos_gestiones_incidencias_saltos
                               where a.pro_ges_inc_idn == _atenciones_procesos_incidencias.pro_ges_inc_idn
                               select a.pro_ges_inc_idn_salta).FirstOrDefault();

                atenciones_procesos_incidencias _atenciones_procesos_incidencias1 = new atenciones_procesos_incidencias();
                _atenciones_procesos_incidencias1.emp_usu_sed_idn = atenciones_procesos_incidencias.emp_usu_sed_idn;
                _atenciones_procesos_incidencias1.ate_pro_inc_observacion = atenciones_procesos_incidencias.ate_pro_inc_observacion;
                _atenciones_procesos_incidencias1.ate_pro_inc_fecha_ingreso = DateTime.Now;
                _atenciones_procesos_incidencias1.ate_pro_inc_fecha_inicio_atencion = DateTime.Now;
                _atenciones_procesos_incidencias1.ate_pro_inc_fecha_termino_atencion = DateTime.Now;
                _atenciones_procesos_incidencias1.pro_ges_inc_idn = _proceso_id;
                _atenciones_procesos_incidencias1.ate_inc_idn = atenciones_procesos_incidencias.ate_inc_idn;

                db.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias1);
            }


            db.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias);
            
            db.SaveChanges();
             return RedirectToAction("Create_funcionario", "atenciones_procesos_incidencias", new { ate_inc_idn = _atenciones_procesos_incidencias.ate_inc_idn });
           

           
           
        }

       
        
        public ActionResult insiste_gestion(int ate_inc_idn)
        {

            var _max_gestion = (from a in db.atenciones_procesos_incidencias
                                join b in db.procesos_gestiones_incidencias on a.pro_ges_inc_idn equals b.pro_ges_inc_idn
                                orderby a.ate_pro_inc_idn descending
                                where a.ate_inc_idn == ate_inc_idn
                                select b).Take(1).FirstOrDefault();


            var _cod_insistencia = (from a in db.procesos_gestiones_incidencias
                                    where a.pro_inc_idn == _max_gestion.pro_inc_idn && a.ges_inc_idn == 21
                                    select a).FirstOrDefault();


            atenciones_procesos_incidencias _atenciones_procesos_incidencias1 = new atenciones_procesos_incidencias();
            _atenciones_procesos_incidencias1.emp_usu_sed_idn = Convert.ToInt16(Session["emp_usu_sed_idn"]);
            _atenciones_procesos_incidencias1.ate_pro_inc_observacion = "";
            _atenciones_procesos_incidencias1.ate_pro_inc_fecha_ingreso = DateTime.Now;
            _atenciones_procesos_incidencias1.ate_pro_inc_fecha_inicio_atencion = DateTime.Now;
            _atenciones_procesos_incidencias1.ate_pro_inc_fecha_termino_atencion = DateTime.Now;
            _atenciones_procesos_incidencias1.pro_ges_inc_idn = _cod_insistencia.pro_ges_inc_idn;
            _atenciones_procesos_incidencias1.ate_inc_idn = ate_inc_idn;

            db.atenciones_procesos_incidencias.Add(_atenciones_procesos_incidencias1);

            db.SaveChanges();
            return RedirectToAction("Index_funcionario_nogestiona", "atenciones_procesos_incidencias", new { ate_inc_idn = ate_inc_idn });


            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ate_pro_inc_idn,ate_inc_idn,pro_ges_inc_idn,ate_pro_inc_observacion,ate_pro_inc_fecha_ingreso,emp_usu_sed_idn")] atenciones_procesos_incidencias atenciones_procesos_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.atenciones_procesos_incidencias.Add(atenciones_procesos_incidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ate_inc_idn = new SelectList(db.atenciones_incidencias, "ate_inc_idn", "ate_inc_observacion", atenciones_procesos_incidencias.ate_inc_idn);
            ViewBag.emp_usu_sed_idn = new SelectList(db.empresas_usuarios_sedes, "emp_usu_sed_idn", "emp_usu_sed_idn", atenciones_procesos_incidencias.emp_usu_sed_idn);
            ViewBag.pro_ges_inc_idn = new SelectList(db.procesos_gestiones_incidencias, "pro_ges_inc_idn", "pro_ges_inc_idn", atenciones_procesos_incidencias.pro_ges_inc_idn);
            return View(atenciones_procesos_incidencias);
        }

        // GET: atenciones_procesos_incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones_procesos_incidencias atenciones_procesos_incidencias = db.atenciones_procesos_incidencias.Find(id);
            if (atenciones_procesos_incidencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.ate_inc_idn = new SelectList(db.atenciones_incidencias, "ate_inc_idn", "ate_inc_observacion", atenciones_procesos_incidencias.ate_inc_idn);
            ViewBag.emp_usu_sed_idn = new SelectList(db.empresas_usuarios_sedes, "emp_usu_sed_idn", "emp_usu_sed_idn", atenciones_procesos_incidencias.emp_usu_sed_idn);
            ViewBag.pro_ges_inc_idn = new SelectList(db.procesos_gestiones_incidencias, "pro_ges_inc_idn", "pro_ges_inc_idn", atenciones_procesos_incidencias.pro_ges_inc_idn);
            return View(atenciones_procesos_incidencias);
        }

        // POST: atenciones_procesos_incidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ate_pro_inc_idn,ate_inc_idn,pro_ges_inc_idn,ate_pro_inc_observacion,ate_pro_inc_fecha_ingreso,emp_usu_sed_idn")] atenciones_procesos_incidencias atenciones_procesos_incidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atenciones_procesos_incidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ate_inc_idn = new SelectList(db.atenciones_incidencias, "ate_inc_idn", "ate_inc_observacion", atenciones_procesos_incidencias.ate_inc_idn);
            ViewBag.emp_usu_sed_idn = new SelectList(db.empresas_usuarios_sedes, "emp_usu_sed_idn", "emp_usu_sed_idn", atenciones_procesos_incidencias.emp_usu_sed_idn);
            ViewBag.pro_ges_inc_idn = new SelectList(db.procesos_gestiones_incidencias, "pro_ges_inc_idn", "pro_ges_inc_idn", atenciones_procesos_incidencias.pro_ges_inc_idn);
            return View(atenciones_procesos_incidencias);
        }

        // GET: atenciones_procesos_incidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            atenciones_procesos_incidencias atenciones_procesos_incidencias = db.atenciones_procesos_incidencias.Find(id);
            if (atenciones_procesos_incidencias == null)
            {
                return HttpNotFound();
            }
            return View(atenciones_procesos_incidencias);
        }

        // POST: atenciones_procesos_incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            atenciones_procesos_incidencias atenciones_procesos_incidencias = db.atenciones_procesos_incidencias.Find(id);
            db.atenciones_procesos_incidencias.Remove(atenciones_procesos_incidencias);
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
