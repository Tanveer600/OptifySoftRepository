using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.OptifySoft.Entities
{
  public class  MenuPermission
    {
        public int MenuPermissionId { get; set; }
        public int MenuID { get; set; }
        public int PermissionID { get; set; }
    }
}
