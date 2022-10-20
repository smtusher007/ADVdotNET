using StudenReg.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudenReg.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new UniMSEntities1();
            return View(db.Students.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            var db = new UniMSEntities1();
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new UniMSEntities1();
            return View(db.Students.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var db = new UniMSEntities1();
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var db = new UniMSEntities1();
            return View(db.Students.Find(Id));
        }
        public ActionResult Delete(int Id)
        {
            var db = new UniMSEntities1();
            var student = db.Students.Find(Id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}