using FreeSql;
using System;
using System.Collections.Generic;
using System.Text;
using Core.UsuallyCommon;

namespace Core.AppEntitys
{
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public class FreeSqlFactory
    {
        /// <summary>
        /// 获取连接池
        /// </summary>
        /// <param name="DbType">数据库初始化类型</param>
        /// <param name="Connection">连接字符串</param>
        /// <param name="autoSync">自动同步</param>
        public void GetFreeSql(DataType DbType, String Connection,Boolean autoSync = false)
        {
            FreeSql = new FreeSqlBuilder()
             .UseConnectionString(DbType, Connection)
             .UseAutoSyncStructure(autoSync)
             .Build();
        }


        /// <summary>
        /// 获取连接池
        /// </summary>
        /// <param name="DbType">数据库初始化类型</param>
        /// <param name="Connection">连接字符串</param>
        /// <param name="autoSync">自动同步</param>
        public void GetFreeSql( Boolean autoSync = false)
        {
            FreeSql = new FreeSqlBuilder()
             .UseConnectionString(DefaultDataType, DefaultBaseConnection)
             .UseAutoSyncStructure(autoSync)
             .Build();
        }

        /// <summary>
        /// 实力
        /// </summary>
        public IFreeSql FreeSql { get; set; } 
 

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DefaultBaseConnection
        {
            get
            {
                var connectionstring = "Data Source=DESKTOP-4B71JOP;Initial Catalog=Core_Base;Integrated Security=SSPI;";
                var dc = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultBaseConnection"].ToStringExtension();
                if (!string.IsNullOrEmpty(dc))
                {
                    connectionstring = dc;
                } 
                return connectionstring;
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static DataType DefaultDataType
        {
            get
            {
                var datetype = DataType.SqlServer;
                var datatypestring = System.Configuration.ConfigurationManager.ConnectionStrings["DataType"].ToStringExtension();
                if (!string.IsNullOrEmpty(datatypestring))
                {
                    datetype = datatypestring.ToEnum<DataType>();
                } 
                return datetype;
            }
        }
    }
}
