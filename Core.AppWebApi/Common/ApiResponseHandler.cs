using Core.UsuallyCommon;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Core.AppWebApi
{
    public class ApiResponseHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        public ApiResponseHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json"; 
            await Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                success = false,
                message = "Login",
                code = CodeDescription.Login
            }));
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json"; 
            await Response.WriteAsync(JsonConvert.SerializeObject(new  
            {
                success = false,
                message = "Login",
                code = CodeDescription.Login
            }));
        }

    }
}
