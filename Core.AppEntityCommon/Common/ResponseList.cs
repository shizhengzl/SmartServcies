using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppEntitys
{
    public class ResponseList<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; }

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
        public Int64 Total { get; set; }

        /// <summary>
        /// 成功编码
        /// </summary>
        public CodeDescription Code { get; set; } =  CodeDescription.Success;
    }
}
