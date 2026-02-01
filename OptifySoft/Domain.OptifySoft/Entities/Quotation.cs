using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Quotation
    {
        public int QuotationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }
}
