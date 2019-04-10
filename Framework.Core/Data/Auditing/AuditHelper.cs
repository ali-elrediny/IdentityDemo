using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Data.Model;

namespace Framework.Core.Data.Auditing
{
    internal static class AuditHelper
    {
        internal static void AddAudit(Audit audit)
        {
            using (var uow = new CommonsUnitOfWork())
            {
                uow.Audits.Add(audit);
                uow.Save();
            }
        }
    }
}
