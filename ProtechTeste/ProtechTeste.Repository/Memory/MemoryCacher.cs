using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProtechTeste.Repository.Memory
{
    public class MemoryCacher
    {
        private static volatile object dataLock = new object();

        public static object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public static bool Contains(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Contains(key);
        }

        /// <summary>
        /// Add to cache without expiration policies.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Add(string key, object value)
        {
            lock (dataLock)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = MemoryCache.InfiniteAbsoluteExpiration;
                policy.SlidingExpiration = MemoryCache.NoSlidingExpiration;
                object original = memoryCache.AddOrGetExisting(key, value, policy);
                if (original != null)
                {
                    Remove(key);
                    return memoryCache.Add(key, value, policy);
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Add to cache with fixed expiration DateTime.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static bool Add(string key, object value, DateTimeOffset absoluteExpiration)
        {
            lock (dataLock)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                return memoryCache.Add(key, value, absoluteExpiration);
            }
        }

        /// <summary>
        /// Add to cache with TimeSpan that indicates if the data should be disposed if it has not been accessed in a given span of time.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public static bool Add(string key, object value, TimeSpan slidingExpiration)
        {
            lock (dataLock)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.SlidingExpiration = slidingExpiration;
                object original = memoryCache.AddOrGetExisting(key, value, policy);
                if (original != null)
                {
                    Remove(key);
                    return memoryCache.Add(key, value, policy);
                }
                else
                {
                    return true;
                }
            }
        }

        public static void Remove(string key)
        {
            lock (dataLock)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                if (memoryCache.Contains(key))
                {
                    memoryCache.Remove(key);
                }
            }
        }
    }
}
