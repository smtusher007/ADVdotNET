using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DB;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class EmployeeRepo
    {
        public static List<EmployeeModel> Get()
        {
            var employees = new List<EmployeeModel>();
            var db = new ZeroHungerDbEntities();

            foreach (var employee in db.Employees)
            {
                employees.Add(new EmployeeModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    PhoneNo = employee.PhoneNo,
                    UserId = employee.UserId,
                    AreaId = employee.AreaId
                });
            }

            return employees;
        }
        public static EmployeeData Get(int UserId)
        {
            var db = new ZeroHungerDbEntities();
            var employee = new EmployeeData();
            var db_employee = (from ad in db.Employees
                               where ad.UserId == UserId
                               select ad).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == UserId
                           select ad).SingleOrDefault();


            employee.Name = db_employee.Name;
            employee.PhoneNo = db_employee.PhoneNo;
            employee.UserId = db_employee.UserId;
            employee.AreaId = db_employee.AreaId;

            return employee;

        }
        public static string Update(EmployeeData employee)
        {
            var db = new ZeroHungerDbEntities();
            var db_employee = (from emp in db.Employees
                               where emp.UserId == employee.UserId
                               select emp).SingleOrDefault();
            var db_user = (from ad in db.Users
                           where ad.Id == employee.UserId
                           select ad).SingleOrDefault();

            
            db_employee.Name = employee.Name;
            db_employee.PhoneNo = employee.PhoneNo;
            db_employee.AreaId = employee.AreaId;
            db.SaveChanges();

            return "Update Successful";

        }
        public static void Create(EmployeeModel employee)
        {

            var db = new ZeroHungerDbEntities();
            var newUser = db.Employees.Add(new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNo = employee.PhoneNo,
                AreaId = employee.AreaId,
                UserId = employee.UserId,
            });
            db.SaveChanges();
        }
    }
}