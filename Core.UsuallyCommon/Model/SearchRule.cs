using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 查询规则
    /// </summary>
    public class SearchRule
    {
        /// <summary>
        /// 查询key
        /// </summary>
        public String SearchKey { get; set; }

        /// <summary>
        /// 查询次数
        /// </summary>
        public Int64 SearchCount { get; set; }
    }
}
