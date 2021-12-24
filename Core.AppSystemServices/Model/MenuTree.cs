using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 菜单树
    /// </summary>
    public class MenuTree
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 路劲
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 组件
        /// </summary>
        public string component { get; set; }
        /// <summary>
        /// 重定向
        /// </summary>
        public string redirect { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public MenuMeta meta { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<MenuTree> children { get; set; }


        public string targetsource { get; set; }
        public string sourcevalue { get; set; }

        public string righttargetsource { get; set; }
        public string rightsourcevalue { get; set; }
    }
}
