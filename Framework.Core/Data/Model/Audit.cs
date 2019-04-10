using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Framework.Core.Data.Model
{
    public class Audit
    {
        public Guid Id { get; set; }
        public string ItemId { get; set; }

        public int? ApplicationTypeId { get; set; }

        public string TableName { get; set; }
        public char CrudOperation { get; set; }

        public int AuditTypeId { get; set; }
        public string ItemJson { get; set; }
        public string OldItemJson { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual AuditType AuditType { get; set; }


    }
}
