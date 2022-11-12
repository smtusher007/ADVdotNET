using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DB;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class RestaurantRepo
    {
        public static List<RestaurantModel> Get()
        {
            var restaurants = new List<RestaurantModel>();
            var db = new ZeroHungerDbEntities();

            foreach (var restaurant in db.Restaurants)
            {
                restaurants.Add(new RestaurantModel()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    UserId = restaurant.UserId,
                    AreaId = restaurant.AreaId,
                    Address = restaurant.Address,
                });
                
            }
            return restaurants;
        }
        public static RestaurantData Get(int UserId)
        {
            var db = new ZeroHungerDbEntities();
            var restaurant = new RestaurantData();
            var db_restaurant = (from ad in db.Restaurants
                                 where ad.UserId == UserId
                                 select ad).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == UserId
                           select ad).SingleOrDefault();


            restaurant.Name = db_restaurant.Name;
            restaurant.UserId = UserId;
            restaurant.AreaId = db_restaurant.AreaId;
            restaurant.Address = db_restaurant.Address;

            return restaurant;

        }
        public static string Update(RestaurantData restaurant)
        {
            var db = new ZeroHungerDbEntities();
            var db_restaurant = (from res in db.Restaurants
                                 where res.UserId == restaurant.UserId
                                 select res).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == restaurant.UserId
                           select ad).SingleOrDefault();

            db_restaurant.Name = restaurant.Name;
            db_restaurant.Address = restaurant.Address;
            db_restaurant.AreaId = restaurant.AreaId;
            db.SaveChanges();

            return "Update Successful";

        }
        public static void Create(RestaurantModel restaurant)
        {

            var db = new ZeroHungerDbEntities();
            var newUser = db.Restaurants.Add(new Restaurant()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                AreaId = restaurant.AreaId,
                UserId = restaurant.UserId,
                Address = restaurant.Address,
            });
            db.SaveChanges();
        }
    }
}