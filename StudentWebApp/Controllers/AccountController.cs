using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentWebApp.Models;
using WebMatrix.WebData;
using WebMatrix.Data;
using System.Web.Security;

namespace StudentWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login loginData, string ReturnUrl)
        {

            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(loginData.Username, loginData.Password))
                {
                    //string username = User.Identity.Name;
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry the username or password is invalid");
                    return View(loginData);
                }
            }
            ModelState.AddModelError("", "Sorry the username or password is invalid");
            return View(loginData);

            //return Content(loginData.Username + "," + loginData.Password);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register registerData, string role)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registerData.Username, registerData.Password);
                    Roles.AddUserToRole(registerData.Username, role);

                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException exception)
                {
                    ModelState.AddModelError("", "Sorry the username already exists");
                    return View(registerData);
                }
            }
            ModelState.AddModelError("", "Sorry the username already exists");
            return View(registerData);

            //return Content(registerData.Username + "," + registerData.Password);
        }
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
