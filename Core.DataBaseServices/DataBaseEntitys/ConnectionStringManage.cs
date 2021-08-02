using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.DataBaseServices.DataBaseEntitys
{
    /// <summary>
    /// 连接字符串管理
    /// </summary>
    public class ConnectionStringManage
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        [Description("数据库类型")]
        public DataBaseType DataBaseType { get; set; }

        /// <summary>
        /// windows认证
        /// </summary>
        [Description("windows认证")]
        public Boolean  IsWindows { get; set; } = false;

        /// <summary>
        /// 服务器地址
        /// </summary>
        [Description("服务器地址")]
        public string Address { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        public string UserIds { get; set;  }

        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        public string Password { get; set; }

        /// <summary>
        /// 默认数据库
        /// </summary>
        [Description("默认数据库")]
        public string DefaultDataBase { get; set; }
    }
}
