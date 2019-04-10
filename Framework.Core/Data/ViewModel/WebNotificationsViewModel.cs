// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotificationsViewModel.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.ViewModel
{
    #region usings

    using System;

    #endregion

    /// <summary>
    /// The web notifications view model.
    /// </summary>
    public class WebNotificationsViewModel
    {
        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedOn { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether is notified.
        /// </summary>
        public bool IsNotified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is seen.
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the notified date time.
        /// </summary>
        public DateTime? NotifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the seen date time.
        /// </summary>
        public DateTime? SeenDateTime { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the web notification id.
        /// </summary>
        public Guid WebNotificationId { get; set; } = Guid.Empty;
    }
}