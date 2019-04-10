// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UseHub.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications.Hubs
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Framework.Core.Data;
    using Framework.Core.Globalization;

    using Microsoft.AspNetCore.SignalR;

    #endregion

    /// <summary>
    /// The use hub.
    /// </summary>
    public class UseHub : IUseHub
    {
        /// <summary>
        /// The _web notification hub.
        /// </summary>
        private readonly IHubContext<WebNotificationHub> webNotificationHub;

        /// <summary>
        /// The common uow.
        /// </summary>
        private readonly CommonsUnitOfWork commonUow;

        /// <summary>
        /// Initializes a new instance of the <see cref="UseHub"/> class.
        /// </summary>
        /// <param name="webNotificationHub">
        /// The web notification hub.
        /// </param>
        /// <param name="commonUow">
        /// The common uow.
        /// </param>
        public UseHub(IHubContext<WebNotificationHub> webNotificationHub, CommonsUnitOfWork commonUow)
        {
            this.webNotificationHub = webNotificationHub;
            this.commonUow = commonUow;
        }

        /// <summary>
        /// </summary>
        /// <param name="groupName">
        /// AspNetRole Name
        /// </param>
        /// <param name="usersIds">
        /// Extra Users Will Be Notified
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SendMessageToGroup(
            string groupName,
            List<Guid> usersIds,
            string messageAr,
            string messageEn,
            string redirectUrl)
        {
            var webNotificationId = this.AddToUsers(usersIds, messageAr, messageEn, redirectUrl);
            return this.webNotificationHub.Clients.Group(groupName).SendAsync(
                "PushNotification",
                webNotificationId,
                CultureHelper.IsArabic ? messageAr : messageEn,
                redirectUrl);
        }

        /// <summary>
        /// </summary>
        /// <param name="groups">
        /// AspNetRole Name
        /// </param>
        /// <param name="usersIds">
        /// Extra Users Will Be Notified
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SendMessageToGroups(
            List<string> groups,
            List<Guid> usersIds,
            string messageAr,
            string messageEn,
            string redirectUrl)
        {
            var webNotificationId = this.AddToUsers(usersIds, messageAr, messageEn, redirectUrl);
            return this.webNotificationHub.Clients.Groups(groups).SendAsync(
                "PushNotification",
                webNotificationId,
                CultureHelper.IsArabic ? messageAr : messageEn,
                redirectUrl);
        }

        /// <summary>
        /// The send message to user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SendMessageToUser(string userId, string messageAr, string messageEn, string redirectUrl)
        {
            var webNotificationId = this.AddToUser(userId, messageAr, messageEn, redirectUrl);

            return this.webNotificationHub.Clients.User(userId).SendAsync(
                "PushNotification",
                webNotificationId,
                CultureHelper.IsArabic ? messageAr : messageEn,
                redirectUrl);
        }

        /// <summary>
        /// The send message to users.
        /// </summary>
        /// <param name="usersIds">
        /// The users ids.
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SendMessageToUsers(List<string> usersIds, string messageAr, string messageEn, string redirectUrl)
        {
            var webNotificationId = this.AddToUsers(usersIds, messageAr, messageEn, redirectUrl);
            return this.webNotificationHub.Clients.Users(usersIds).SendAsync(
                "PushNotification",
                webNotificationId,
                CultureHelper.IsArabic ? messageAr : messageEn,
                redirectUrl);
        }

        /// <summary>
        /// The add to user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string AddToUser(string userId, string messageAr, string messageEn, string url = null)
        {
            var webNotification = new Data.Model.WebNotification
                                      {
                                          Id = Guid.NewGuid(),
                                          MessageContentAr = messageAr,
                                          MessageContentEn = messageEn,
                                          Url = url
                                      };
            this.commonUow.WebNotifications.Add(webNotification);
            var webNotificationUsers = new Data.Model.WebNotificationUsers
                                           {
                                               Id = Guid.NewGuid(),
                                               AspNetUsersId = Guid.Parse(userId),
                                               IsNotified = false,
                                               IsSeen = false,
                                               WebNotificationId = webNotification.Id
                                           };
            this.commonUow.WebNotificationUsers.Add(webNotificationUsers);
            this.commonUow.Save();
            return webNotification.Id.ToString();
        }

        /// <summary>
        /// The add to users.
        /// </summary>
        /// <param name="usersIds">
        /// The users ids.
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string AddToUsers(List<Guid> usersIds, string messageAr, string messageEn, string redirectUrl)
        {
            var webNotification = new Data.Model.WebNotification
                                      {
                                          Id = Guid.NewGuid(),
                                          MessageContentAr = messageAr,
                                          MessageContentEn = messageEn,
                                          Url = redirectUrl
                                      };
            this.commonUow.WebNotifications.Add(webNotification);

            foreach (var userId in usersIds)
            {
                var webNotificationUsers = new Data.Model.WebNotificationUsers
                                               {
                                                   Id = Guid.NewGuid(),
                                                   AspNetUsersId = userId,
                                                   IsNotified = false,
                                                   IsSeen = false,
                                                   WebNotificationId = webNotification.Id
                                               };
                this.commonUow.WebNotificationUsers.Add(webNotificationUsers);
            }

            this.commonUow.Save();
            return webNotification.Id.ToString();
        }

        /// <summary>
        /// The add to users.
        /// </summary>
        /// <param name="usersIds">
        /// The users ids.
        /// </param>
        /// <param name="messageAr">
        /// The message Ar.
        /// </param>
        /// <param name="messageEn">
        /// The message En.
        /// </param>
        /// <param name="redirectUrl">
        /// The redirect Url.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string AddToUsers(List<string> usersIds, string messageAr, string messageEn, string redirectUrl)
        {
            var webNotification = new Data.Model.WebNotification
                                      {
                                          Id = Guid.NewGuid(),
                                          MessageContentAr = messageAr,
                                          MessageContentEn = messageEn,
                                          Url = redirectUrl
                                      };
            this.commonUow.WebNotifications.Add(webNotification);
            foreach (var userId in usersIds)
            {
                var webNotificationUsers = new Data.Model.WebNotificationUsers
                                               {
                                                   Id = Guid.NewGuid(),
                                                   AspNetUsersId = Guid.Parse(userId),
                                                   IsNotified = false,
                                                   IsSeen = false,
                                                   WebNotificationId = webNotification.Id
                                               };
                this.commonUow.WebNotificationUsers.Add(webNotificationUsers);
            }

            this.commonUow.Save();
            return webNotification.Id.ToString();
        }
    }
}