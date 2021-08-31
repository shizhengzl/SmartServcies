using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 组织机构表
    /// </summary>
    [Description("组织机构表")]
    public class Organizations : EntityBaseAll
    {
        /// <summary>
        /// 组织机构名称
        /// </summary>
        [Description("组织机构名称")]
        [Column(StringLength = 50)]
        public string Name { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public Guid CompanysId { get; set; }
    }
}
