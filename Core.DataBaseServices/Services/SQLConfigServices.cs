using Core.FreeSqlServices;
using Core.UsuallyCommon;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataBaseServices
{
    /// <summary>
    /// 配置服务类
    /// </summary>
    public class SQLConfigServices
    {
        public static IFreeSql _freesql { get; set; }

        public ConnectionStringManage _connectionManage { get; set; }

        public SQLConfigServices(ConnectionStringManage connectionStringManage)
        {
            _freesql = new FreeSqlFactory().FreeSql;
            _connectionManage = connectionStringManage;
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

        /// <summary>
        /// 获取所有数据库
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetDataBases()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().GetDataBaseSQL.ToStringExtension();
        }

        /// <summary>
        /// 获取数据库的表
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetTables()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().GetTableSQL.ToStringExtension();
        }

        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetColumns()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().GetColumnSQL.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string AddExtendedproperty()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().AddExtendedproperty.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string ModifyExtendedproperty()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().ModifyExtendedproperty.ToStringExtension();
        }



        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string AddTableExtendedproperty()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().AddTableExtendedproperty.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string ModifyTableExtendedproperty()
        {
            return _freesql.Select<SQLConfig>().Where(x => x.Type == _connectionManage.DataBaseType).First().ModifyTableExtendedproperty.ToStringExtension();
        }
    }
}
