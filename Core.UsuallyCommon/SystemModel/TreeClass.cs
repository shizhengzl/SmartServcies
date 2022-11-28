using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    public class TreeClass
    {
        ///
        /// 数字标识
        /// </summary>
        public string Id { get; set; } 
        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// 枚举描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeClass> children { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public string Props { get; set; }

        /// <summary>
        /// 存在描述
        /// </summary> 
        public Boolean HasDescription { get; set; }
    }
}
