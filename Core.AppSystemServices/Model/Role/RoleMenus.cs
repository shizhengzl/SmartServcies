using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    [Description("角色菜单表")]
    public class RoleMenus:BaseCompany
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        public Guid RolesId { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        public Guid MenusId { get; set; }

         
    }
}
