using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UsuallyCommon
{
    public class CommonSQL
    {
        /// <summary>
        ///  移除表
        /// </summary>
        public static string ClearTableSql = @"DECLARE @snippet nvarchar(MAX) ='DROP TABLE @TableName;' + CHAR(10)
            DECLARE @result nvarchar(MAX) = ''
            SELECT @result = @result + REPLACE(@snippet,'@TableName',name) FROM sys.tables 
            exec  (@result)";
    }
}
