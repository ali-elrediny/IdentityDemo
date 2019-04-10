// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubUsers.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications.Hubs
{
    #region usings

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The hub users.
    /// </summary>
    public static class HubUsers
    {
        /// <summary>
        /// The users.
        /// </summary>
        private static readonly Dictionary<string, string> users = new Dictionary<string, string>();

        /// <summary>
        /// The add user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="clientConnectionId">
        /// The client connection id.
        /// </param>
        public static void AddUser(string userId, string clientConnectionId)
        {
            users.Add(userId, clientConnectionId);
        }

        /// <summary>
        /// The get user connection id.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetUserConnectionId(string userId)
        {
            return users[userId];
        }

        /// <summary>
        /// The remove user.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        public static void RemoveUser(string userId)
        {
            users.Remove(userId);
        }
    }
}