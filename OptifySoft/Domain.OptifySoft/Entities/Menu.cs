using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }

        public int? ParentId { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
