using Core.UsuallyCommon;
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
    public class RoleUsers:BaseCompany
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
         
    }
}
