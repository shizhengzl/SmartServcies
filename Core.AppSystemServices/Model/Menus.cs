using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
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
        [Column(StringLength = 200)]
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Description("菜单图标")]
        [Column(StringLength = 200)]
        public string MenuIcon { get; set; }


        /// <summary>
        /// 路劲
        /// </summary>
        [Description("路劲")]
        [Column(StringLength = 200)]
        public string Path { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        [Description("组件")]
        [Column(StringLength = 200)]
        public string Component { get; set; }

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

     
    }
}
