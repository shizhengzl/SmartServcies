using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppEntitys
{
    /// <summary>
    /// 基类包含创建时间和用户和修改
    /// </summary>
    [Description("基类包含创建时间和用户和修改")]
    public class EntityBaseAll
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
        /// 修改时间
        /// </summary>
        [Description("修改时间")]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        [Description("创建用户")]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        [Description("修改用户")]
        public Guid? ModifyUserId { get; set; }
    }
}
