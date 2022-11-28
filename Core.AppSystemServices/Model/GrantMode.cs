using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 授权模式
    /// </summary>
    [Description("授权模式")]
    public enum GrantMode
    {
        [Description("角色授权")]
        RoleGrant = 0,
        [Description("单位授权")]
        CompanyGrant = 1 ,
        [Description("部门授权")]
        OrganizationGrant = 2,
        [Description("用户授权")]
        UserGrant = 3
    }
}
