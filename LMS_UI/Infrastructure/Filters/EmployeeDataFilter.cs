using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_BL.Entities;
using LMS_BL.Repositories.Abstract;
using LMS_BL.Repositories.EntityRepository;

namespace LMS_UI.Infrastructure.Filters
{
    public class EmployeeDataActionFilter: ActionFilterAttribute, IActionFilter
    {
        IEmployeeRepository empRepository = new EntityEmployeeRepository();
        

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["UserId"] != null)
            {
                string userid = filterContext.HttpContext.Session["UserId"].ToString();
                Employee emp = empRepository.GetEmployeeByUserID(userid);
                filterContext.HttpContext.Session.Add("Employee", emp);
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("~");
            }
            this.OnActionExecuting(filterContext);
        }
    }
}