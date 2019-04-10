// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebNotificationUsers.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Model
{
    #region usings

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    /// The web notification users.
    /// </summary>
    [Table("WebNotificationUsers", Schema = "common")]
    public class WebNotificationUsers
    {
        /// <summary>
        /// Gets or sets the asp net users id.
        /// </summary>
        public Guid? AspNetUsersId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is notified.
        /// </summary>
        public bool IsNotified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is seen.
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Gets or sets the notified date time.
        /// </summary>
        public DateTime? NotifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the seen date time.
        /// </summary>
        public DateTime? SeenDateTime { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the web notification.
        /// </summary>
        public WebNotification WebNotification { get; set; }

        /// <summary>
        /// Gets or sets the web notification id.
        /// </summary>
        public Guid WebNotificationId { get; set; }
    }
}