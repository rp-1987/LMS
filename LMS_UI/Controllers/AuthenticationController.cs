using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMS_UI.Controllers
{
    public class AuthenticationController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            //string Username = Request.Form["Username"];
            //string Password = Request.Form["Password"];
            LoginService.LoginServiceClient client = new LoginService.LoginServiceClient();
            if (client.AuthenticateUser(Username, Password))
            {
                Session["UserId"] = Username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Error"] = "Invalid Username/Credentials";
                return View();
            }
        }
    }
}
