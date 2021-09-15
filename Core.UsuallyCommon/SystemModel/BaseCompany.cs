using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.UsuallyCommon
{
    /// <summary>
    /// 租户基类
    /// </summary>
    public class BaseCompany : EntityBaseAll
    {
        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public Guid CompanysId { get; set; }
    }
}
