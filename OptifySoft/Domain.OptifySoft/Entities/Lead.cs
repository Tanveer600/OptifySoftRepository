using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Lead
    {
        public int LeadId { get; set; }
        public int CustomerId { get; set; }
        public string? Status { get; set; }
        public string? Source { get; set; }
        public int AssignedTo { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }
}
