using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 单位菜单表
    /// </summary>
    [Description("单位菜单表")]
    public class CompanyMenus
    {
        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public Guid CompanysId { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        public Guid MenusId { get; set; }
    }
}
