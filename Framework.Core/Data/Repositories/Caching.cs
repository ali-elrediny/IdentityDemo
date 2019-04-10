using Framework.Core.Contracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using Z.EntityFramework.Plus;
using System.Runtime.Caching;


namespace Framework.Core.Data.Repositories
{
    internal static class Caching //: ICachingService
    {
        /// <summary>
        /// The application settings service.
        /// </summary>
        /// 

        private static readonly IApplicationSettingsService applicationSettingsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Caching"/> class.
        /// </summary>
        /// <param name="applicationSettingsService">
        /// The application settings service.
        /// </param>
        //public Caching(IApplicationSettingsService applicationSettingsService)
        //{
        //    this.applicationSettingsService = applicationSettingsService;
        //}

        /// <summary>
        ///     The cache policy.
        /// </summary>
        /// 
        //this.applicationSettingsService.CacheItemPolicyDurationInHours
        public static MemoryCacheEntryOptions CachePolicy =>
            new MemoryCacheEntryOptions
            {
                SlidingExpiration =
                        TimeSpan.FromHours(10)
            };

        /// <summary>
        ///     The reports cache policy.
        /// </summary>
        public static CacheItemPolicy ReportsCachePolicy => new CacheItemPolicy { SlidingExpiration = TimeSpan.FromHours(1) };

        /// <summary>
        /// The clear cache.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public static void ClearCache(string key)
        {
            QueryCacheManager.ExpireTag(key);
        }

        /// <summary>
        ///     The keys.
        /// </summary>
        public class Keys
        {
            /// <summary>
            ///     The all cache keys.
            /// </summary>
            public const string AllCacheKeys = "AllCacheKeys";

            /// <summary>
            ///     The cancel contract reasons.
            /// </summary>
            public const string SystemSettings = "SystemSettings";

        }
    }
}
