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
    public class STUDENT_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: STUDENT_TBL
        public ActionResult Index()
        {
            var sTUDENT_TBL = db.STUDENT_TBL.Include(s => s.CLASS_TBL);
            return View(sTUDENT_TBL.ToList());
        }

        // GET: STUDENT_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_TBL sTUDENT_TBL = db.STUDENT_TBL.Find(id);
            if (sTUDENT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_TBL);
        }

        // GET: STUDENT_TBL/Create
        public ActionResult Create()
        {
            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION");
            return View();
        }

        // POST: STUDENT_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STUDENT_ID,STUDENT_NAME,STUDENT_EMAIL,STUDENT_PASSWORD,CLASS_FID")] STUDENT_TBL sTUDENT_TBL)
        {
            if (ModelState.IsValid)
            {
                db.STUDENT_TBL.Add(sTUDENT_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION", sTUDENT_TBL.CLASS_FID);
            return View(sTUDENT_TBL);
        }

        // GET: STUDENT_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_TBL sTUDENT_TBL = db.STUDENT_TBL.Find(id);
            if (sTUDENT_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION", sTUDENT_TBL.CLASS_FID);
            return View(sTUDENT_TBL);
        }

        // POST: STUDENT_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STUDENT_ID,STUDENT_NAME,STUDENT_EMAIL,STUDENT_PASSWORD,CLASS_FID")] STUDENT_TBL sTUDENT_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLASS_FID = new SelectList(db.CLASS_TBL, "CLASS_ID", "SESSION", sTUDENT_TBL.CLASS_FID);
            return View(sTUDENT_TBL);
        }

        // GET: STUDENT_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_TBL sTUDENT_TBL = db.STUDENT_TBL.Find(id);
            if (sTUDENT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_TBL);
        }

        // POST: STUDENT_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT_TBL sTUDENT_TBL = db.STUDENT_TBL.Find(id);
            db.STUDENT_TBL.Remove(sTUDENT_TBL);
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
