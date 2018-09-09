using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_UI.Infrastructure.Filters;
using LMS_BL.Entities;
using LMS_UI.Models;


namespace LMS_UI.Controllers
{
    [EmployeeDataActionFilter]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Employee emp = (Employee)Session["Employee"];
            return View(emp);
        }

        public ActionResult GetMenuItems()
        {
            Employee emp = (Employee)Session["Employee"];
            
            MenuViewModel obj = new MenuViewModel();
            return View(obj.GetAllMenus(emp.Department.Name));
        }


        public ActionResult GetEmpDetails()
        {
            Employee emp = (Employee)Session["Employee"];
            return View(emp);
        }

    }

}
