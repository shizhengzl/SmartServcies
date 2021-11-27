using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;
using FreeSql;
using System.Linq;

namespace Core.DataBaseServices
{
    public class DataBaseServices : SystemServices
    {
        public DataBaseServices() : base(DataBaseFactory.Core_DataBase.FreeSql)
        {

        }

        SQLConfigServices sqlconfigservices = new SQLConfigServices();
        /// <summary>
        /// 获取连接下所有数据库
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<DataBase> GetDataBase(IFreeSql freesql, DataType dataType)
        { 
            var databasesql = sqlconfigservices.GetDataBases(dataType);
            return freesql.Ado.ExecuteDataTable(databasesql).ToList<DataBase>();
        }


        /// <summary>
        /// 获取连接下所有表
        /// </summary>
        /// <returns></returns>
        public List<Table> GetTable(IFreeSql freesql, DataType dataType)
        { 
            var tablesql = sqlconfigservices.GetTables(dataType);
            return freesql.Ado.ExecuteDataTable(tablesql).ToList<Table>();
        }


        /// <summary>
        /// 获取连接下所有列
        /// </summary>
        /// <returns></returns>
        public List<Column> GetColumn(IFreeSql freesql, DataType dataType,String tableName = "")
        {  
            var columnsql = sqlconfigservices.GetColumns(dataType);
            var response = freesql.Ado.ExecuteDataTable(columnsql).ToList<Column>();
            if (!tableName.IsNullOrEmpty())
                response = response.Where(x => x.TableName.ToUpper().Equals(tableName.ToUpper())).ToList();
            return response;
        }

    }
}
