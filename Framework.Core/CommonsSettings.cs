﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonsSettings.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core
{
    #region usings

    using Microsoft.Extensions.Configuration;

    #endregion

    /// <summary>
    ///     The commons settings.
    /// </summary>
    public static class CommonsSettings
    {
        /// <summary>
        /// The application root url.
        /// </summary>
        public static string ApplicationRootUrl =>
            ConfigurationHelper.Configuration.GetValue<string>("Commons:ApplicationRootUrl") ?? string.Empty;

        public static string ApplicationId =>
            ConfigurationHelper.Configuration.GetValue<string>("Commons:ApplicationId") ?? string.Empty;

        // 0 public static string ApplicationName { get; internal set; } = "MyApplicationName";

        /// <summary>
        ///     Gets the connection string name.
        /// </summary>
        public static string ConnectionStringName =>
            ConfigurationHelper.Configuration.GetValue<string>("Commons:DbConnectionStringName") ?? "CommonsDbEntities";

        /// <summary>
        ///     Gets the connection string value.
        /// </summary>
        public static string ConnectionStringValue =>
            ConfigurationHelper.Configuration.GetConnectionString(ConnectionStringName);

        /// <summary>
        ///     Gets the default culture.
        /// </summary>
        public static string DefaultCulture { get; internal set; } = "ar-SA";

        /// <summary>
        ///     Gets or sets the widgets static content version.
        /// </summary>
        public static uint WidgetsStaticContentVersion { get; set; } = 1;
    }
}