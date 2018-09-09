using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS_BL.Entities;

namespace LMS_BL.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByUserID(string UserID);
    }

    public interface ILeaveRepository
    {
        List<LeaveType> GetAllLeaves();
        void AddEmployeeLeave(EmployeeLeave employeeLeave);
        IEnumerable<EmployeeLeaveBalance> GetEmployeeLeaveBalance(int EmpID);
        IEnumerable<EmployeeLeaveApproval> GetLeaveApprovals(int approverID);
        IEnumerable<EmployeeLeaveApproval> GetLeaveApprovals(int approverID, int[] leaveTypes, DateTime FromDate, DateTime ToDate);
        string SetApproval(int RecID, string status);
    }
}
