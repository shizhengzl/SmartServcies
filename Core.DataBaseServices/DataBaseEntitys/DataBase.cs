using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.DataBaseServices
{
    /// <summary>
    /// 数据库
    /// </summary>
    [Description("数据库")]
    public class DataBase : ConnectionString
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        [Description("服务器地址")]
        public string DataBaseName { get; set; }
    }
}
