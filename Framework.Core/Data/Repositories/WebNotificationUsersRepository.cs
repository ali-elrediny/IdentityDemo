// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotificationUsersRepository.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Repositories
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Framework.Core.Data.Model;
    using Framework.Core.Data.ViewModel;

    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    ///     The attachment type repository.
    /// </summary>
    public class WebNotificationUsersRepository : RepositoryBase<WebNotificationUsers>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebNotificationUsersRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public WebNotificationUsersRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<WebNotificationsViewModel> GetAll(Guid userId)
        {
            return this.DbSet.Where(a => a.AspNetUsersId == userId).OrderByDescending(z => z.CreatedOn).Select(
                w => new WebNotificationsViewModel
                         {
                             Message = w.WebNotification.MessageContent,
                             CreatedOn = w.CreatedOn,
                             IsNotified = w.IsNotified,
                             IsSeen = w.IsSeen,
                             NotifiedDateTime = w.NotifiedDateTime,
                             SeenDateTime = w.SeenDateTime,
                             WebNotificationId = w.WebNotificationId,
                             Url = w.WebNotification.Url
                         }).Take(200).ToList();
        }

        /// <summary>
        /// The get byweb notification id.
        /// </summary>
        /// <param name="webNotificationId">
        /// The web notification id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="WebNotificationUsers"/>.
        /// </returns>
        public WebNotificationUsers GetBywebNotificationId(Guid webNotificationId, Guid userId)
        {
            return this.DbSet.FirstOrDefault(
                a => a.WebNotificationId == webNotificationId && a.AspNetUsersId == userId);
        }

        /// <summary>
        /// The get top 10.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<WebNotificationsViewModel> GetTop10(Guid userId)
        {
            return this.DbSet.Where(a => a.AspNetUsersId == userId).OrderByDescending(z => z.CreatedOn).Take(10).Select(
                w => new WebNotificationsViewModel
                         {
                             Message = w.WebNotification.MessageContent,
                             CreatedOn = w.CreatedOn,
                             IsNotified = w.IsNotified,
                             IsSeen = w.IsSeen,
                             NotifiedDateTime = w.NotifiedDateTime,
                             SeenDateTime = w.SeenDateTime,
                             WebNotificationId = w.WebNotificationId,
                             Url = w.WebNotification.Url
                         }).ToList();
        }

        /// <summary>
        /// The get un notified message.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<WebNotificationsViewModel> GetUnNotifiedMessage(Guid userId)
        {
            return this.DbSet.Where(a => !a.IsNotified && a.AspNetUsersId == userId).Select(
                w => new WebNotificationsViewModel
                         {
                             Message = w.WebNotification.MessageContent,
                             CreatedOn = w.CreatedOn,
                             IsNotified = w.IsNotified,
                             IsSeen = w.IsSeen,
                             NotifiedDateTime = w.NotifiedDateTime,
                             SeenDateTime = w.SeenDateTime,
                             WebNotificationId = w.WebNotificationId,
                             Url = w.WebNotification.Url
                         }).ToList();
        }

        /// <summary>
        /// The get un seen.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int getUnSeen(Guid userId)
        {
            return this.DbSet.Count(a => a.AspNetUsersId == userId && !a.IsSeen);
        }

        /// <summary>
        /// The notified.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        public void Notified(Guid id, Guid userId)
        {
            var webNotificationUsers = this.GetBywebNotificationId(id, userId);
            webNotificationUsers.IsNotified = true;
            webNotificationUsers.NotifiedDateTime = DateTime.Now;
            this.Update(webNotificationUsers.Id, webNotificationUsers);
        }

        /// <summary>
        /// The seen.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        public void Seen(Guid id, Guid userId)
        {
            var webNotificationUsers = this.GetBywebNotificationId(id, userId);
            webNotificationUsers.IsSeen = true;
            webNotificationUsers.SeenDateTime = DateTime.Now;
            this.Update(webNotificationUsers.Id, webNotificationUsers);
        }
    }
}