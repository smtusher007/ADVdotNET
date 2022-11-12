using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Zero_Hunger.DB;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class UserRepo
    {
        public static List<UserModel> Get()
        {
            var users = new List<UserModel>();
            var db = new ZeroHungerDbEntities();

            foreach (var user in db.Users)
            {
                users.Add(new UserModel()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    PhoneNo = user.PhoneNo,

                });

            }
            return users;
        }
        public static UserModel Get(int Id)
        {
            var db = new ZeroHungerDbEntities();
            var user = new UserModel();
            var u = db.Users.Find(Id);

            user.Id = u.Id;
            user.Username = u.Username;
            user.Email = u.Email;
            user.PhoneNo = u.PhoneNo;

            return user;
        }
        public static User Create(UserModel user)
        {
            var db = new ZeroHungerDbEntities();
            var newUser = db.Users.Add(new User()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNo = user.PhoneNo
            });
            db.SaveChanges();
            return newUser;

        }
    }
}