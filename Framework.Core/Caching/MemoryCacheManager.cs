// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryCacheManager.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Caching
{
    #region usings

    using System;

    using Framework.Core.Extensions;

    using Microsoft.Extensions.Caching.Memory;

    #endregion

    /// <summary>
    ///     The memory cache manager.
    /// </summary>
    public class MemoryCacheManager : ICache
    {
        /// <summary>
        ///     The cache.
        /// </summary>
        private readonly IMemoryCache Cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheManager"/> class.
        /// </summary>
        /// <param name="Cache">
        /// The cache.
        /// </param>
        public MemoryCacheManager(IMemoryCache Cache)
        {
            this.Cache = Cache;
        }

        /// <summary>
        ///     The flush.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Flush()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Get<T>(string key)
        {
            return this.Cache.Get(key).To<T>();
        }

        /// <summary>
        /// The get and remove.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T GetAndRemove<T>(string key)
        {
            var val = this.Cache.Get(key);
            this.Cache.Remove(key);
            return (T)val;
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void Remove(string key)
        {
            this.Cache.Remove(key);
        }

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void Set<T>(string key, T value)
        {
            this.Cache.Set(key, value);
        }

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void Set<T>(string key, T value, TimeSpan timeout)
        {
            this.Cache.Set(key, value, timeout);
        }
    }
}