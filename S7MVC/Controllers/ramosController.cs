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
    public class ramosController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: ramos
        public ActionResult Index()
        {
            return View(db.ramos.ToList());
        }

        // GET: ramos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ramos ramos = db.ramos.Find(id);
            if (ramos == null)
            {
                return HttpNotFound();
            }
            return View(ramos);
        }

        // GET: ramos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ramos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ram_idn,ram_codigo_umas,ram_nombre")] ramos ramos)
        {
            if (ModelState.IsValid)
            {
                db.ramos.Add(ramos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ramos);
        }

        // GET: ramos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ramos ramos = db.ramos.Find(id);
            if (ramos == null)
            {
                return HttpNotFound();
            }
            return View(ramos);
        }

        // POST: ramos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ram_idn,ram_codigo_umas,ram_nombre")] ramos ramos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ramos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ramos);
        }

        // GET: ramos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ramos ramos = db.ramos.Find(id);
            if (ramos == null)
            {
                return HttpNotFound();
            }
            return View(ramos);
        }

        // POST: ramos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ramos ramos = db.ramos.Find(id);
            db.ramos.Remove(ramos);
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
