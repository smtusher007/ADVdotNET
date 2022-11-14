using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class DisReqModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int EmpId { get; set; }
        public int AreaId { get; set; }
        public int Status { get; set; }

    }
}