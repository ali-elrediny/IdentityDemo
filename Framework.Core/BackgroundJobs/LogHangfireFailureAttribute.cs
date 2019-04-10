// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogHangfireFailureAttribute.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.BackgroundJobs
{
    #region usings

    using Hangfire.Common;
    using Hangfire.States;
    using Hangfire.Storage;

    using Microsoft.Extensions.Logging;

    #endregion

    /// <summary>
    ///     The log hangfire failure attribute.
    /// </summary>
    public class LogHangfireFailureAttribute : JobFilterAttribute, IApplyStateFilter
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        private ILogger Logger { get; } = ApplicationLogging.CreateLogger<LogHangfireFailureAttribute>();

        /// <summary>
        /// The on state applied.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            if (context.NewState is FailedState failedState)
            {
                this.Logger.LogError(
                    message: $"Background job #{context.BackgroundJob.Id} was failed with an exception.",
                    exception: failedState.Exception);
            }
        }

        /// <summary>
        /// The on state un applied.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
        }
    }
}