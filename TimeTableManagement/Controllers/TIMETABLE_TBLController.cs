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
    public class TIMETABLE_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: TIMETABLE_TBL
        public ActionResult Index()
        {
            var tIMETABLE_TBL = db.TIMETABLE_TBL.Include(t => t.CLASS_TBL).Include(t => t.COURSE_ASSIGN_TBL).Include(t => t.ROOM_TBL).Include(t => t.SLOT_TBL).Include(t => t.TEACHER_TBL);
            return View(tIMETABLE_TBL.ToList());
        }

        // GET: TIMETABLE_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMETABLE_TBL tIMETABLE_TBL = db.TIMETABLE_TBL.Find(id);
            if (tIMETABLE_TBL == null)
            {
                return HttpNotFound();
            }
            return View(tIMETABLE_TBL);
        }

        // GET: TIMETABLE_TBL/Create
        public ActionResult Create()
        {
            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION");
            ViewBag.COURSE_ASSIGN_FID = new SelectList(db.COURSE_ASSIGN_TBL, "COURSE_ASSIGN_ID", "COURSE_ASSIGN_ID");
            ViewBag.ROOM_FID = new SelectList(db.ROOM_TBL, "ROOM_ID", "ROOM_NO");
            ViewBag.SLOT_FID = new SelectList(db.SLOT_TBL, "SLOT_ID", "SLOT_ID");
            ViewBag.TEACHER_FID = new SelectList(db.TEACHER_TBL, "TEACHER_ID", "TEACHER_NAME");
            return View();
        }

        // POST: TIMETABLE_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TIMETABLE_ID,TEACHER_FID,CLASS_FID,SLOT_FID,ROOM_FID,COURSE_ASSIGN_FID")] TIMETABLE_TBL tIMETABLE_TBL)
        {
            if (ModelState.IsValid)
            {
                db.TIMETABLE_TBL.Add(tIMETABLE_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION", tIMETABLE_TBL.CLASS_FID);
            ViewBag.COURSE_ASSIGN_FID = new SelectList(db.COURSE_ASSIGN_TBL, "COURSE_ASSIGN_ID", "COURSE_ASSIGN_ID", tIMETABLE_TBL.COURSE_ASSIGN_FID);
            ViewBag.ROOM_FID = new SelectList(db.ROOM_TBL, "ROOM_ID", "ROOM_NO", tIMETABLE_TBL.ROOM_FID);
            ViewBag.SLOT_FID = new SelectList(db.SLOT_TBL, "SLOT_ID", "SLOT_ID", tIMETABLE_TBL.SLOT_FID);
            ViewBag.TEACHER_FID = new SelectList(db.TEACHER_TBL, "TEACHER_ID", "TEACHER_NAME", tIMETABLE_TBL.TEACHER_FID);
            return View(tIMETABLE_TBL);
        }

        // GET: TIMETABLE_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMETABLE_TBL tIMETABLE_TBL = db.TIMETABLE_TBL.Find(id);
            if (tIMETABLE_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION", tIMETABLE_TBL.CLASS_FID);
            ViewBag.COURSE_ASSIGN_FID = new SelectList(db.COURSE_ASSIGN_TBL, "COURSE_ASSIGN_ID", "COURSE_ASSIGN_ID", tIMETABLE_TBL.COURSE_ASSIGN_FID);
            ViewBag.ROOM_FID = new SelectList(db.ROOM_TBL, "ROOM_ID", "ROOM_NO", tIMETABLE_TBL.ROOM_FID);
            ViewBag.SLOT_FID = new SelectList(db.SLOT_TBL, "SLOT_ID", "SLOT_ID", tIMETABLE_TBL.SLOT_FID);
            ViewBag.TEACHER_FID = new SelectList(db.TEACHER_TBL, "TEACHER_ID", "TEACHER_NAME", tIMETABLE_TBL.TEACHER_FID);
            return View(tIMETABLE_TBL);
        }

        // POST: TIMETABLE_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TIMETABLE_ID,TEACHER_FID,CLASS_FID,SLOT_FID,ROOM_FID,COURSE_ASSIGN_FID")] TIMETABLE_TBL tIMETABLE_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIMETABLE_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION", tIMETABLE_TBL.CLASS_FID);
            ViewBag.COURSE_ASSIGN_FID = new SelectList(db.COURSE_ASSIGN_TBL, "COURSE_ASSIGN_ID", "COURSE_ASSIGN_ID", tIMETABLE_TBL.COURSE_ASSIGN_FID);
            ViewBag.ROOM_FID = new SelectList(db.ROOM_TBL, "ROOM_ID", "ROOM_NO", tIMETABLE_TBL.ROOM_FID);
            ViewBag.SLOT_FID = new SelectList(db.SLOT_TBL, "SLOT_ID", "SLOT_ID", tIMETABLE_TBL.SLOT_FID);
            ViewBag.TEACHER_FID = new SelectList(db.TEACHER_TBL, "TEACHER_ID", "TEACHER_NAME", tIMETABLE_TBL.TEACHER_FID);
            return View(tIMETABLE_TBL);
        }

        // GET: TIMETABLE_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMETABLE_TBL tIMETABLE_TBL = db.TIMETABLE_TBL.Find(id);
            if (tIMETABLE_TBL == null)
            {
                return HttpNotFound();
            }
            return View(tIMETABLE_TBL);
        }

        // POST: TIMETABLE_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIMETABLE_TBL tIMETABLE_TBL = db.TIMETABLE_TBL.Find(id);
            db.TIMETABLE_TBL.Remove(tIMETABLE_TBL);
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
