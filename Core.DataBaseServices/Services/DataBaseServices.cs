using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;

namespace Core.DataBaseServices
{
    public class DataBaseServices : SystemServices
    {
         
        public IFreeSql PrivateFreeSql { get; set; }

        public ConnectionStringManage _connectionManage { get; set; }

        public DataBaseServices(ConnectionStringManage connectionStringManage)
        {
            PrivateFreeSql = GetFreeSql(connectionStringManage);
            _connectionManage = connectionStringManage;
        }
         
        /// <summary>
        /// 获取连接下所有数据库
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<DataBase> GetDataBase()
        { 
            SQLConfigServices sqlconfigservices = new SQLConfigServices(_connectionManage);
            var databasesql = sqlconfigservices.GetDataBases();
            return PrivateFreeSql.Ado.ExecuteDataTable(databasesql).ToList<DataBase>();
        }


        /// <summary>
        /// 获取连接下所有表
        /// </summary>
        /// <returns></returns>
        public List<Table> GetTable(string DataBaseName)
        {
            _connectionManage.DefaultDataBase = DataBaseName;
            PrivateFreeSql = GetFreeSql(_connectionManage);
            SQLConfigServices sqlconfigservices = new SQLConfigServices(_connectionManage);
            var tablesql = sqlconfigservices.GetTables();
            return PrivateFreeSql.Ado.ExecuteDataTable(tablesql).ToList<Table>();
        }


        /// <summary>
        /// 获取连接下所有列
        /// </summary>
        /// <returns></returns>
        public List<Column> GetColumn(string DataBaseName)
        {
            _connectionManage.DefaultDataBase = DataBaseName;
            SQLConfigServices sqlconfigservices = new SQLConfigServices(_connectionManage);
            var columnsql = sqlconfigservices.GetColumns();
            PrivateFreeSql = GetFreeSql(_connectionManage);
            return PrivateFreeSql.Ado.ExecuteDataTable(columnsql).ToList<Column>();
        }



        /// <summary>
        /// 获取连接持
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IFreeSql GetFreeSql(ConnectionStringManage search)
        {
            return FreeSqlFactory.GetFreeSql(search.DataBaseType, search.GetConnectionString());
        }


        public void InitCompanySqlConfig() 
        {
            
        }
    }
}
