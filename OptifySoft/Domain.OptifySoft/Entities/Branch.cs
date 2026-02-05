using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }

        public string BranchName { get; set; } = null!;

        public int? ParentBranchId { get; set; }   // NULL = Head Office
        public string? Address { get; set; }

        public string? Phone { get; set; }

        public bool IsHeadOffice { get; set; }
        public Branch? ParentBranch { get; set; }
        public ICollection<Branch> SubBranches { get; set; } = new List<Branch>();

        public bool IsActive { get; set; }

        public int TenantId { get; set; }
    }
}
