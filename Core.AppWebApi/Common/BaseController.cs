using Core.AppSystemServices;
using Core.CacheServices;
using Microsoft.AspNetCore.Mvc;

namespace Core.AppWebApi
{
    /// <summary>
    /// 基类控制器
    /// </summary>
    public class BaseController : ControllerBase
    {
        private CurrentSesscion GetCurrentSesscion()
        {
            var token = GetToken(); 
            return MemoryCacheManager.GetCache<CurrentSesscion>(token);
        }

        private string GetToken()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }

        /// <summary>
        /// 获取token
        /// </summary>
        public string Token { get { return GetToken(); } }


        /// <summary>
        /// 活当前用户
        /// </summary>
        public CurrentSesscion session { get { return GetCurrentSesscion(); } }




    }
}
