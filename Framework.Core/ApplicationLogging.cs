// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationLogging.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core
{
    #region usings

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using NLog.Extensions.Logging;
    using NLog.Web;

    #endregion

    /// <summary>
    /// The application logging.
    /// Logger Uses Factory Pattern to get on demand instance freely without the need of constructor injection
    /// based on ideas from https://stackify.com/net-core-loggerfactory-use-correctly/
    /// </summary>
    public class ApplicationLogging
    {
        /// <summary>
        /// The logger factory.
        /// </summary>
        private static ILoggerFactory loggerFactory;

        /// <summary>
        /// The configure nlog logger.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="conf">
        /// The conf.
        /// </param>
        public static void ConfigureNlogLogger(ILoggerFactory factory, IHostingEnvironment env, IConfiguration conf)
        {
            env.ConfigureNLog("nlog.config");
            factory.AddNLog();
            factory.AddConsole(conf.GetSection("Logging"));
            loggerFactory = factory;
        }

        /// <summary>
        /// The create logger.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="ILogger"/>.
        /// </returns>
        public static ILogger CreateLogger<T>()
        {
            return loggerFactory.CreateLogger<T>();
        }
    }
}