using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS_BL.Entities;
using LMS_BL.Repositories;
using LMS_BL.Repositories.Abstract;

namespace LMS_BL.Repositories.EntityRepository
{
    public class EntityEmployeeRepository : IEmployeeRepository
    {
        LMSDbContext context = new LMSDbContext();

        Employee IEmployeeRepository.GetEmployeeByUserID(string UserID)
        {
            int empid = int.Parse(UserID);
            return context.Employees.Single(e => e.ID == empid);
        }
    }
}
