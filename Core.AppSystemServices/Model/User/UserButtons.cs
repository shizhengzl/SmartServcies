using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{

    /// <summary>
    /// 用户按钮表
    /// </summary>
    [Description("用户按钮表")]
    public class UserButtons : BaseCompany
    {
        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        public Guid UsersId { get; set; }

        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        public Guid ButtonsId { get; set; }
    }
}
