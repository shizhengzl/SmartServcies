using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppRepositorys
{
    /// <summary>
    /// 单位租户表
    /// </summary>
    [Description("单位租户表")]
    public class Companys : EntityBaseAll
    {
        /// <summary>
        /// 租户名称
        /// </summary>
        [Description("租户名称")]
        [Column(StringLength = 50)]
        public String CompanyName { get; set; }
    }
}
