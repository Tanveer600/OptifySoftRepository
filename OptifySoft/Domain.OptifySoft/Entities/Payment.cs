using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Mode { get; set; }
        public string? Status { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }

}
