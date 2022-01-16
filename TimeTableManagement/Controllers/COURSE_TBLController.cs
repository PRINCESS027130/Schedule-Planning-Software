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
    public class COURSE_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: COURSE_TBL
        public ActionResult Index()
        {
            var cOURSE_TBL = db.COURSE_TBL.Include(c => c.DEGREE_TBL);
            return View(cOURSE_TBL.ToList());
        }

        // GET: COURSE_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE_TBL cOURSE_TBL = db.COURSE_TBL.Find(id);
            if (cOURSE_TBL == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE_TBL);
        }

        // GET: COURSE_TBL/Create
        public ActionResult Create()
        {
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME");
            return View();
        }

        // POST: COURSE_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COURSE_ID,COURSE_NAME,CREDIT_HOURS,DEGREE_FID")] COURSE_TBL cOURSE_TBL)
        {
            if (ModelState.IsValid)
            {
                db.COURSE_TBL.Add(cOURSE_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cOURSE_TBL.DEGREE_FID);
            return View(cOURSE_TBL);
        }

        // GET: COURSE_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE_TBL cOURSE_TBL = db.COURSE_TBL.Find(id);
            if (cOURSE_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cOURSE_TBL.DEGREE_FID);
            return View(cOURSE_TBL);
        }

        // POST: COURSE_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COURSE_ID,COURSE_NAME,CREDIT_HOURS,DEGREE_FID")] COURSE_TBL cOURSE_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOURSE_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cOURSE_TBL.DEGREE_FID);
            return View(cOURSE_TBL);
        }

        // GET: COURSE_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE_TBL cOURSE_TBL = db.COURSE_TBL.Find(id);
            if (cOURSE_TBL == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE_TBL);
        }

        // POST: COURSE_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURSE_TBL cOURSE_TBL = db.COURSE_TBL.Find(id);
            db.COURSE_TBL.Remove(cOURSE_TBL);
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
