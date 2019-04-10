using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Core.Contracts;
using Framework.Core.Data.Model;
using Framework.Core.Data.ViewModel;
using Framework.Core.Extensions;
using Framework.Core.Notifications;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace Framework.Core.Data.Repositories
{
    public partial class AuditsRepository : RepositoryBase<Audit>
    {
        public AuditsRepository(DbContext context) : base(context)
        {
        }

        public AuditListViewModel Search(AuditListViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            var query = this.DbSet.AsNoTracking();

            var selectedQuery = query.Select(i => new AuditListItemViewModel
            {
                Id = i.Id,
                ItemId = i.ItemId,
                ActionTypeId = i.AuditTypeId
            });

            var pagedResult = selectedQuery.GetPaged(
                o => o.ActionTypeId,
                false,
                vm.PageNumber,
                vm.PageSize = this.ApplicationSettingsService.DefaultPagerPageSize);

            vm.Items = new StaticPagedList<AuditListItemViewModel>(
                pagedResult,
                pagedResult.PageNumber,
                pagedResult.PageSize,
                pagedResult.TotalItemCount);

            return vm;
        }
    }
}
