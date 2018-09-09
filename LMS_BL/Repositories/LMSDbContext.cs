using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using LMS_BL.Entities;
using System.Configuration;

namespace LMS_BL.Repositories
{
    class LMSDbContext : DbContext
    {

        public LMSDbContext()
            : base(ConfigurationManager.ConnectionStrings["LMSDbContext"].ConnectionString)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LeaveBalance> LeaveBalanceMaster { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public DbSet<EmployeeLeaveApproval> EmployeeLeaveApprovals { get; set; }
        public DbSet<EmployeeLeaveDocument> EmployeeLeaveDocuments { get; set; }
        public DbSet<EmployeeLeaveDocumentData> EmployeeLeaveDocumentDataset { get; set; }
        public DbSet<EmployeeLeaveBalance> EmployeeLeaveBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeLeaveDocument>().HasRequired(e => e.employeeLeaveDocumentData).WithRequiredPrincipal();
            modelBuilder.Entity<EmployeeLeaveDocument>().ToTable("EmployeeLeaveDocuments");
            modelBuilder.Entity<EmployeeLeaveDocumentData>().ToTable("EmployeeLeaveDocuments");
        }
    }


}
