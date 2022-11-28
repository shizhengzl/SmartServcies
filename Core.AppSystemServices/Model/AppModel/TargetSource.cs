using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
    [Description("目标数据源")]
    public enum TargetSource
    {
        [Description("枚举")]
        Enum,
        [Description("表")]
        Table ,
        [Description("SQL")]
        SQL,
        [Description("基础数据")]
        BaseData,
        [Description("外部数据源")]
        External
    }
}
