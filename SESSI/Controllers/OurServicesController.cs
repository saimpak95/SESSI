using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SESSI.Controllers
{
    public class OurServicesController : Controller
    {
        // GET: OurServices
        public ActionResult Functions()
        {
            return View();
        }


        public ActionResult MedicalServices()
        {
            return View();
        }

        public ActionResult CashBenefits()
        {
            return View();
        }
    }
}