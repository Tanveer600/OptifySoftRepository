using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class PurchaseOrderItem
    {
        public int POItemId { get; set; }
        public int POId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int TenantId { get; set; }
    }

}
