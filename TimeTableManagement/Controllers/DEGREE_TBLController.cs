using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeTableManagement.Models;

namespace TimeTableManagement.Controllers
{
    public class DEGREE_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: DEGREE_TBL
        public ActionResult Index()
        {
            var dEGREE_TBL = db.DEGREE_TBL.Include(d => d.DEPARTMENT_TBL);
            return View(dEGREE_TBL.ToList());
        }

        // GET: DEGREE_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEGREE_TBL dEGREE_TBL = db.DEGREE_TBL.Find(id);
            if (dEGREE_TBL == null)
            {
                return HttpNotFound();
            }
            return View(dEGREE_TBL);
        }

        // GET: DEGREE_TBL/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            return View();
        }

        // POST: DEGREE_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEGREE_ID,DEGREE_NAME,DEPARTMENT_FID")] DEGREE_TBL dEGREE_TBL)
        {
            if (ModelState.IsValid)
            {
                db.DEGREE_TBL.Add(dEGREE_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", dEGREE_TBL.DEPARTMENT_FID);
            return View(dEGREE_TBL);
        }

        // GET: DEGREE_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEGREE_TBL dEGREE_TBL = db.DEGREE_TBL.Find(id);
            if (dEGREE_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", dEGREE_TBL.DEPARTMENT_FID);
            return View(dEGREE_TBL);
        }

        // POST: DEGREE_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEGREE_ID,DEGREE_NAME,DEPARTMENT_FID")] DEGREE_TBL dEGREE_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEGREE_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", dEGREE_TBL.DEPARTMENT_FID);
            return View(dEGREE_TBL);
        }

        // GET: DEGREE_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEGREE_TBL dEGREE_TBL = db.DEGREE_TBL.Find(id);
            if (dEGREE_TBL == null)
            {
                return HttpNotFound();
            }
            return View(dEGREE_TBL);
        }

        // POST: DEGREE_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEGREE_TBL dEGREE_TBL = db.DEGREE_TBL.Find(id);
            db.DEGREE_TBL.Remove(dEGREE_TBL);
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
