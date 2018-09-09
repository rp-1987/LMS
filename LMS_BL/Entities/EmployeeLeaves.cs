using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_BL.Entities
{
    public class EmployeeLeave : IValidatableObject
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        [Required(ErrorMessage="Please select Leave Type")]
        public int LeaveTypeID { get; set; }
        [Required(ErrorMessage = "Please select From Date")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "Please select To Date")]
        public DateTime ToDate { get; set; }
        public decimal NoOfDays { get; set; }
        public bool HalfDay { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage="Please enter comments for Leave Request")]
        public string Comments { get; set; }
        [ForeignKey("EmpID")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }
        public virtual EmployeeLeaveApproval employeeLeaveApproval { get; set; }
        public virtual ICollection<EmployeeLeaveDocument> EmployeeLeaveDocuments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ToDate < FromDate)
            {
                yield return new ValidationResult("ToDate cannot be greater than FromDate");
            }
        }
    }

    public class EmployeeLeaveBalance
    {
        [Key]
        public Int64 SrNo { get; set; }
        public int EmpID { get; set; }
        public int LeaveTypeID { get; set; }
        public string LeaveCode { get; set; }
        public string Description { get; set; }
        public decimal Entitled { get; set; }
        public decimal Pending { get; set; }
        public decimal Taken { get; set; }
        public decimal Balance { get; set; }
    }
}
