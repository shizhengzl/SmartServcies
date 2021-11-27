using Core.AppSystemServices;
using Core.CacheServices;
using Core.UsuallyCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Core.AppWebApi
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
         
        public PermissionAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly IHttpContextAccessor _httpContextAccessor;


        public override Task HandleAsync(AuthorizationHandlerContext context)
        {

            //Microsoft.AspNetCore.Http.HttpContext httpContext = ((Microsoft.AspNetCore.Http.DefaultHttpContext)((Microsoft.AspNetCore.Mvc.ActionContext)context.Resource).HttpContext);
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            //var routContext = (context.Resource as Microsoft.AspNetCore.Routing.RouteEndpoint); 
            var user = MemoryCacheManager.GetCache<CurrentSesscion>(token);
            if (user == null)
            {
                context.Fail();
                //return Task.FromResult(new JsonResult(new
                //{
                //    Success = false,
                //    Message = "Login",
                //    Code = CodeDescription.Login
                //})); 
            }
            else
            {
                foreach (var requemet in context.Requirements)
                {
                    context.Succeed(requemet);
                }
            }

            return Task.CompletedTask;
        }



        /// <summary>
        /// 判断是否授权
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            Microsoft.AspNetCore.Http.HttpContext httpContext = ((Microsoft.AspNetCore.Http.DefaultHttpContext)((Microsoft.AspNetCore.Mvc.ActionContext)context.Resource).HttpContext);
            var authorizationFilterContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;
            var user = httpContext;
            if (user == null)
                authorizationFilterContext.Result = new JsonResult(new
                {
                    Success = false,
                    Message = "Login",
                    Code = CodeDescription.NotPermission
                });
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
