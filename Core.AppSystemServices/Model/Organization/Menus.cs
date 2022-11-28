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

        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")] 
        [Column(StringLength = 200)]
        public String TargetSource {  get; set; }


        /// <summary>
        /// 数据源值
        /// </summary>
        [Description("数据源值")]
        [Column(StringLength = -1)]
        public string SourceValue { get; set; }



        /// <summary>
        /// 右数据源
        /// </summary>
        [Description("右数据源")]
        [Column(StringLength = 200)]
        public String RightTargetSource { get; set; }


        /// <summary>
        /// 右数据源值
        /// </summary>
        [Description("右数据源值")]
        [Column(StringLength = -1)]
        public string RightSourceValue { get; set; }



        /// <summary>
        /// 显示添加按钮
        /// </summary>
        [Description("显示添加按钮")]
        public bool ShowCreate { get; set; } = true;
        /// <summary>
        /// 显示修改按钮
        /// </summary>
        [Description("显示修改按钮")]
        public bool ShowModify { get; set; } = true;
        /// <summary>
        /// 显示删除按钮
        /// </summary>
        [Description("显示删除按钮")]

        public bool ShowRemove { get; set; } = true;

        /// <summary>
        /// 显示分页
        /// </summary>
        [Description("显示分页")]

        public bool ShowPage { get; set; } = true;

        /// <summary>
        /// 每页大小
        /// </summary>
        [Description("每页大小")]

        public Int32 PageSize { get; set; } = 10;


        /// <summary>
        /// 右显示添加按钮
        /// </summary>
        [Description("右显示添加按钮")]
        public bool RightShowCreate { get; set; }
        /// <summary>
        /// 右显示修改按钮
        /// </summary>
        [Description("右显示修改按钮")]
        public bool RightShowModify { get; set; }
        /// <summary>
        /// 右显示删除按钮
        /// </summary>
        [Description("右显示删除按钮")]

        public bool RightShowRemove { get; set; }

        /// <summary>
        /// 右显示分页
        /// </summary>
        [Description("右显示分页")]

        public bool RightShowPage { get; set; } 

        /// <summary>
        /// 右每页大小
        /// </summary>
        [Description("右每页大小")]

        public Int32 RightPageSize { get; set; } = 10;

    }
}
