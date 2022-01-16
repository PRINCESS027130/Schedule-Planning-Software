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
    public class TEACHER_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: TEACHER_TBL
        public ActionResult Index()
        {
            var tEACHER_TBL = db.TEACHER_TBL.Include(t => t.DEPARTMENT_TBL);
            return View(tEACHER_TBL.ToList());
        }

        // GET: TEACHER_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEACHER_TBL tEACHER_TBL = db.TEACHER_TBL.Find(id);
            if (tEACHER_TBL == null)
            {
                return HttpNotFound();
            }
            return View(tEACHER_TBL);
        }

        // GET: TEACHER_TBL/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            return View();
        }

        // POST: TEACHER_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEACHER_ID,TEACHER_NAME,TEACHER_EMAIL,TEACHER_PASSWORD,TEACHER_PHNO,TEACHER_ADDRESS,DEPARTMENT_FID")] TEACHER_TBL tEACHER_TBL)
        {
            if (ModelState.IsValid)
            {
                db.TEACHER_TBL.Add(tEACHER_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", tEACHER_TBL.DEPARTMENT_FID);
            return View(tEACHER_TBL);
        }

        // GET: TEACHER_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEACHER_TBL tEACHER_TBL = db.TEACHER_TBL.Find(id);
            if (tEACHER_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", tEACHER_TBL.DEPARTMENT_FID);
            return View(tEACHER_TBL);
        }

        // POST: TEACHER_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEACHER_ID,TEACHER_NAME,TEACHER_EMAIL,TEACHER_PASSWORD,TEACHER_PHNO,TEACHER_ADDRESS,DEPARTMENT_FID")] TEACHER_TBL tEACHER_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEACHER_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_TBL, "DEPARTMENT_ID", "DEPARTMENT_NAME", tEACHER_TBL.DEPARTMENT_FID);
            return View(tEACHER_TBL);
        }

        // GET: TEACHER_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEACHER_TBL tEACHER_TBL = db.TEACHER_TBL.Find(id);
            if (tEACHER_TBL == null)
            {
                return HttpNotFound();
            }
            return View(tEACHER_TBL);
        }

        // POST: TEACHER_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEACHER_TBL tEACHER_TBL = db.TEACHER_TBL.Find(id);
            db.TEACHER_TBL.Remove(tEACHER_TBL);
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
