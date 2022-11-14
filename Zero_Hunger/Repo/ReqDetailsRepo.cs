using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DB;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class ReqDetailsRepo
    {
        public static List<ReqDetails> Get()
        {
            var db = new ZeroHungerDbEntities();
            var foods = new List<ReqDetails>();

            foreach (var item in db.ReqDetails.ToList())
            {

                var food = new ReqDetails();
                food.Id = item.Id;
                food.FoodName = item.FoodName;
                food.ReqId = item.ReqId;
                foods.Add(food);
            }

            return foods;
        }
        public static List<ReqDetails> Get(int ReqId)
        {
            var db = new ZeroHungerDbEntities();
            var foods = new List<ReqDetails>();

            foreach (var item in db.ReqDetails.ToList())
            {
                if (item.ReqId == ReqId)
                {
                    var food = new ReqDetails();
                    food.Id = item.Id;
                    food.FoodName = item.FoodName;
                    food.ReqId = item.ReqId;
                    foods.Add(food);
                }
            }

            return foods;
        }
        public static void Create(List<ReqDetailsForCart> foods, int ReqId)
        {
            var db = new ZeroHungerDbEntities();
            foreach (var item in foods)
            {
                var details = new ReqDetail()
                {
                    FoodName = item.FoodName,
                    ReqId = ReqId
                };
                db.ReqDetails.Add(details);
            }
            db.SaveChanges();
        }
    }
}