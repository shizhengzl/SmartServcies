using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppSystemServices
{
    public class SQLScripts
    {
        /*
         *  移除表
            DECLARE @snippet nvarchar(MAX) ='DROP TABLE @TableName;' + CHAR(10)
            DECLARE @result nvarchar(MAX) = ''
            SELECT @result = @result + REPLACE(@snippet,'@TableName',name) FROM sys.tables 
            exec  (@result)

         */
    }
}
