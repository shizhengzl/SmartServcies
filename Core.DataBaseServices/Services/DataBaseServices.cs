using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;
using FreeSql;
using System.Linq;

namespace Core.DataBaseServices
{
    [AppServiceAttribute]
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
        /// 添加列属性
        /// </summary>
        /// <returns></returns>
        public void AddExtendedproperty(IFreeSql freesql, DataType dataType,string table, string column, string description)
        {
            var addproperty = sqlconfigservices.AddExtendedproperty(dataType);
            addproperty = string.Format(addproperty, table, column, description);
            freesql.Ado.ExecuteNonQuery(addproperty);
        }

        /// <summary>
        /// 修改列属性
        /// </summary>
        /// <returns></returns>
        public void ModifyExtendedproperty(IFreeSql freesql, DataType dataType, string table, string column, string description)
        {
            var modifyproperty = sqlconfigservices.ModifyExtendedproperty(dataType);
            modifyproperty = string.Format(modifyproperty, table, column, description);
            freesql.Ado.ExecuteNonQuery(modifyproperty);
        }



        /// <summary>
        /// 添加表属性
        /// </summary>
        /// <returns></returns>
        public void AddTableExtendedproperty(IFreeSql freesql, DataType dataType, string table, string description)
        {
            var addproperty = sqlconfigservices.AddTableExtendedproperty(dataType);
            addproperty = string.Format(addproperty, table, description);
            freesql.Ado.ExecuteNonQuery(addproperty);
        }

        /// <summary>
        /// 修改表属性
        /// </summary>
        /// <returns></returns>
        public void ModifyTableExtendedproperty(IFreeSql freesql, DataType dataType, string table, string description)
        {
            var modifyproperty = sqlconfigservices.ModifyTableExtendedproperty(dataType);
            modifyproperty = string.Format(modifyproperty, table, description);
            freesql.Ado.ExecuteNonQuery(modifyproperty);
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
