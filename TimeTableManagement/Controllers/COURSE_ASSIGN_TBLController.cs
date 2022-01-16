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
    public class COURSE_ASSIGN_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: COURSE_ASSIGN_TBL
        public ActionResult Index()
        {
            var cOURSE_ASSIGN_TBL = db.COURSE_ASSIGN_TBL.Include(c => c.COURSE_TBL).Include(c => c.DEGREE_TBL);
            return View(cOURSE_ASSIGN_TBL.ToList());
        }

        // GET: COURSE_ASSIGN_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE_ASSIGN_TBL cOURSE_ASSIGN_TBL = db.COURSE_ASSIGN_TBL.Find(id);
            if (cOURSE_ASSIGN_TBL == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE_ASSIGN_TBL);
        }

        // GET: COURSE_ASSIGN_TBL/Create
        public ActionResult Create()
        {
            ViewBag.COURSE_FID = new SelectList(db.COURSE_TBL, "COURSE_ID", "COURSE_NAME");
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME");
            return View();
        }

        // POST: COURSE_ASSIGN_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COURSE_ASSIGN_ID,COURSE_FID,DEGREE_FID")] COURSE_ASSIGN_TBL cOURSE_ASSIGN_TBL)
        {
            if (ModelState.IsValid)
            {
                db.COURSE_ASSIGN_TBL.Add(cOURSE_ASSIGN_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COURSE_FID = new SelectList(db.COURSE_TBL, "COURSE_ID", "COURSE_NAME", cOURSE_ASSIGN_TBL.COURSE_FID);
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cOURSE_ASSIGN_TBL.DEGREE_FID);
            return View(cOURSE_ASSIGN_TBL);
        }

        // GET: COURSE_ASSIGN_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE_ASSIGN_TBL cOURSE_ASSIGN_TBL = db.COURSE_ASSIGN_TBL.Find(id);
            if (cOURSE_ASSIGN_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.COURSE_FID = new SelectList(db.COURSE_TBL, "COURSE_ID", "COURSE_NAME", cOURSE_ASSIGN_TBL.COURSE_FID);
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cOURSE_ASSIGN_TBL.DEGREE_FID);
            return View(cOURSE_ASSIGN_TBL);
        }

        // POST: COURSE_ASSIGN_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COURSE_ASSIGN_ID,COURSE_FID,DEGREE_FID")] COURSE_ASSIGN_TBL cOURSE_ASSIGN_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOURSE_ASSIGN_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COURSE_FID = new SelectList(db.COURSE_TBL, "COURSE_ID", "COURSE_NAME", cOURSE_ASSIGN_TBL.COURSE_FID);
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cOURSE_ASSIGN_TBL.DEGREE_FID);
            return View(cOURSE_ASSIGN_TBL);
        }

        // GET: COURSE_ASSIGN_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE_ASSIGN_TBL cOURSE_ASSIGN_TBL = db.COURSE_ASSIGN_TBL.Find(id);
            if (cOURSE_ASSIGN_TBL == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE_ASSIGN_TBL);
        }

        // POST: COURSE_ASSIGN_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURSE_ASSIGN_TBL cOURSE_ASSIGN_TBL = db.COURSE_ASSIGN_TBL.Find(id);
            db.COURSE_ASSIGN_TBL.Remove(cOURSE_ASSIGN_TBL);
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
