using Core.AppSystemServices;
using Core.UsuallyCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Core.AppWebApi.Filters
{
    /// <summary>
    /// 全局异常钩子
    /// </summary>
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        public GlobalExceptionsFilter(LogServices logServices)
        {
            _logServices = logServices;
        }
        LogServices _logServices  {get;set;}

        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;  
            //日志入库
            //向负责人发报警邮件，异步
            //向负责人发送报警短信或者报警电话，异步 
            // 这里获取服务器ip时，需要考虑如果是使用nginx做了负载，这里要兼容负载后的ip，
            // 监控了ip方便定位到底是那台服务器出故障了
            string ip = context.HttpContext.Connection.RemoteIpAddress.ToString();

            //_logServices.AddExexptionLogs(ex, context.ActionDescriptor.DisplayName,string.Empty);

            //_logger.LogError($"系统编号：{sysId},主机IP:{ip},堆栈信息：{ex.StackTrace},异常描述：{ex.Message}");


            context.Result = new JsonResult (new
            {
                Success = false,
                Message = ex.Message,
                Code = CodeDescription.Faile
            });
            context.ExceptionHandled = true;
        }
    }
}
