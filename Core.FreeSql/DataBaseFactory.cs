using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FreeSqlServices
{
    public class DataBaseFactory
    {
        /// <summary>
        /// 核心数据库
        /// </summary>
        public static FreeSqlFactory _Core_Base { get; set; }
        /// <summary>
        /// 应用数据库
        /// </summary>
        public static FreeSqlFactory _Core_Application { get; set; } 
        /// <summary>
        /// 数据库配置
        /// </summary>
        public static FreeSqlFactory _Core_DataBase { get; set; }

        /// <summary>
        /// 日志数据库
        /// </summary>
        public static FreeSqlFactory _Core_Log { get; set; }
        /// <summary>
        /// 核心数据库
        /// </summary>
        public static FreeSqlFactory Core_Base {
            get
            {
                if (_Core_Base == null) 
                {
                    _Core_Base = new FreeSqlFactory(ConnectionBase.Core_Base.GetConnectionString());
                }
                return _Core_Base;
            }
        }
        /// <summary>
        /// 应用数据库
        /// </summary>
        public static FreeSqlFactory Core_Application
        {
            get
            {
                if (_Core_Application == null)
                {
                    _Core_Application = new FreeSqlFactory(ConnectionBase.Core_Application.GetConnectionString());
                }
                return _Core_Application;
            }
        }
        /// <summary>
        /// 核心数据库
        /// </summary>
        public static FreeSqlFactory Core_DataBase
        {
            get
            {
                if (_Core_DataBase == null)
                {
                    _Core_DataBase = new FreeSqlFactory(ConnectionBase.Core_DataBase.GetConnectionString());
                }
                return _Core_DataBase;
            } 
        }

        /// <summary>
        /// 日志数据库
        /// </summary>
        public static FreeSqlFactory Core_Log
        {
            get
            {
                if (_Core_Log == null)
                {
                    _Core_Log = new FreeSqlFactory(ConnectionBase.Core_Log.GetConnectionString());
                }
                return _Core_Log;
            }
        }
    }
}
