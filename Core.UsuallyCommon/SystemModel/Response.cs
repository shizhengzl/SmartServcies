using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 输出
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; } = string.Empty;


        /// <summary>
        /// 总数
        /// </summary>
        public Int64 Total { get; set; } = 0;

        /// <summary>
        /// 成功编码
        /// </summary>
        public CodeDescription Code { get; set; } = CodeDescription.Success;


        /// <summary>
        /// 其他对象
        /// </summary>
        public object Other { get; set; }

        /// <summary>
        /// 表单验证规则
        /// </summary>
        public object Rules { get; set; }
    }
}
