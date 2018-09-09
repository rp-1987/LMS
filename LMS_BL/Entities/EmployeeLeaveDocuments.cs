using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_BL.Entities
{
    public class EmployeeLeaveDocument
    {
        public int ID { get; set; }
        public int LeaveID { get; set; }
        public int DocumentID { get; set; }        
        public string Status { get; set; }
        public int HRReviewer { get; set; }
        
        public virtual Document Document { get; set; }
        public virtual EmployeeLeave Leave { get; set; }        
        public virtual EmployeeLeaveDocumentData employeeLeaveDocumentData { get; set; }
    }

    public class EmployeeLeaveDocumentData
    {
        [Key]
        public int EmployeeDocumentID { get; set; }
        public byte[] DocumentBin { get; set; }
        public string DocumentName { get; set; }
        public string DocumentMIMEType { get; set; }
    }
}
