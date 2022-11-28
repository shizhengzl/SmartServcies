using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.FreeSqlServices
{
    /// <summary>
    /// SQL日志
    /// </summary>
    [Description("SQL日志")]
    public class SqlLogs : BaseCompany
    {
        /// <summary>
        /// SQL
        /// </summary>
        [Column(StringLength = -1)]
        [Description("Sql")]
        public string Sql { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary> 
        [Description("执行时间")]
        public Int64 ExecuteTimeLongs { get; set; }
    }
}
