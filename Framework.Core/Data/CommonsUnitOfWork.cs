// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonsUnitOfWork.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data
{
    #region usings

    using System;

    using Framework.Core.Data.Repositories;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    #endregion

    /// <summary>
    ///     The commons unit of work.
    /// </summary>
    public sealed class CommonsUnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        private ILogger Logger { get; } = ApplicationLogging.CreateLogger<CommonsUnitOfWork>();
        /// <summary>
        ///     The http context accessor.
        /// </summary>
        public IHttpContextAccessor HttpContextAccessor { get; }

        public CommonsUnitOfWork()
        {
            this.context = new CommonsDbEntities();
            this.SystemSettings = new SystemSettingsRepository(this.context);
            this.AttachmentTypes = new AttachmentTypeRepository(this.context);
            this.NotificationTemplates = new NotificationTemplatesRepository(this.context);
            this.WebNotifications = new WebNotificationRepository(this.context);
            this.WebNotificationUsers = new WebNotificationUsersRepository(this.context);
            this.Audits = new AuditsRepository(this.context);
            this.AuditTypes = new AuditTypesRepository(this.context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonsUnitOfWork"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="httpContextAccessor">
        /// The http Context Accessor.
        /// </param>
        public CommonsUnitOfWork(
            ILogger<UnitOfWorkBase> logger, 
            IHttpContextAccessor httpContextAccessor)
            : base(logger, httpContextAccessor)
        {
            this.context = new CommonsDbEntities();
            this.SystemSettings = new SystemSettingsRepository(this.context);
            this.AttachmentTypes = new AttachmentTypeRepository(this.context);
            this.NotificationTemplates = new NotificationTemplatesRepository(this.context);
            this.WebNotifications = new WebNotificationRepository(this.context);
            this.WebNotificationUsers = new WebNotificationUsersRepository(this.context);

            this.Audits = new AuditsRepository(this.context);
            this.AuditTypes = new AuditTypesRepository(this.context);

            this.HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="CommonsUnitOfWork" /> class.
        /// </summary>
        ~CommonsUnitOfWork()
        {
            this.Dispose(false);
        }

        public AuditTypesRepository AuditTypes { get; set; }

        public AuditsRepository Audits { get; set; }

        /// <summary>
        ///     Gets or sets the notification template.
        /// </summary>
        public NotificationTemplatesRepository NotificationTemplates { get; set; }

        /// <summary>
        ///     Gets or sets the system settings.
        /// </summary>
        public SystemSettingsRepository SystemSettings { get; set; }

        /// <summary>
        ///     Gets or sets the web notifications.
        /// </summary>
        public WebNotificationRepository WebNotifications { get; set; }

        /// <summary>
        ///     Gets or sets the web notification users.
        /// </summary>
        public WebNotificationUsersRepository WebNotificationUsers { get; set; }

        /// <summary>
        ///     Gets or sets the attachment types.
        /// </summary>
        internal AttachmentTypeRepository AttachmentTypes { get; set; }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context?.Dispose();
                var dbContext = this.context;
                dbContext?.Dispose();
            }
        }
    }
}