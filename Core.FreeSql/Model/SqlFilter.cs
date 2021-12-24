using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.FreeSqlServices
{
    public class SqlFilter
    {
        public String Logic { get; set;  }

        public List<SqlFilterColumn> Filters { get; set; }
    }


    public class SqlFilterColumn
    { 
        public String Field { get; set; }
        public String Operator { get; set; }
        public String Value { get; set; }

        public SqlFilter Filters {  get; set; }
    }

    public enum SqlLogicEnum
    {
        And,
        Or
    }

    public enum SqlOperatorEnum
    {
        [Description("等于")]
        Equal,
        [Description("不等于")]
        NotEqual,

        [Description("开始匹配字符")]
        StartsWith,
        [Description("结束匹配字符")]
        EndsWith,

        [Description("开始匹配字符不是")]
        NotStartsWith,
        [Description("结束匹配字符不是")]
        NotEndsWith,


        [Description("大于")]
        GreaterThan, 
        [Description("大于等于")]
        GreaterThanOrEqual,
        [Description("小于")]
        LessThan,
        [Description("小于等于")]
        LessThanOrEqual,
        [Description("范围查询")]
        Range,
        [Description("日期范围，有特殊处理 value[1] + 1")]
        RanDateRangege,
        [Description("是否符合 value 中任何一项（直白的说是 SQL IN）")]
        Any,
        [Description("是否符合 value 中任何一项（直白的说是 SQL NOT IN）")]
        NotAny,
 

    }
}
