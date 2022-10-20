using StudenReg.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace StudenReg.Controllers
{
    public class PreRegistrationController : Controller
    {
        // GET: PreRegistration
        [HttpGet]
        public ActionResult Index()
        {
            var db = new UniMSEntities1();
            var course = (from c in db.Courses
                          where (c.PreReq != null &&
                          c.PreReq == (from cs in db.CourseStudents
                                       where cs.CourseId == c.PreReq && cs.StudentId == 6 && cs.Grade != "W" && (cs.Status == "Complete" || cs.Status == "Enrolled") && (cs.Grade == "A+" || cs.Grade == "D" || cs.Grade == "")
                                       select cs.CourseId).FirstOrDefault()) ||
                           (c.PreReq == null && c.Id != (from cs in db.CourseStudents
                                                         where cs.StudentId == 1 && cs.CourseId == c.Id
                                                         select cs.CourseId).FirstOrDefault()) ||
                           (c.Id == (from cs in db.CourseStudents
                                     where cs.Status == "complete" && cs.StudentId == 1 && cs.CourseId == c.Id && (cs.Grade == "W" || cs.Marks < 60)
                                     select cs.CourseId).FirstOrDefault())
                          select c).ToList();


            return View(course);
        }
        [HttpPost]
        public ActionResult Index(int[] Courses)
        {
            var db = new UniMSEntities1();
            foreach (var Course in Courses)
            {
                db.CourseStudents.Add(new CourseStudent()
                {
                    CourseId = Course,
                    StudentId = 6,
                    Status = "Enrolled",
                    Grade = "",
                    Marks = 0
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}