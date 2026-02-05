  using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? Type { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
    }

}
