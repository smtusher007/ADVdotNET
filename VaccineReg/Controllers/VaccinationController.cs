using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VaccineReg.Controllers
{
    public class VaccinationController : Controller
    {
        // GET: Vaccination
        public ActionResult Registration()
        {
            return View();
        }
    }
}