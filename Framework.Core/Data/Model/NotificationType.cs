// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationType.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data.Model
{
    #region usings

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    /// <summary>
    ///     The notification type.
    /// </summary>
    [Table("NotificationType", Schema = "common")]
    public sealed class NotificationType
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NotificationType" /> class.
        /// </summary>
        public NotificationType()
        {
            this.NotificationTemplates = new HashSet<NotificationTemplate>();
        }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        [Column(Order = 0)]
        public byte Id { get; set; }

        /// <summary>
        ///     Gets or sets the name ar.
        /// </summary>
        [Required]
        [StringLength(256)]
        [Column(Order = 1)]
        public string NameAr { get; set; }

        /// <summary>
        ///     Gets or sets the name en.
        /// </summary>
        [Column(Order = 2)]
        [StringLength(256)]
        public string NameEn { get; set; }

        /// <summary>
        ///     Gets or sets the notification templates.
        /// </summary>
        public ICollection<NotificationTemplate> NotificationTemplates { get; set; }
    }
}