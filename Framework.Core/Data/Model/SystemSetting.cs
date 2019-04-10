// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemSetting.cs" company="Usama Nada">
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
    /// The system setting.
    /// </summary>
    [Table("SystemSettings", Schema = "common")]
    public class SystemSetting
    {
        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is sticky.
        /// </summary>
        public bool IsSticky { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether secure.
        /// </summary>
        public bool Secure { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public string ValueType { get; set; }
    }
}