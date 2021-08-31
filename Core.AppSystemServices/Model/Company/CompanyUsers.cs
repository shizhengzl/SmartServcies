using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 单位用户
    /// </summary>
    [Description("单位用户")]
    public class CompanyUsers
    {
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        public Guid UsersId { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public Guid CompanysId { get; set; }
    }
}
