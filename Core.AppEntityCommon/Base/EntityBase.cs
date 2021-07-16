using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppEntitys
{
    /// <summary>
    /// 数据库实体基类
    /// </summary>
    [Description("数据库实体基类")]
    public class EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")] 
        public Guid Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [Description("创建用户")]
        public Int64 CreateUserId { get; set; }
    }
}
