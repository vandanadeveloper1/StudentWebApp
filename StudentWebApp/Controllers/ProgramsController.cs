using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWebApp.Controllers
{
    public class ProgramsController : Controller
    {
        // GET: Program
        public ActionResult Art()
        {
            return View();
        }
        public ActionResult Music()
        {
            return View();
        }
        public ActionResult Reading()
        {
            return View();
        }
        public ActionResult Outdoor()
        {
            return View();
        }
    }
}