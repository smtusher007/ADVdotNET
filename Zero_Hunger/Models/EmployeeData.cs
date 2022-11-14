using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class EmployeeData
    { 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}