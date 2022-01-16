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
    public class DEPARTMENT_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: DEPARTMENT_TBL
        public ActionResult Index()
        {
            return View(db.DEPARTMENT_TBL.ToList());
        }

        // GET: DEPARTMENT_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT_TBL dEPARTMENT_TBL = db.DEPARTMENT_TBL.Find(id);
            if (dEPARTMENT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT_TBL);
        }

        // GET: DEPARTMENT_TBL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPARTMENT_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME")] DEPARTMENT_TBL dEPARTMENT_TBL)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENT_TBL.Add(dEPARTMENT_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEPARTMENT_TBL);
        }

        // GET: DEPARTMENT_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT_TBL dEPARTMENT_TBL = db.DEPARTMENT_TBL.Find(id);
            if (dEPARTMENT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT_TBL);
        }

        // POST: DEPARTMENT_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME")] DEPARTMENT_TBL dEPARTMENT_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTMENT_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEPARTMENT_TBL);
        }

        // GET: DEPARTMENT_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT_TBL dEPARTMENT_TBL = db.DEPARTMENT_TBL.Find(id);
            if (dEPARTMENT_TBL == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT_TBL);
        }

        // POST: DEPARTMENT_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPARTMENT_TBL dEPARTMENT_TBL = db.DEPARTMENT_TBL.Find(id);
            db.DEPARTMENT_TBL.Remove(dEPARTMENT_TBL);
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
