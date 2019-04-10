// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotificationRepository.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Repositories
{
    #region usings

    using Framework.Core.Data.Model;

    #region

    using Microsoft.EntityFrameworkCore;

    #endregion

    #endregion

    /// <summary>
    ///     The attachment type repository.
    /// </summary>
    public class WebNotificationRepository : RepositoryBase<WebNotification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebNotificationRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public WebNotificationRepository(DbContext context)
            : base(context)
        {
        }
    }
}