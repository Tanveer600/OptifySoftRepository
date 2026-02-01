using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class SalesOrder
    {
        public int SaleOrderId { get; set; }
        public int QuotationId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }
}
