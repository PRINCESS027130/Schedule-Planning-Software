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
    public class ADMIN_TBLController : Controller
    {
        private Model1 db = new Model1();

        // GET: ADMIN_TBL
        public ActionResult Index()
        {
            return View(db.ADMIN_TBL.ToList());
        }

        // GET: ADMIN_TBL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN_TBL aDMIN_TBL = db.ADMIN_TBL.Find(id);
            if (aDMIN_TBL == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN_TBL);
        }

        // GET: ADMIN_TBL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN_TBL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ADMIN_TBL aDMIN_TBL,HttpPostedFileBase pic)
        {
            if (ModelState.IsValid)
            {
                db.ADMIN_TBL.Add(aDMIN_TBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDMIN_TBL);
        }

        // GET: ADMIN_TBL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN_TBL aDMIN_TBL = db.ADMIN_TBL.Find(id);
            if (aDMIN_TBL == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN_TBL);
        }

        // POST: ADMIN_TBL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ADMIN_ID,ADMIN_NAME,ADMIN_EMAIL,ADMIN_PASSWORD,ADMIN_PHNO,ADMIN_ADDRESS,ADMIN_IMAGE")] ADMIN_TBL aDMIN_TBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMIN_TBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDMIN_TBL);
        }

        // GET: ADMIN_TBL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN_TBL aDMIN_TBL = db.ADMIN_TBL.Find(id);
            if (aDMIN_TBL == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN_TBL);
        }

        // POST: ADMIN_TBL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMIN_TBL aDMIN_TBL = db.ADMIN_TBL.Find(id);
            db.ADMIN_TBL.Remove(aDMIN_TBL);
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
