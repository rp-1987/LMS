using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS_UI.Infrastructure.Filters;
using LMS_UI.Infrastructure.Attributes;
using LMS_BL.Entities;
using LMS_UI.Models;
using LMS_BL.Repositories.Abstract;
using LMS_BL.Repositories.EntityRepository;

namespace LMS_UI.Models
{
    public class EmployeeLeaveViewModel
    {
        public int ApproverID { get; set; }
        public int[] LeaveTypeIDs { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public IEnumerable<EmployeeLeave> employeeLeaves { get; set; }
        public IEnumerable<EmployeeLeaveApproval> employeeLeaveApprovals { get; set; }

        public EmployeeLeaveViewModel GetPendingApprovals()
        {
            ILeaveRepository leaveRepository = new LeaveRepository();
            this.employeeLeaveApprovals = leaveRepository.GetLeaveApprovals(this.ApproverID);

            return this;
 
        }
    }
}