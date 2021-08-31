using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    public enum DefaultCommonEnum
    {
        [Description("admin")]
        defaultAdmin =0,
        [Description("00000000-0000-0000-0000-000000000001")]
        defaultCompany = 1,
        [Description("00000000-0000-0000-0000-000000000002")]
        defaultsuppermenuid = 2,
        [Description("00000000-0000-0000-0000-000000000003")]
        defaultsystemmenuid = 3,
        [Description("系统管理员")]
        defaultRole = 4,
        [Description("00000000-0000-0000-0000-000000000005")]
        defaultSelfRole = 5,
        [Description("00000000-0000-0000-0000-000000000006")]
        defaultCompanyRole = 6,

        [Description("00000000-0000-0000-0000-000000000007")]
        defaultSelfUser = 7,
        [Description("00000000-0000-0000-0000-000000000008")]
        defaultCompanyUser = 8,

        [Description("00000000-0000-0000-0000-000000000009")]
        defaultSelfOrganization = 9,
        [Description("00000000-0000-0000-0000-000000000010")]
        defaultOrganization = 10,

        [Description("智能科技云计算技术有限公司")]
        defaultSelfCompanyName = 11,
        [Description("隔壁老王管理公司")]
        defaultCompanyName = 12
    }
}
