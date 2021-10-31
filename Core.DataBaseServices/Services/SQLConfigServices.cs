using Core.FreeSqlServices;
using Core.UsuallyCommon;
using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataBaseServices
{
    /// <summary>
    /// 其他数据库配置服务类
    /// </summary>
    public class SQLConfigServices
    {
        public static IFreeSql PrivateFreeSql { get; set; }

        public ConnectionStringManage PrivateConnectionManage { get; set; }

        public SQLConfigServices(ConnectionStringManage connectionStringManage)
        {
            PrivateConnectionManage = connectionStringManage;
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
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().GetDataBaseSQL.ToStringExtension();
        }

        /// <summary>
        /// 获取数据库的表
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetTables()
        {
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().GetTableSQL.ToStringExtension();
        }

        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetColumns()
        {
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().GetColumnSQL.ToStringExtension();
        } 


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string AddExtendedproperty()
        {
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().AddExtendedproperty.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string ModifyExtendedproperty()
        {
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().ModifyExtendedproperty.ToStringExtension();
        }



        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string AddTableExtendedproperty()
        {
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().AddTableExtendedproperty.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string ModifyTableExtendedproperty()
        {
            return PrivateFreeSql.Select<SQLConfig>().Where(x => x.Type == PrivateConnectionManage.DataBaseType).First().ModifyTableExtendedproperty.ToStringExtension();
        }
    }
}
