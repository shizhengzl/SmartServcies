using Core.FreeSqlServices;
using Core.UsuallyCommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 日志
    /// </summary>
    [AppServiceAttribute]
    public class LogServices : SystemServices
    {

        public LogServices() : base(DataBaseFactory.Core_Log.FreeSql)
        {

        }

        /// <summary>
        /// 获取列表
        /// </summary> 
        /// <param name="request"></param> 
        /// <returns></returns>
        public List<object> GetList(BaseRequest<string> request)
        {
            return GetEntitys(request);
        }


        public void AddOperationLogs(CurrentSesscion sesscion, object data, object newData,string url,string IP)
        {
            OpeartionLogs opeartionLogs = new OpeartionLogs()
            {
                CompanysId = sesscion == null ? Guid.Empty : sesscion.User.CompanysId,
                CreateUserId = sesscion == null ? Guid.Empty : sesscion.User.Id,
                CreateTime = DateTime.UtcNow,
                JsonData = JsonConvert.SerializeObject(data),
                NewJsonData = JsonConvert.SerializeObject(newData),
                IP = IP,
                OpeartionDescripton = $"{sesscion.User.UserName}({sesscion.User.NikeName})在"
            };
            Create<OpeartionLogs>(opeartionLogs);
        }

        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="description"></param>
        public void AddExexptionLogs(Exception ex,string method,string description, CurrentSesscion sesscion)
        {
            ExceptionLogs logs = new ExceptionLogs()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                CreateTime = DateTime.UtcNow,
                Method = method,
                Description= description,
                CreateUserId = sesscion == null ? Guid.Empty : sesscion.User.Id,
                CompanysId = sesscion == null ? Guid.Empty : sesscion.User.CompanysId
            };
            Create<ExceptionLogs>(logs);
        }
    }
}
