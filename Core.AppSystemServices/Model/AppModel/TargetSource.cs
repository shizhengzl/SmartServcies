using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.AppSystemServices
{
 
    public enum TargetSource
    { 
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
