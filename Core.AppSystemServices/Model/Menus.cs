using Core.UsuallyCommon;
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
    public class Menus : BaseCompany
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
        /// 排序
        /// </summary>
        [Description("排序")]
        public Int32 Sort { get; set; }

        /// <summary>
        /// 父菜单
        /// </summary>
        [Description("父菜单")]
        public Guid MenusId { get; set; } = Guid.Empty;

        /// <summary>
        /// 默认菜单
        /// </summary>
        [Description("默认菜单")]
        public Boolean IsDefault { get; set; }

        /// <summary>
        /// 超级管理员菜单
        /// </summary>
        [Description("超级管理员菜单")]
        public Boolean IsSupper { get; set; }

        /// <summary>
        /// 自动生成
        /// </summary>
        [Description("自动生成")]
        public Boolean IsAuto { get; set; } = true;
    }
}
