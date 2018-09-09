using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_BL.Entities
{
    public class EmployeeLeaveApproval
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key, ForeignKey("EmployeeLeave")]
        public int LeaveID { get; set; }
        public int ApproverID { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        [ForeignKey("LeaveID")]
        public virtual EmployeeLeave EmployeeLeave { get; set; }
        [ForeignKey("ApproverID")]
        public virtual Employee Approver { get; set; }
    }
}
