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
    public class usuarios_productosController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: usuarios_productos
        public ActionResult Index(int usu_idn)
        {


            var _usuarios_productos = from a in db.usuarios_productos
                                      where a.usu_idn == usu_idn
                                      select a;

            return PartialView("_Index", _usuarios_productos.ToList());
        }

        // GET: usuarios_productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios_productos usuarios_productos = db.usuarios_productos.Find(id);
            if (usuarios_productos == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_productos);
        }

        // GET: usuarios_productos/Create
        public ActionResult Create(int usu_idn)
        {

            ViewBag.usu_idn = usu_idn;


            usuarios_productos _usuarios_productos = new usuarios_productos();

            _usuarios_productos.usu_idn = usu_idn;

            ViewBag.ano_idn = new SelectList(db.anos, "ano_idn", "ano_nombre");
            ViewBag.per_idn = new SelectList(db.periodos, "per_idn", "per_nombre");
            ViewBag.pro_idn = new SelectList(db.productos, "pro_idn", "pro_codigo_umas");
           
            return View(_usuarios_productos);
        }

        // POST: usuarios_productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usu_pro_idn,usu_idn,pro_idn,ano_idn,per_idn,usu_pro_activo")] usuarios_productos usuarios_productos)
        {
            if (ModelState.IsValid)
            {
                db.usuarios_productos.Add(usuarios_productos);
                db.SaveChanges();


                var _usuarios = (from a in db.usuarios
                                 where a.usu_idn == usuarios_productos.usu_idn
                                 select a).FirstOrDefault();

                return RedirectToAction("Details", "usuarios", new { v_rut = _usuarios.usu_id_nacional });
            }

            ViewBag.ano_idn = new SelectList(db.anos, "ano_idn", "ano_nombre", usuarios_productos.ano_idn);
            ViewBag.per_idn = new SelectList(db.periodos, "per_idn", "per_nombre", usuarios_productos.per_idn);
            ViewBag.pro_idn = new SelectList(db.productos, "pro_idn", "pro_codigo_umas", usuarios_productos.pro_idn);
            ViewBag.usu_idn = new SelectList(db.usuarios, "usu_idn", "usu_nombres", usuarios_productos.usu_idn);
            return View(usuarios_productos);
        }

        // GET: usuarios_productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios_productos usuarios_productos = db.usuarios_productos.Find(id);
            if (usuarios_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ano_idn = new SelectList(db.anos, "ano_idn", "ano_nombre", usuarios_productos.ano_idn);
            ViewBag.per_idn = new SelectList(db.periodos, "per_idn", "per_nombre", usuarios_productos.per_idn);
            ViewBag.pro_idn = new SelectList(db.productos, "pro_idn", "pro_codigo_umas", usuarios_productos.pro_idn);
            ViewBag.usu_idn = new SelectList(db.usuarios, "usu_idn", "usu_nombres", usuarios_productos.usu_idn);
            return View(usuarios_productos);
        }

        // POST: usuarios_productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usu_pro_idn,usu_idn,pro_idn,ano_idn,per_idn,usu_pro_activo")] usuarios_productos usuarios_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ano_idn = new SelectList(db.anos, "ano_idn", "ano_nombre", usuarios_productos.ano_idn);
            ViewBag.per_idn = new SelectList(db.periodos, "per_idn", "per_nombre", usuarios_productos.per_idn);
            ViewBag.pro_idn = new SelectList(db.productos, "pro_idn", "pro_codigo_umas", usuarios_productos.pro_idn);
            ViewBag.usu_idn = new SelectList(db.usuarios, "usu_idn", "usu_nombres", usuarios_productos.usu_idn);
            return View(usuarios_productos);
        }

        // GET: usuarios_productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios_productos usuarios_productos = db.usuarios_productos.Find(id);
            if (usuarios_productos == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_productos);
        }

        // POST: usuarios_productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarios_productos usuarios_productos = db.usuarios_productos.Find(id);
            db.usuarios_productos.Remove(usuarios_productos);
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
