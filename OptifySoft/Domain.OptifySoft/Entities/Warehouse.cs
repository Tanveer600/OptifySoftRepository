using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }

}
