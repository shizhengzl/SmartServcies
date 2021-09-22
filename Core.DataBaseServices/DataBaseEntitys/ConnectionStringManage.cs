using Core.UsuallyCommon;
using FreeSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.DataBaseServices
{
    /// <summary>
    /// 连接字符串管理
    /// </summary>
    public class ConnectionStringManage:BaseCompany
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        [Description("数据库类型")]
        public DataType DataBaseType { get; set; }

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

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public String GetConnectionString() {
            string response = string.Empty;
            var database = string.Format("database={0};", DefaultDataBase);
            if (IsWindows && DataBaseType == DataType.SqlServer) {
            
                response = string.Format("server={0};{1}Integrated Security=True;" ,Address,DefaultDataBase.IsNullOrEmpty() ? string.Empty: database);
            }
            if (!IsWindows && DataBaseType == DataType.SqlServer)
            {
                response = string.Format("server={0};{1}uid={2},pwd={3};", Address,   DefaultDataBase.IsNullOrEmpty() ? string.Empty : database,UserIds,Password);
            }
            if (IsWindows && DataBaseType == DataType.MySql)
            {

            }
            if (!IsWindows && DataBaseType == DataType.MySql) { 
            
            }
            return response;
        }
    }
}
