using System;
using System.Collections.Generic;
using Memcached.Client;
using System.Configuration;

namespace CacheManageLib
{
    /// <summary>
    /// Memcache帮助类库
    /// </summary>
    public class MemcacheHelper
    {
        #region 全局静态对象  
        // 全局Socket连接池对象  
        private static SockIOPool sockIOPool;
        public static SockIOPool CurrentPool
        {
            get
            {
                return sockIOPool;
            }
        }
        // 全局Memcached客户端对象  
        private static MemcachedClient mc;
        #endregion
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static bool MemcacheHelperInit()
        {
            try
            {
                // 初始化Memcached服务器列表  
                string[] serverList = ConfigurationManager.AppSettings["Memcached.ServerList"].Split(',');
                // 初始化Socket连接池  
                sockIOPool = SockIOPool.GetInstance("MemPool");
                sockIOPool.SetServers(serverList);
                sockIOPool.Initialize();
                // 初始化Memcached客户端  
                mc = new MemcachedClient();
                mc.PoolName = "MemPool";
                mc.EnableCompression = false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>  
        /// 判断pkey关键字是否在Pmc中  
        /// </summary>  
        /// <param name="pMC"></param>  
        /// <param name="pKey"></param>  
        /// <returns></returns>  
        public static bool IsCache(string pKey)
        {
            if (MemcacheHelperInit())
            {
                if (mc.KeyExists(pKey))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// 删掉Memcache 数据  
        /// </summary>  
        /// <param name="key"> </param>  
        /// <returns></returns>  
        public static bool RemoveCache(string pKey)
        {
            if (MemcacheHelperInit())
            {
                if (!mc.KeyExists(pKey))
                {
                    return false;
                }
                else
                {
                    return mc.Delete(pKey);
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// Set-新增或修改  
        /// </summary>  
        /// <param name="key">键</param>  
        /// <param name="value">值</param>  
        /// <returns>是否成功</returns>  
        public static bool AddCache(string key, object value)
        {
            if (MemcacheHelperInit())
            {
                if (!mc.KeyExists(key))
                {
                    return mc.Add(key, value);
                }
                else
                {
                    return mc.Set(key, value);
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// Set-新增或修改  
        /// </summary>  
        /// <param name="key">键</param>  
        /// <param name="value">值</param>  
        /// <param name="expiry">过期时间</param>  
        /// <returns>是否成功</returns>  
        public static bool AddCache(string key, object value, DateTime expiry)
        {
            if (MemcacheHelperInit())
            {
                if (!mc.KeyExists(key))
                {
                    return mc.Add(key, value, expiry);
                }
                else
                {
                    return mc.Set(key, value, expiry);
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// 根据单个key值获取Memcache 数据  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static object GetCache(string key)
        {
            if (MemcacheHelperInit())
            {
                if (!mc.KeyExists(key))
                {
                    return null;
                }
                else
                {
                    return mc.Get(key);
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>  
        /// 根据多个key值获取Memcache 数据  
        /// </summary>  
        /// <param name="key"> </param>  
        /// <returns></returns>  
        public static Dictionary<string, object> GetCache(string[] keys)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (MemcacheHelperInit())
            {
                foreach (string key in keys)
                {
                    object obj = mc.Get(key);
                    if (!dic.ContainsKey(key) && obj != null)
                        dic.Add(key, obj);
                }
                return dic;
            }
            else
            {
                return null;
            }
        }
    }
    }
