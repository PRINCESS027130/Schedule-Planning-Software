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
    public class CLASS_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: CLASS_TBL
        public ActionResult Index()
        {
            var cLASS_TBL = db.CLASS_TBL.Include(c => c.DEGREE_TBL);
            return View(cLASS_TBL.ToList());
        }

        // GET: CLASS_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_TBL cLASS_TBL = db.CLASS_TBL.Find(id);
            if (cLASS_TBL == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_TBL);
        }

        // GET: CLASS_TBL/Create
        public ActionResult Create()
        {
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME");
            return View();
        }

        // POST: CLASS_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLASS_ID,SESSION,SECTION,SHIFT,DEGREE_FID")] CLASS_TBL cLASS_TBL)
        {
            if (ModelState.IsValid)
            {
                db.CLASS_TBL.Add(cLASS_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cLASS_TBL.DEGREE_FID);
            return View(cLASS_TBL);
        }

        // GET: CLASS_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_TBL cLASS_TBL = db.CLASS_TBL.Find(id);
            if (cLASS_TBL == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cLASS_TBL.DEGREE_FID);
            return View(cLASS_TBL);
        }

        // POST: CLASS_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLASS_ID,SESSION,SECTION,SHIFT,DEGREE_FID")] CLASS_TBL cLASS_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASS_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEGREE_FID = new SelectList(db.DEGREE_TBL, "DEGREE_ID", "DEGREE_NAME", cLASS_TBL.DEGREE_FID);
            return View(cLASS_TBL);
        }

        // GET: CLASS_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_TBL cLASS_TBL = db.CLASS_TBL.Find(id);
            if (cLASS_TBL == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_TBL);
        }

        // POST: CLASS_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASS_TBL cLASS_TBL = db.CLASS_TBL.Find(id);
            db.CLASS_TBL.Remove(cLASS_TBL);
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
