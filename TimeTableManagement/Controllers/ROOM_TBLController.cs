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
    public class ROOM_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: ROOM_TBL
        public ActionResult Index()
        {
            var rOOM_TBL = db.ROOM_TBL.Include(r => r.DEPARTMENT_TBL);
            return View(rOOM_TBL.ToList());
        }

        // GET: ROOM_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_TBL rOOM_TBL = db.ROOM_TBL.Find(id);
            if (rOOM_TBL == null)
            {
                return HttpNotFound();
            }
            return View(rOOM_TBL);
        }

        // GET: ROOM_TBL/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            return View();
        }

        // POST: ROOM_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROOM_ID,ROOM_NO,DEPARTMENT_FID")] ROOM_TBL rOOM_TBL)
        {
            if (ModelState.IsValid)
            {
                db.ROOM_TBL.Add(rOOM_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", rOOM_TBL.DEPARTMENT_FID);
            return View(rOOM_TBL);
        }

        // GET: ROOM_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_TBL rOOM_TBL = db.ROOM_TBL.Find(id);
            if (rOOM_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", rOOM_TBL.DEPARTMENT_FID);
            return View(rOOM_TBL);
        }

        // POST: ROOM_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROOM_ID,ROOM_NO,DEPARTMENT_FID")] ROOM_TBL rOOM_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOOM_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", rOOM_TBL.DEPARTMENT_FID);
            return View(rOOM_TBL);
        }

        // GET: ROOM_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM_TBL rOOM_TBL = db.ROOM_TBL.Find(id);
            if (rOOM_TBL == null)
            {
                return HttpNotFound();
            }
            return View(rOOM_TBL);
        }

        // POST: ROOM_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROOM_TBL rOOM_TBL = db.ROOM_TBL.Find(id);
            db.ROOM_TBL.Remove(rOOM_TBL);
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
