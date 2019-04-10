// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUseHub.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications.Hubs
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    /// The UseHub interface.
    /// </summary>
    public interface IUseHub
    {
        /// <summary>
        /// The send message to group.
        /// </summary>
        /// <param name="groupName">
        /// The group name.
        /// </param>
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
        Task SendMessageToGroup(
            string groupName,
            List<Guid> usersIds,
            string messageAr,
            string messageEn,
            string redirectUrl);

        /// <summary>
        /// The send message to groups.
        /// </summary>
        /// <param name="groups">
        /// The groups.
        /// </param>
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
        Task SendMessageToGroups(
            List<string> groups,
            List<Guid> usersIds,
            string messageAr,
            string messageEn,
            string redirectUrl);

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
        Task SendMessageToUser(string userId, string messageAr, string messageEn, string redirectUrl);

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
        Task SendMessageToUsers(List<string> usersIds, string messageAr, string messageEn, string redirectUrl);
    }
}