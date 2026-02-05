using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int SalesOrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VAT { get; set; }
        public string? PaymentStatus { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }

}
