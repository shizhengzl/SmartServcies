using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 列表显示列
    /// </summary>
    [Description("列表显示列")]
    public class ShowColumns : BaseCompany
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        [Description("数据库名称")]
        [Column(StringLength = 50)]
        public String DataBaseName { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        [Description("表名称")]
        [Column(StringLength = 50)]
        public String TableName { get; set; }

        /// <summary>
        /// 绑定名称
        /// </summary>
        [Description("绑定名称")]
        [Column(StringLength = 50)]
        public String ColumnName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [Description("显示名称")]
        [Column(StringLength = 50)]
        public String ColumnDescription { get; set; }

        /// <summary>
        /// 显示宽度
        /// </summary>
        [Description("显示宽度")]
        [Column(StringLength = 50)]
        public String ColumnWidth { get; set; }

        /// <summary>
        /// 显示位置
        /// </summary>
        [Description("显示位置")] 
        public String Postion { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [Description("是否显示")] 
        public bool IsShow { get; set; } 

        /// <summary>
        /// 排序
        /// </summary>
        [Description("排序")]
        public Int32 Sort { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Description("类型")]
        public string CsharpType { get; set; }

    }
}
