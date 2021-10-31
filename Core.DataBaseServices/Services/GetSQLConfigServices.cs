using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;
using System.Linq;

namespace Core.DataBaseServices
{
    public class GetSQLConfigServices
    {
        /// <summary>
        /// 获取当前连接下所以表的列
        /// </summary>
        /// <returns></returns>
        public static List<Column> GetColumn(string tableName)
        {
            var columnsql = FreeSqlFactory.FreeSql.Select<SQLConfig>().Where(x => x.Type == FreeSqlFactory.FreeSql.Ado.DataType).First().GetColumnSQL.ToStringExtension();
            return FreeSqlFactory.FreeSql.Ado.ExecuteDataTable(columnsql).ToList<Column>().Where(x=>x.TableName.ToUpper() == tableName.ToUpper()).ToList();
        } 

    }
}
