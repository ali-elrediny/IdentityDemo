// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotificationHub.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Notifications.Hubs
{
    #region usings

    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    #endregion

    /// <summary>
    /// The web notification hub.
    /// </summary>
    [Authorize]
    public class WebNotificationHub : Hub
    {
        /// <summary>
        /// The on connected async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override async Task OnConnectedAsync()
        {
            var groupName = this.GetCurrentUserRoleName(out var userId);

            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName).ConfigureAwait(false);
            await base.OnConnectedAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// The on disconnected async.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var groupName = this.GetCurrentUserRoleName(out var userId);

            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName).ConfigureAwait(false);
            await base.OnDisconnectedAsync(exception).ConfigureAwait(false);
        }

        /// <summary>
        /// The send message to caller.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="webNotificationId">
        /// The web notification id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SendMessageToCaller(string message, Guid webNotificationId, string redirectUrl)
        {
            return this.Clients.Caller.SendAsync("PushNotification", webNotificationId, message, redirectUrl);
        }

        // public async Task SendMessage(string message)
        // {
        // await Clients.All.SendAsync("PushNotification", "5ef96a68-cb58-4fc9-b31f-b91b49795ce8", message);
        // }
        /// <summary>
        /// The get current user role name.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCurrentUserRoleName(out string userId)
        {
            var user = this.Context.User.Identity as ClaimsIdentity;
            userId = user.Claims.First().Value;
            return user.Claims.Last().Value;
        }
    }
}