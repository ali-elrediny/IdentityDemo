using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Data.Model
{
    public class AuditType
    {
        public AuditType()
        {
            Audits = new HashSet<Audit>();
        }

        public int Id { get; set; }
        public int? ApplicationTypeId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public virtual ICollection<Audit> Audits { get; set; }
    }
}
