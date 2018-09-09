using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using LMS_BL.Entities;
using LMS_BL.Repositories;
using LMS_BL.Repositories.Abstract;

namespace LMS_BL.Repositories.EntityRepository
{
    public class LeaveRepository : ILeaveRepository
    {
        LMSDbContext context = new LMSDbContext();
        public List<LeaveType> GetAllLeaves()
        {
            var leaveTypes = context.LeaveTypes.AsEnumerable().ToList<LeaveType>();
            return leaveTypes;
        }

        public void AddEmployeeLeave(EmployeeLeave employeeLeave)
        {

            var empRepMang = context.Employees.Where(m => m.ID == employeeLeave.EmpID).FirstOrDefault();
            employeeLeave.NoOfDays = (decimal)((employeeLeave.ToDate - employeeLeave.FromDate).TotalDays);
            context.EmployeeLeaves.Add(employeeLeave);
            context.SaveChanges();
            if (employeeLeave.Status == LeaveStatus.Pending)
            {
                context.EmployeeLeaveApprovals.Add(new EmployeeLeaveApproval
                {
                    ApproverID = empRepMang.ReportingManager,
                    LeaveID = employeeLeave.ID,
                    Status = LeaveStatus.Pending
                });
                context.Entry(employeeLeave.employeeLeaveApproval).Reference(e => e.Approver).Load();
            }
            //employeeLeave = context.EmployeeLeaves.Include(p => p.LeaveType).Include(p=>p.employeeLeaveApproval.Approver).Where(p => p.ID == employeeLeave.ID).FirstOrDefault();
            context.Entry(employeeLeave).Reference(e => e.LeaveType).Load();
            context.Entry(employeeLeave).Reference(e => e.employeeLeaveApproval).Load();

            context.SaveChanges();

        }

        public IEnumerable<EmployeeLeaveBalance> GetEmployeeLeaveBalance(int EmpID)
        {
            var empleaveBalances = context.EmployeeLeaveBalances.Where(e => e.EmpID == EmpID).AsEnumerable();            
            return empleaveBalances;
        }

        public IEnumerable<EmployeeLeaveApproval> GetLeaveApprovals(int approverID)
        {
            var pendingApprovals = context.EmployeeLeaveApprovals.Where(c => c.ApproverID == approverID).AsEnumerable();            
            return pendingApprovals;
        }

        public IEnumerable<EmployeeLeaveApproval> GetLeaveApprovals(int approverID, int[] leaveTypes, DateTime FromDate, DateTime ToDate)
        {
            var pendingApprovals = context.EmployeeLeaveApprovals
                .Where(c => c.ApproverID == approverID && 
                    c.EmployeeLeave.FromDate >= FromDate && 
                    c.EmployeeLeave.ToDate <= ToDate &&
                    leaveTypes.Contains(c.EmployeeLeave.LeaveType.ID)).AsEnumerable();
            return pendingApprovals;
        }

        public string SetApproval(int RecID, string status)
        {
            EmployeeLeaveApproval obj = context.EmployeeLeaveApprovals.Where(c => c.ID == RecID).FirstOrDefault();
            obj.Status = status;
            context.SaveChanges();
            return obj.Status;
        }


    }
}
