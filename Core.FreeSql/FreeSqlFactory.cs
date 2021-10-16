using FreeSql;
using System;
using Core.UsuallyCommon;

namespace Core.FreeSqlServices
{
     /// <summary>
    /// 数据库工厂
    /// </summary>
    public class FreeSqlFactory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FreeSqlFactory()
        {
           
          
        }

        /// <summary>
        /// 获取连接池
        /// </summary>
        /// <param name="DbType">数据库初始化类型</param>
        /// <param name="Connection">连接字符串</param>
        /// <param name="autoSync">自动同步</param>
        public static IFreeSql GetFreeSql(DataType DbType, String Connection,Boolean autoSync = false)
        {
            return new FreeSqlBuilder()
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
        public IFreeSql GetFreeSql( Boolean autoSync = false)
        {
            return new FreeSqlBuilder()
             .UseConnectionString(DefaultDataType, DefaultBaseConnection)
             .UseAutoSyncStructure(autoSync)
             .Build();
        }

        public static IFreeSql _FreeSql { get; set; }

        /// <summary>
        /// 实力
        /// </summary>
        public static IFreeSql FreeSql 
        { 
            get {
                if (_FreeSql.IsNull())
                {
                    _FreeSql = new FreeSqlBuilder()
                   .UseConnectionString(DefaultDataType, DefaultBaseConnection)
                   .UseAutoSyncStructure(true)
                   .Build();
                }
                return _FreeSql;
            } 
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DefaultBaseConnection
        {
            get
            {
                var connectionstring = "Data Source=.;Initial Catalog=Core_Base;Integrated Security=SSPI;Pooling=true;Min Pool Size=100;Max Pool Size=20;";
                var dc = System.Configuration.ConfigurationManager.AppSettings["DefaultBaseConnection"].ToStringExtension();
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
