using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 角色用户
    /// </summary>
    [Description("角色用户")]
    public class RoleUsers
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        public Guid RolesId { get; set; }

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
