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
    public class SLOT_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: SLOT_TBL
        public ActionResult Index()
        {
            return View(db.SLOT_TBL.ToList());
        }

        // GET: SLOT_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLOT_TBL sLOT_TBL = db.SLOT_TBL.Find(id);
            if (sLOT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(sLOT_TBL);
        }

        // GET: SLOT_TBL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SLOT_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SLOT_ID,SLOT_START_TIME,SLOT_END_TIME")] SLOT_TBL sLOT_TBL)
        {
            if (ModelState.IsValid)
            {
                db.SLOT_TBL.Add(sLOT_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sLOT_TBL);
        }

        // GET: SLOT_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLOT_TBL sLOT_TBL = db.SLOT_TBL.Find(id);
            if (sLOT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(sLOT_TBL);
        }

        // POST: SLOT_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SLOT_ID,SLOT_START_TIME,SLOT_END_TIME")] SLOT_TBL sLOT_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sLOT_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sLOT_TBL);
        }

        // GET: SLOT_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLOT_TBL sLOT_TBL = db.SLOT_TBL.Find(id);
            if (sLOT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(sLOT_TBL);
        }

        // POST: SLOT_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLOT_TBL sLOT_TBL = db.SLOT_TBL.Find(id);
            db.SLOT_TBL.Remove(sLOT_TBL);
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
