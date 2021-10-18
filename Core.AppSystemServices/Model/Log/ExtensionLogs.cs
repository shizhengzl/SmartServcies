using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace Core.AppSystemServices
{

    /// <summary>
    /// 异常日志
    /// </summary>
    [Description("异常日志")]
    public class ExceptionLogs : EntityBase
    {
        /// <summary>
        /// 堆栈信息
        /// </summary>
        [Column(StringLength = -1)]
        [Description("堆栈信息")]
        public string StackTrace { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        [Column(StringLength = -1)]
        [Description("错误消息")]
        public string Message { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        [Column(StringLength = -1)]
        [Description("错误描述")]
        public string Description { get; set; }
        /// <summary>
        /// 错误方法
        /// </summary>
        [Column(StringLength = -1)]
        [Description("错误方法")]
        public string Method { get; set; }
    }
}
