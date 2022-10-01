using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class TusherController : Controller
    {
        // GET: Tusher
        public ActionResult HomePage()
        {
            return View("HomePage");
        }
        public ActionResult education()
        {
            return View();
        }
        public ActionResult projects()
        {
            return View();
        }
        public ActionResult references()
        {
            return View();
        }
    }
}