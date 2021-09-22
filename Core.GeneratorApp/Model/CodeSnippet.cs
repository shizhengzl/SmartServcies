using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GeneratorApp
{
    /// <summary>
    /// 模板管理
    /// </summary>
    [Description("模板管理")]
    public class CodeSnippet : BaseCompany
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        [Description("模板名称")]
        [Column(StringLength = 50)]
        public String Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [Description("模板内容")]
        [Column(StringLength = -1)]
        public String Context { get; set; }

        /// <summary>
        /// 生成路劲
        /// </summary>
        [Description("生成路劲")]
        [Column(StringLength = 200)]
        public String VirtualPath { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")] 
        public Boolean IsDisabled { get; set; }
        /// <summary>
        /// 追加差异字段
        /// </summary>
        [Description("追加差异字段")]
        public Boolean IsAppend { get; set; } = true;
        /// <summary>
        /// 文件名称
        /// </summary>
        [Description("文件名称")]
        [Column(StringLength = 100)]
        public String Filename { get; set; }
    }
}
