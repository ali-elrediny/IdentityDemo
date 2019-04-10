using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Core.Contracts;
using Framework.Core.Data.Model;
using Framework.Core.Globalization;
using Framework.Core.Notifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Framework.Core.Data.Repositories
{

    public partial class AuditTypesRepository : RepositoryBase<AuditType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationTemplatesRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public AuditTypesRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<AuditType> GetAll()
        {
            return this.DbSet.ToList();
        }

        /// <summary>
        /// The get all select list items.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<SelectListItem> GetAllListItems()
        {
            return this.DbSet.Select(o => new SelectListItem
                {Text = CultureHelper.IsArabic ? o.NameAr : o.NameEn, Value = o.Id.ToString()}).ToList();
        }

        public List<SelectListItem> GetHistoryLogTypesByApplicationId(int applicationId)
        {
            return this.DbSet.Where(x => x.ApplicationTypeId == applicationId)?.Select(o =>
                    new SelectListItem {Text = CultureHelper.IsArabic ? o.NameAr : o.NameEn, Value = o.Id.ToString()})
                .ToList();
        }


    }
}
