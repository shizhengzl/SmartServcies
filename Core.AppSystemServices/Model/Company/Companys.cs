using Core.UsuallyCommon;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 单位表
    /// </summary>
    [Description("单位表")]
    public class Companys : BaseCompany
    {
        /// <summary>
        /// 租户名称
        /// </summary>
        [Description("单位名称")]
        [Column(StringLength = 50)]
        public String CompanyName { get; set; }

        /// <summary>
        /// 授权模式
        /// </summary>
        [Description("授权模式")]
        public GrantMode GrantMode { get; set; }
    }
}
