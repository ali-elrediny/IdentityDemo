// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemSettingsRepository.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Repositories
{
    using System.Collections.Generic;
    #region usings

    using System.Linq;

    using Framework.Core.Data.Model;
    using Framework.Core.Extensions;

    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;

    #endregion

    /// <summary>
    ///     The system settings repository.
    /// </summary>
    public class SystemSettingsRepository : RepositoryBase<SystemSetting>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemSettingsRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public SystemSettingsRepository(DbContext context)
            : base(context)
        {
        }
        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="applicationId">
        /// The application id.
        /// </param>
        public void Delete(string key, string applicationId = null)
        {
            var setting = this.DbSet.Where(c => c.Key == key && c.ApplicationId == applicationId);
            this.Delete(setting);
        }
        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="applicationId">
        /// The application id.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetValue<T>(string key, string applicationId = null)
        {
            var setting = this.GetAll().FirstOrDefault(e => e.Key == key && (e.ApplicationId == applicationId || applicationId == null));
            return setting == null ? default(T) : setting.Value.To<T>();
        }
        //Updated by Hoda 2018-12-4 to remove many requests to DB GetValue call for each item from DB request.
        internal List<SystemSetting> GetAll()
        {
            var setting = this.DbSet.FromCache(Caching.CachePolicy,
                    Caching.Keys.SystemSettings,
                    Caching.Keys.AllCacheKeys).ToList();
            return setting;
        }
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="applicationId">
        /// The application id.
        /// </param>
        public void Update(string key, string value, string applicationId = null)
        {
            var setting = this.DbSet.FirstOrDefault(
                c => c.Key == key && (c.ApplicationId == applicationId || applicationId == null));

            if (setting != null)
            {
                setting.Value = value;
            }
        }
    }
}