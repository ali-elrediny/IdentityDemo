using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModeifiedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
