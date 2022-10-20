using StudenReg.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace StudenReg.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var db = new UniMSEntities1();
            return View(db.Courses.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cours cours)
        {
            var db = new UniMSEntities1();
            db.Courses.Add(cours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new UniMSEntities1();
            return View(db.Courses.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(Cours cours)
        {
            var db = new UniMSEntities1();
            db.Courses.AddOrUpdate(cours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var db = new UniMSEntities1();
            return View(db.Courses.Find(Id));
        }
        public ActionResult Delete(int Id)
        {
            var db = new UniMSEntities1();
            var course = db.Courses.Find(Id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}