using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class StockTransaction
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public string? Type { get; set; } // IN / OUT
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }

}
