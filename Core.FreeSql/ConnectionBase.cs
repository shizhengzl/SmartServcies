using System;
using System.Collections.Generic;
using System.Text;

namespace Core.FreeSqlServices
{
    public class ConnectionBase
    {
        //private static ConnectionString _Core_Base { get; set; }
        private static ConnectionString _Core_DataBase { get; set; }
        private static ConnectionString _Core_Application { get; set; }

        private static ConnectionString _Core_Log { get; set; }


        private static String DefaultUser = "u_temp";
        private static String DefaultPassWord = "3GfnOA#hbz%aRWR7njM&";
        private static String DefaultAddress = "192.168.0.100";
        //public static ConnectionString Core_Base
        //{
        //    get
        //    {
        //        if (_Core_Base == null)
        //        {
        //            _Core_Base = new ConnectionString()
        //            {
        //                Address = ".",
        //                DataType = FreeSql.DataType.SqlServer,
        //                DefaultDataBase = "Core_Base",
        //                IsWindows = false,
        //                UserIds = "sa",
        //                Password = "sasa"
        //            };
        //        }
        //        return _Core_Base;
        //    }
        //}


        public static ConnectionString Core_DataBase
        {
            get
            {
                if (_Core_DataBase == null)
                {
                    _Core_DataBase = new ConnectionString()
                    {
                        Address = DefaultAddress,// ".",
                        DataType = FreeSql.DataType.SqlServer,
                        DefaultDataBase = "Core_DataBase",
                        IsWindows = false,
                        UserIds = DefaultUser,// "sa",
                        Password = DefaultPassWord// "sasa"
                    };
                }
                return _Core_DataBase;
            }
        }


        public static ConnectionString Core_Application
        {
            get
            {
                if (_Core_Application == null)
                {
                    _Core_Application = new ConnectionString()
                    {
                        Address = DefaultAddress,
                        DataType = FreeSql.DataType.SqlServer,
                        DefaultDataBase = "Core_Application",
                        IsWindows = false,
                        UserIds = DefaultUser,
                        Password = DefaultPassWord
                    };
                }
                return _Core_Application;
            }
        }

        public static ConnectionString Core_Log
        {
            get
            {
                if (_Core_Log == null)
                {
                    _Core_Log = new ConnectionString()
                    {
                        Address = DefaultAddress,
                        DataType = FreeSql.DataType.SqlServer,
                        DefaultDataBase = "Core_Log",
                        IsWindows = false,
                        UserIds = DefaultUser,
                        Password = DefaultPassWord
                    };
                }
                return _Core_Log;
            }
        }






        public ConnectionBase()
        {
            //Core_Base.Address = ".";
            //Core_Base.IsWindows = false;
            //Core_Base.DataType = FreeSql.DataType.SqlServer;
            //Core_Base.DefaultDataBase = "Core_Base";
            //Core_Base.UserIds = "sa";
            //Core_Base.Password = "sasa";
             
            Core_DataBase.Address = DefaultAddress;
            Core_DataBase.IsWindows = false;
            Core_DataBase.DataType = FreeSql.DataType.SqlServer;
            Core_DataBase.DefaultDataBase = "Core_DataBase";
            Core_DataBase.UserIds = DefaultUser;
            Core_DataBase.Password = DefaultPassWord;

            Core_Application.Address = DefaultAddress;
            Core_Application.IsWindows = false;
            Core_Application.DataType = FreeSql.DataType.SqlServer;
            Core_Application.DefaultDataBase = "Core_Application";
            Core_Application.UserIds = DefaultUser;
            Core_Application.Password = DefaultPassWord;

            Core_Log.Address = DefaultAddress;
            Core_Log.IsWindows = false;
            Core_Log.DataType = FreeSql.DataType.SqlServer;
            Core_Log.DefaultDataBase = "Core_Log";
            Core_Log.UserIds = DefaultUser;
            Core_Log.Password = DefaultPassWord;
        } 

    }
}
