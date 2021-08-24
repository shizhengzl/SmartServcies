using Core.UsuallyCommon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Description("菜单表")]
    public class Menus : EntityBaseAll
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Description("菜单名称")]
        public string Name { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Description("菜单图标")]
        public string IconUrl { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Description("表名")]
        public string Url { get; set; }

        /// <summary>
        /// 父菜单
        /// </summary>
        [Description("父菜单")]
        public Guid MenusId { get; set; } = Guid.Empty;
    }
}
