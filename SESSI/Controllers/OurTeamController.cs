using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SESSI.Controllers
{
    public class OurTeamController : Controller
    {
        // GET: OurTeam
        public ActionResult Organogram()
        {
            return View();
        }
        public ActionResult Committee()
        {
            return View();
        }
        public ActionResult Members()
        {
            return View();
        }
        public ActionResult SeniorityList()
        {
            return View();
        }
    }
}