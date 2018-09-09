using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS_UI.Infrastructure.Filters;
using LMS_UI.Infrastructure.Attributes;
using LMS_BL.Entities;
using LMS_UI.Models;
using LMS_BL.Repositories.Abstract;
using LMS_BL.Repositories.EntityRepository;

namespace LMS_UI.Controllers
{
    [EmployeeDataActionFilter]
    public class LeaveController : Controller
    {
        //
        // GET: /Leave/
        ILeaveRepository leaveRepository = new LeaveRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var selectLeaveTypes = new List<SelectListItem>();
            List<LeaveType> leaveTypes = leaveRepository.GetAllLeaves();
            foreach (var leave in leaveTypes)
            {
                selectLeaveTypes.Add(new SelectListItem { Text = (leave.Description + "(" + leave.Code + ")"), Value = leave.ID.ToString() });
            }
            ViewBag.LeaveTypeID = selectLeaveTypes;
            return View();
        }

        //[HttpParamAction]
        [HttpPost]
        public ActionResult Add(EmployeeLeave employeeLeave, string Command)
        {
            Employee emp = (Employee)Session["Employee"];
            
            employeeLeave.EmpID = emp.ID;
            if (ModelState.IsValid)
            {
                if (Command == "Save as Draft")
                {
                    employeeLeave.Status = LeaveStatus.Draft;
                    leaveRepository.AddEmployeeLeave(employeeLeave);
                    
                    return View("DraftMessage", employeeLeave);
                }
                else
                {
                    employeeLeave.Status = LeaveStatus.Pending;
                    leaveRepository.AddEmployeeLeave(employeeLeave);
                    return View("ConfirmLeave",employeeLeave);
                }
                
                
            }
            else
            {
                var selectLeaveTypes = new List<SelectListItem>();
                List<LeaveType> leaveTypes = leaveRepository.GetAllLeaves();
                foreach (var leave in leaveTypes)
                {
                    selectLeaveTypes.Add(new SelectListItem { Text = (leave.Description + "(" + leave.Code + ")"), Value = leave.ID.ToString() });
                }
                ViewBag.LeaveTypeID = selectLeaveTypes;
                return View(employeeLeave);
            }

        }


        public ActionResult Approve()
        {
            var selectLeaveTypes = new List<SelectListItem>();
            List<LeaveType> leaveTypes = leaveRepository.GetAllLeaves();
            ViewBag.LeaveTypeID = selectLeaveTypes;
            foreach (var leave in leaveTypes)
            {
                selectLeaveTypes.Add(new SelectListItem { Text = (leave.Description + "(" + leave.Code + ")"), Value = leave.ID.ToString() });
            }
            return View();
        }

        public PartialViewResult ApproveResponse(int[] LeaveType, string txtFromDate, string txtToDate)
        {
            Employee emp = (Employee)Session["Employee"];
            DateTime FromDate = (!string.IsNullOrWhiteSpace(txtFromDate)) ? DateTime.Parse(txtFromDate) : DateTime.Now;
            DateTime ToDate = (!string.IsNullOrWhiteSpace(txtToDate)) ? DateTime.Parse(txtToDate) : DateTime.Now;
            
            var leaveApprovals = leaveRepository.GetLeaveApprovals(emp.ID, LeaveType, FromDate, ToDate);
            return PartialView(leaveApprovals);
        }

        public ActionResult GetEmployeeBalances()
        {
            Employee emp = (Employee)Session["Employee"];
            var EmpBalances = leaveRepository.GetEmployeeLeaveBalance(emp.ID);
            return View(EmpBalances);
        }

        public ActionResult SetApproval(int ID, string Task)
        {
            string res = leaveRepository.SetApproval(ID, Task);
            return Content(res);
        }


    }
}
