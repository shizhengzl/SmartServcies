using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 日志
    /// </summary>
    public class LogServices : SystemServices
    {

        public LogServices() : base(DataBaseFactory.Core_Log.FreeSql)
        { 
        
        }

        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="description"></param>
        public void AddExexptionLogs(Exception ex,string method, string description)
        {
            ExceptionLogs logs = new ExceptionLogs()
            {
                CreateTime = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Description = description,
                Method = method

            };
            Create<ExceptionLogs>(logs);
        }
    }
}
