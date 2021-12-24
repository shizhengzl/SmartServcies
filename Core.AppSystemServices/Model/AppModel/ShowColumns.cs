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
        /// 菜单
        /// </summary>
        [Description("菜单")] 
        public Guid? MenusId { get; set; }


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


        /// <summary>
        /// 数据来源
        /// </summary>
        [Description("数据来源")]
        [Column(StringLength = 50)]
        public String TargetSource { get; set; }

        /// <summary>
        /// 数据源值
        /// </summary>
        [Description("数据源值")]
        [Column(StringLength = 50)]
        public String SourceValue { get; set; }


        /// <summary>
        /// 绑定键
        /// </summary>
        [Description("绑定键")]
        [Column(StringLength = 200)]
        public String BindKey { get; set; }

        /// <summary>
        /// 绑定值
        /// </summary>
        [Description("绑定值")]
        [Column(StringLength = 200)]
        public String BindValue { get; set; }

        /// <summary>
        /// 必填
        /// </summary>
        [Description("必填")]
        public bool IsRequired { get; set; }


        /// <summary>
        /// 只读
        /// </summary>
        [Description("只读")]
        public bool IsReadyOnly { get; set; }


        /// <summary>
        /// 编辑显示
        /// </summary>
        [Description("编辑显示")]
        public bool IsEditShow { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        [Description("最大长度")]
        public Int32 MaxLength { get; set; }


        /// <summary>
        /// 验证方式
        /// </summary>
        [Description("验证方式")]
        [Column(StringLength = 50)]
        public String ValidType { get; set; }

        /// <summary>
        /// 模糊查询
        /// </summary>
        [Description("模糊查询")] 
        public Boolean IsLike { get; set; }

        /// <summary>
        /// 格式化和编辑
        /// </summary>
        [Description("格式化和编辑")]
        [Column(StringLength = -1)]
        public string Json { get; set; }

    }
}
