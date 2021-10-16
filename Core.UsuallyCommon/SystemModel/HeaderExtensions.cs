using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    public class HeaderExtensions
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string ColumnDescription { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public Int32 Width { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        public bool IsShow { get; set; }
    }
}
