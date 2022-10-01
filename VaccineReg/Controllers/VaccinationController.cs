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
            return View();
        }
        
        [HttpPost]
        public ActionResult Confirm(Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", "Vaccination");
            }
            ViewBag.VaccineRegistration = vaccine.name;
            return View(vaccine);
        }
 

    }
}