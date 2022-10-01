using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccineReg.Models
{
    public class Vaccine
    {
        [Required(ErrorMessage = "This Field is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Character should between 3 to 25")]
        public string name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
    }
}