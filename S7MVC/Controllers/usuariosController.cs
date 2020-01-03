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
    public class usuariosController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: usuarios
        public ActionResult Index()
        {
            return View(db.usuarios.ToList());
        }



        public ActionResult Index_usuarios_busca()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Index_usuarios_lista(string v_rut)
        {


            var _usuarios = from a in db.usuarios
                            where a.usu_id_nacional == v_rut.Trim()
                            select a;
                             
              


            return View(_usuarios);
        }

        // GET: usuarios/Details/5
        public ActionResult Details(string v_rut)
        {

            usuarios usuarios;

            var _usuarios = (from a in db.usuarios
                            where a.usu_id_nacional == v_rut.Trim()
                            select a).FirstOrDefault();


            if (_usuarios == null) {


                return RedirectToAction("Create", "usuarios");
            }

            else {

                ViewBag.existe = 1;

                ViewBag.usu_idn = _usuarios.usu_idn;
                usuarios = db.usuarios.Find(_usuarios.usu_idn);
                return View(usuarios);

            }


        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_idn,usu_nombres,usu_apellidos,usu_id_nacional,usu_email,usu_clave")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Details", "usuarios", new { v_rut = usuarios.usu_id_nacional });
            }

            return View(usuarios);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_idn,usu_nombres,usu_apellidos,usu_id_nacional,usu_email,usu_clave")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            db.usuarios.Remove(usuarios);
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
