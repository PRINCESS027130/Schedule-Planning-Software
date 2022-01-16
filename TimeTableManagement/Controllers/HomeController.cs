using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTableManagement.Models;

namespace TimeTableManagement.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult login(string Email,string Password)
        {
            int v = db.ADMIN_TBL.Where(x => x.ADMIN_EMAIL == Email && x.ADMIN_PASSWORD == Password).Count();
            if (v>0)
            {
                return RedirectToAction("Index"); 
            }
                else
            {
                ViewBag.loginerror = "Not Found Email and Password";
                return View();
            }
            return View();
        }
        public ActionResult gallery()
        {
            return View();
        }
        public ActionResult basic_table()
        {
            return View();
        }
    }
}