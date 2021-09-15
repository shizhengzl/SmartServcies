using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.SnippetServices
{
    /// <summary>
    /// 代码片段记录表
    /// </summary>
    [Description("代码片段记录表")]
    public class SnippetRecord : BaseCompany
    {
        /// <summary>
        /// 语言
        /// </summary>
        [Description("语言")]
        public LanguageType LanguageType { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Description("标题")]
        [Column(StringLength = 500)]
        public string Title { get; set; }
        /// <summary>
        /// 快捷键
        /// </summary>
        [Description("快捷键")]
        [Column(StringLength = 500)]
        public string Shortcut { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Description("作者")]
        [Column(StringLength = 100)]
        public string Author { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [Description("代码")]
        [Column(StringLength = -1)]
        public string Code { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        [Column(StringLength = -1)]
        public String Description { get; set; }
    }
}
