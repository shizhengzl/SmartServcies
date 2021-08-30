using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 部门菜单表
    /// </summary>
    [Description("部门菜单表")]
    public class DepartmentMenus
    {
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        public Guid DepartmentsId { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        public Guid MenusId { get; set; }
    }
}
