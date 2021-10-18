using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 记录日志
    /// </summary>
    [Description("记录日志")]
    public class InfoLogs : EntityBase
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        [Column(StringLength = -1)]
        [Description("错误消息")]
        public string Message { get; set; }
    }
}
