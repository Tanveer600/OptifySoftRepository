using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class AuditLog
    {
        public int AuditId { get; set; }
        public string? TableName { get; set; }
        public int RecordId { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
        public string? Action { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public int PerformedBy { get; set; }
        public DateTime PerformedAt { get; set; }
    }

}
