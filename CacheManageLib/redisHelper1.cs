using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManageLib
{
   public class redisHelper1
    {
        private static string connstr = System.Configuration.ConfigurationManager.AppSettings["RedisConnectStr"];// "127.0.0.1:6379,allowadmin=true";
        static RedisClient client = new RedisClient("127.0.0.1", 6379);
        static IRedisTypedClient<InStoreReceipt> redis = client.As<InStoreReceipt>();
        /// <summary>
        /// 根据key获取缓存的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetValue<T>(string key)
        {
            return client.Get<object>(key);
        }
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SetCache<T>(string key, object obj)
        {
            return client.Set(key, obj);
        }
        /// <summary>
        /// 根据单个key删除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool DelCache(string key)
        {
            return client.Remove(key);
        }
    }
}
