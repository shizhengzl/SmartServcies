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

        public FreeSqlFactory(string connectionString,DataType dataType)
        {
            _DefaultBaseConnection = connectionString;
            _DefaultDataType = dataType;
        }

        public FreeSqlFactory(string connectionString)
        {
            _DefaultBaseConnection = connectionString;
        }

        public FreeSqlFactory()
        {
        }


        private IFreeSql PrivateFreeSql { get; set; }

        /// <summary>
        /// 实力
        /// </summary>
        public IFreeSql FreeSql 
        { 
            get {
                if (PrivateFreeSql.IsNull())
                {
                    PrivateFreeSql = new FreeSqlBuilder()
                   .UseConnectionString(DefaultDataType, DefaultBaseConnection)
                   .UseAutoSyncStructure(true).UseExitAutoDisposePool(true)
                   .Build();
                }
                return PrivateFreeSql;
            }
            set { 
            
            }
        }

        private string _DefaultBaseConnection { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DefaultBaseConnection
        {
            get
            { 
                if(_DefaultBaseConnection.IsNullOrEmpty())
                    _DefaultBaseConnection = $"Data Source=.;Initial Catalog={DefaultDataBaseName ?? "Core_Base"};Integrated Security=SSPI;Pooling=true;Min Pool Size=100;Max Pool Size=512;";
                return _DefaultBaseConnection;
            } 
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DefaultDataBaseName
        {
            get;set;
        }


        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public DataType _DefaultDataType
        {
            get; set;
        } = DataType.SqlServer;

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataType DefaultDataType
        {
            get
            {
                if(_DefaultDataType.IsNullOrEmpty())
                    _DefaultDataType = DataType.SqlServer; 
                return _DefaultDataType;
            }
        }
    }
}
