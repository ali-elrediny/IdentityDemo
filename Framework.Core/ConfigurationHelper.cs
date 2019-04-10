// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationHelper.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core
{
    #region usings

    using Microsoft.Extensions.Configuration;

    #endregion

    /// <summary>
    /// The configuration helper.
    /// </summary>
    public class ConfigurationHelper
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public static IConfiguration Configuration { get; set; }
    }
}