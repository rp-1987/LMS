using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_BL.Entities
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HOD { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Designation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; }
    }

    public class LeaveType
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<LeaveBalance> LeaveBalances { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
    }

    public class Document
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LeaveTypeID { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }
        public bool Mandatory { get; set; }
        public virtual ICollection<EmployeeLeaveDocument> EmployeeLeaveDocuments { get; set; }
    }

    public class LeaveBalance
    {
        public int ID { get; set; }
        public int DesignationID { get; set; }
        public int LeaveTypeID { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }
        public decimal AvailableLeave { get; set; }
    }

    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public static class LeaveStatus
    {
        public const string Approved = "Approved";
        public const string Pending = "Pending";
        public const string Updated = "Updated";
        public const string Cancelled = "Cancelled";
        public const string Rejected = "Rejected";
        public const string Draft = "Draft";

    }

    public static class DocumentStatus
    {
        public const string Pending = "Pending";
        public const string Received = "Received";

    }
}
