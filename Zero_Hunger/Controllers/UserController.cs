using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Zero_Hunger.Models;
using Zero_Hunger.Repo;

namespace Zero_Hunger.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var neededUser = UserRepo.Get(user.Email, user.Password, user.Type);

                if (neededUser != null)
                {
                    string json = new JavaScriptSerializer().Serialize(neededUser);
                    
                    if (user.Type == 1)
                    {
                        Session["employee"] = json;
                        return RedirectToAction("Index", "Employee");

                    }
                    else if (user.Type == 2)
                    {
                        Session["restaurant"] = json;
                        return RedirectToAction("Index", "Restaurant");

                    }
                    return View();
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            var areas = AreaRepo.Get();
            ViewBag.areas = areas;
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RestaurantReg data)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel();
                user.Email = data.Email;
                user.Password = data.Password;
                user.Type = 2;

                var newUser = UserRepo.Create(user);

                var restaurent = new RestaurantModel();
                restaurent.Name = data.Name;
                restaurent.Address = data.Address;
                restaurent.AreaId = data.AreaId;
                restaurent.UserId = newUser.Id;

                RestaurantRepo.Create(restaurent);
                return RedirectToAction("Login");
            }

            var areas = AreaRepo.Get();
            ViewBag.areas = areas;
            return View();
        }
    }
}