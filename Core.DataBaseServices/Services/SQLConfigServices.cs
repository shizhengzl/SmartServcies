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
    public class SQLConfigServices : SystemServices
    {

        public SQLConfigServices() : base(DataBaseFactory.Core_DataBase.FreeSql)
        { 
        
        }
        /// <summary>
        /// 获取所有数据库
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetDataBases(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().GetDataBaseSQL.ToStringExtension();
        }

        /// <summary>
        /// 获取数据库的表
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetTables(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().GetTableSQL.ToStringExtension();
        }

        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string GetColumns(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().GetColumnSQL.ToStringExtension();
        } 


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string AddExtendedproperty(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().AddExtendedproperty.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string ModifyExtendedproperty(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().ModifyExtendedproperty.ToStringExtension();
        }



        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string AddTableExtendedproperty(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().AddTableExtendedproperty.ToStringExtension();
        }


        /// <summary>
        /// 获取数据库表的列
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public string ModifyTableExtendedproperty(DataType dataType)
        {
            return GetEntitys<SQLConfig>().Where(x => x.Type == dataType).First().ModifyTableExtendedproperty.ToStringExtension();
        }
    }
}
