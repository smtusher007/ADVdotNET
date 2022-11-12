using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class RestaurantData
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public string Address { get; set; }
    }
}