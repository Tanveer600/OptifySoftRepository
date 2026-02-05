using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int RoleId { get; set; }
        public decimal Salary { get; set; }
        public string? Documents { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }

}
