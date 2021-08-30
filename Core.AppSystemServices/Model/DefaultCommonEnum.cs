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
        defaultRole = 4
    }
}
