using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_BL.Entities
{
    public class Employee
    {
        public Employee()
        {

        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int ReportingManager { get; set; }
        public int DeptID { get; set; }
        public int DesignationID { get; set; }
        public DateTime DOB { get; set; }
        public int LocationID { get; set; }
        public DateTime JoiningDate { get; set; }
        public string BloodGroup { get; set; }

        //Foriegn Key Properties
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }
        [ForeignKey("DesignationID")]
        public virtual Designation Designation { get; set; }
        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
        public virtual ICollection<Employee> ReportingManagers { get; set; }
        public virtual ICollection<Employee> HODs { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeeLeaveApproval> EmployeeLeaveApprovals { get; set; }
        public virtual ICollection<EmployeeLeaveDocument> HRApprovers { get; set; }
    }
}
