using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class FollowUp
    {
        public int FollowUpId { get; set; }
        public int LeadId { get; set; }
        public DateTime Date { get; set; }
        public string? Type { get; set; }
        public string? Notes { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }
}
