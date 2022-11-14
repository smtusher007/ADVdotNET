using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Zero_Hunger.DB;
using Zero_Hunger.Models;
using Zero_Hunger.Repo;

namespace Zero_Hunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            string json = (string)Session["employee"];
            //var user = new JavaScriptSerializer().Deserialize<User>(json);
            var employee = EmployeeRepo.Get(1);
            ViewBag.Employee = employee;
            var requests = DisReqRepo.EmpGet(employee.Id);
            var foods = new List<List<ReqDetails>>();

            foreach (var item in requests)
            {
                foods.Add(ReqDetailsRepo.Get(item.Id));
            }

            ViewBag.Foods = foods;
            ViewBag.Restaurants = RestaurantRepo.Get();
            return View(requests);
           
        }
        [HttpPost]
        public ActionResult Index(DisReqModel data)
        {
            string json = (string)Session["employee"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var employee = EmployeeRepo.Get(user.Id);
            if (data.Id != 0)
            {
                data.EmpId = employee.Id;
                DisReqRepo.UpdateStatus(data);
            }

            return RedirectToAction("Index");
        }

    }
}