using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        
    }
}