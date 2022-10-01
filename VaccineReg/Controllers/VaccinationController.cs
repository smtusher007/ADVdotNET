using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineReg.Models;

namespace VaccineReg.Controllers
{
    public class VaccinationController : Controller
    {
        // GET: Vaccination

        [HttpGet]
        public ActionResult Registration()
        {
            return View("Registration");
        }
        
        [HttpPost]
        public ActionResult Registration(Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", "Vaccination");
            }
        
            return View(vaccine);
        }
        public ActionResult Confirm()
        {
            return View();
        }
 

    }
}