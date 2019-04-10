// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationTemplatesRepository.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Repositories
{
    #region usings

    using System;
    using System.Linq;

    using Framework.Core.Data.Model;
    using Framework.Core.Notifications;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    ///     The notification templates repository.
    /// </summary>
    public class NotificationTemplatesRepository : RepositoryBase<NotificationTemplate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationTemplatesRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public NotificationTemplatesRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// The delete template.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void DeleteTemplate(string key)
        {
            var item = this.DbSet.FirstOrDefault(c => c.Key == key);

            if (item == null)
            {
                return;
            }

            this.Delete(item);
        }

        /// <summary>
        /// The delete template.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="notificationTypeId">
        /// The notification type id.
        /// </param>
        public void DeleteTemplate(string key, int notificationTypeId)
        {
            var item = this.DbSet.FirstOrDefault(c => c.Key == key && c.NotificationTypeId == notificationTypeId);

            if (item == null)
            {
                return;
            }

            this.Delete(item);
        }

        /// <summary>
        /// The get template.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="notificationType">
        /// The notification type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public string GetTemplate(string key, NotificationTypes notificationType)
        {
            var template = this.DbSet.FirstOrDefault(c => c.Key == key);

            if (template == null)
            {
                throw new Exception($@"Template Key '{key}' Not Found");
            }

            return template.Value;
        }

        /// <summary>
        /// The update template.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="notificationType">
        /// The notification type.
        /// </param>
        public void UpdateTemplate(string key, string value, NotificationTypes notificationType)
        {
            var setting = this.DbSet.FirstOrDefault(c => c.Key == key && c.NotificationTypeId == (int)notificationType);
            if (setting != null)
            {
                setting.Value = value;
            }
        }
    }
}