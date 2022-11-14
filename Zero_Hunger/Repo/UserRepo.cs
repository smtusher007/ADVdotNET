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
                    Password = user.Password,
                    Email = user.Email,
                    PhoneNo = user.PhoneNo,
                    Type = user.Type

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
            user.Password = u.Password;
            user.Email = u.Email;
            user.PhoneNo = u.PhoneNo;
            user.Type = u.Type;

            return user;
        }
        public static UserModel Get(string Email, string Password, int Type)
        {
            var db = new ZeroHungerDbEntities();
            var user = new UserModel();
            var us = (from needUser in db.Users
                      where needUser.Email == Email && needUser.Type == Type
                      select needUser).SingleOrDefault();
            if (us != null)
            {
                if (us.Password == Password)
                {
                    user.Id = us.Id;
                    user.Email = us.Email;
                    user.Password = us.Password;
                    user.Type = us.Type;

                    return user;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public static User Create(UserModel user)
        {
            var db = new ZeroHungerDbEntities();
            var newUser = db.Users.Add(new User()
            {
                Id = user.Id,
                Username = user.Username,
                Password= user.Password,
                Email = user.Email,
                PhoneNo = user.PhoneNo,
                Type = user.Type
            });
            db.SaveChanges();
            return newUser;

        }
    }
}