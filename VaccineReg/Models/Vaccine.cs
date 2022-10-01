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
        [Required]
        [RegularExpression(@"^(?:\+? 88 | 0088)?01[15-9]\d{8}$", ErrorMessage="Phone Number is not Correct")]
        public string phoneNo { get; set; }
    }
}