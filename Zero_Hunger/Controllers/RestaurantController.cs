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
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);
            ViewBag.Restaurant = restaurant;

            var requests = DisReqRepo.Get(restaurant.Id);
            var foods = new List<List<ReqDetails>>();

            foreach (var item in requests)
            {
                foods.Add(ReqDetailsRepo.Get(item.Id));
            }
            ViewBag.Foods = foods;
            return View(requests);
        }
        [HttpGet]
        public ActionResult DistributeRequests()
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);
            ViewBag.Restaurant = restaurant;
            if (Session["FoodDetail"] != null)
            {
                json = (string)Session["FoodDetail"];
                var foods = new JavaScriptSerializer().Deserialize<List<ReqDetailsForCart>>(json);
                ViewBag.FoodDetails = foods;
            }
            var model = new DisReqModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult DistributeRequests(DisReqModel request)
        {
            string json = (string)Session["restaurant"];
            var user = new JavaScriptSerializer().Deserialize<User>(json);
            var restaurant = RestaurantRepo.Get(user.Id);
            ViewBag.Restaurant = restaurant;

            json = (string)Session["FoodDetail"];
            var foods = new JavaScriptSerializer().Deserialize<List<ReqDetailsForCart>>(json);

            if (ModelState.IsValid)
            {
                request.Status = 1;
                request.RestaurantId = restaurant.Id;
                request.AreaId = restaurant.AreaId;
                var distributeRequest = DisReqRepo.Create(request);

                ReqDetailsRepo.Create(foods, distributeRequest.Id);

                Session.Remove("FoodDetail");
                return RedirectToAction("Index");


            }
            else if (Session["FoodDetail"] != null)
            {
                ViewBag.FoodDetails = foods;
            }
            return View(request);
        }
        [HttpPost]
        public ActionResult AddToCart(ReqDetailsForCart detail)
        {
            if (detail.FoodName != null)
            {
                if (Session["FoodDetail"] == null)
                {
                    List<ReqDetailsForCart> foods = new List<ReqDetailsForCart>();
                    foods.Add(new ReqDetailsForCart()
                    {
                        Id = 1,
                        FoodName = detail.FoodName,
                    });
                    string json = new JavaScriptSerializer().Serialize(foods);
                    Session["FoodDetail"] = json;

                }
                else
                {
                    string json = (string)Session["FoodDetail"];
                    var foods = new JavaScriptSerializer().Deserialize<List<ReqDetailsForCart>>(json);
                    foods.Add(new ReqDetailsForCart()
                    {
                        Id = foods.Count + 1,
                        FoodName = detail.FoodName,
                    });
                    json = new JavaScriptSerializer().Serialize(foods);
                    Session["FoodDetail"] = json;
                }
            }

            return RedirectToAction("DistributeRequests");
        }
    }
}