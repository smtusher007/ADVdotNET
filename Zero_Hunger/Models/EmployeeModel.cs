using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
    }
}