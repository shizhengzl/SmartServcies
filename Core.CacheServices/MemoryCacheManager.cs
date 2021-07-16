using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CacheServices
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public class MemoryCacheManager
    {
        public static MemoryCacheOptions cacheOps = new MemoryCacheOptions()
        {
            //缓存最大为100份
            //##注意netcore中的缓存是没有单位的，缓存项和缓存的相对关系
            //SizeLimit = 10000000,
            //缓存满了时，压缩20%（即删除20份优先级低的缓存项）
            CompactionPercentage = 0.2,
            //三秒钟查找一次过期项
            ExpirationScanFrequency = TimeSpan.FromSeconds(3)
        };
        public static MemoryCache myCache = new MemoryCache(cacheOps);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        public static void Remove(string key)
        {
            myCache.Remove(key);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="timespan"></param>
        public static void SetCache<T>(String Key, T Value, TimeSpan? timespan)
        {
            if (timespan.HasValue)
                myCache.Set<T>(Key, Value, timespan.Value);
            else
                myCache.Set<T>(Key, Value);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="Key">缓存key</param>
        /// <param name="Value">缓存值</param>
        /// <param name="timespan">缓存时间</param>
        public static void SetRefushCache<T>(String Key, T Value, TimeSpan? timespan)
        {
            myCache.Set<T>(Key, Value, new MemoryCacheEntryOptions
            {
                SlidingExpiration = timespan,
            });
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="Key">缓存key</param>
        /// <param name="Value">缓存值</param>
        public static void SetCache(String Key, String Value)
        {
            myCache.Set(Key, Value);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="Key">缓存key</param>
        /// <returns></returns>
        public static T GetCache<T>(String Key)
        {
            return myCache.Get<T>(Key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="Key">缓存key</param>
        /// <returns></returns>
        public static object GetCache(String Key)
        {
            return myCache.Get(Key);
        }
    }
}
