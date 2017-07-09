using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManageLib
{
    /// <summary>
    /// 进仓单回执信息（对应清关系统）
    /// </summary>
    public class InStoreReceipt
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int IdentityID { get; set; }
        /// <summary>
        /// 回执状态
        /// </summary>
        public int ReceiptStatus { get; set; }
        /// <summary>
        /// 回执时间
        /// </summary>
        public DateTime ReceiptTime { get; set; }
        /// <summary>
        /// 回执信息
        /// </summary>
        public string ReceiptMessage { get; set; }
    }
}
