using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OptifySoft.DTO
{
    public class UpdateMenuDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }

        public int? ParentId { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
    }
}
