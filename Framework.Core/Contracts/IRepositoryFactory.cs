// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryFactory.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Contracts
{
    using Framework.Core.Notifications;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The i repo.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Gets the application settings service.
        /// </summary>
        IApplicationSettingsService ApplicationSettingsService { get; }

        /// <summary>
        /// Gets the caching service.
        /// </summary>
        ICachingService CachingService { get; }

        /// <summary>
        ///     Gets the context.
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// The lookups service.
        /// </summary>
        ILookupsService LookupsService { get; }

        /// <summary>
        /// The notification service.
        /// </summary>
        INotificationService NotificationService { get; }

        /// <summary>
        /// The users service.
        /// </summary>
        IUsersService UsersService { get; }

      
    }
}