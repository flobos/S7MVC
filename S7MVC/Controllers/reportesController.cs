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
    public class reportesController : Controller
    {
        private sieteEntidades db = new sieteEntidades();

        // GET: reportes
        public ActionResult Index()
        {
            return View(db.reportes.ToList());
        }

        // GET: reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // GET: reportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rep_idn,rep_nombre,rep_url")] reportes reportes)
        {
            if (ModelState.IsValid)
            {
                db.reportes.Add(reportes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportes);
        }

        // GET: reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: reportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rep_idn,rep_nombre,rep_url")] reportes reportes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportes);
        }

        // GET: reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportes reportes = db.reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reportes reportes = db.reportes.Find(id);
            db.reportes.Remove(reportes);
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
