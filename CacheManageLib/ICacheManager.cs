using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CacheManageLib
{
    public interface ICacheManager<T>
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        T GetCache(string CacheKey);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        void SetCache(string CacheKey, T objObject);
        /// <summary>
        /// 设置缓存包含缓存时间
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="Timeout"></param>
        void SetCache(string CacheKey, T objObject,TimeSpan Timeout);
        /// <summary>
        /// <para>新增缓存</para>
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">object</param>
        /// <seealso cref="Add(string, T, DateTime)"/>
        /// <seealso cref="Add(string, T, DateTime, CacheEntryUpdateCallback)"/>
        void Add(string key, T obj);

        /// <summary>
        /// <para>新增缓存设置过期时间</para>
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">object</param>
        /// <param name="expire">expiration time</param>
        /// <seealso cref="Add(string, T)"/>
        /// <seealso cref="Add(string, T, DateTime, CacheEntryUpdateCallback)"/>
        void Add(string key, T obj, DateTime expire);

        /// <summary>
        /// <para>Method add object to cache</para>
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">object</param>
        /// <param name="expire">expiration time</param>
        /// <param name="callback">method that will call befor object will deleted from cache</param>
        /// <seealso cref="Add(string, T)"/>
        /// <seealso cref="Add(string, T, DateTime)"/>
        void Add(string key, T obj, DateTime expire, CacheEntryUpdateCallback callback);

        /// <summary>
        /// <para>Method try to get strongly typed object from cache by key</para>
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">obj</param>
        /// <return>true if object exist in cache else fasle</return>
        bool TryGetValue(string key, out T obj);
    }
}
