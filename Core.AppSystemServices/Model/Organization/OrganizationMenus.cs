using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 组织机构菜单表
    /// </summary>
    [Description("组织机构菜单表")]
    public class OrganizationMenus
    {
        /// <summary>
        /// 部门
        /// </summary>
        [Description("组织机构")]
        public Guid OraganizationsId { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        public Guid MenusId { get; set; }
    }
}
