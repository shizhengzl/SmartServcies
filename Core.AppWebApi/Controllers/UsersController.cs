using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.UsuallyCommon;
using Core.AppSystemServices;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Core.CacheServices;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace Core.AppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: BaseController
    {
        /// <summary>
        /// 注入接口
        /// </summary>
        public readonly IMapper _mapper;
        public UserServices _userServices { get; set;  }
        public UsersController(UserServices usersSrevices, IMapper mapper)
        {
            _userServices = usersSrevices;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public Response<string> Login([FromBody] DtoUser user)
        { 
            Response<string> response = new Response<string>();
            user.PassWord = user.PassWord.Tomd5();
            var responsesessions = _userServices.Login(_mapper.Map<Users>(user));  
            if (!responsesessions.Success) {
                response.Message = responsesessions.Message;
                response.Code = CodeDescription.Faile;
                response.Success = false;
                return response;
            } 
            var getuser = responsesessions.Data.User; 
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, getuser.Id.ToStringExtension())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PublicConst.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: PublicConst.Domain,
                audience: PublicConst.Domain,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            response.Success = true;
            response.Data = new JwtSecurityTokenHandler().WriteToken(token);
            MemoryCacheManager.SetRefushCache<CurrentSesscion>(response.Data, responsesessions.Data, TimeSpan.FromMinutes(30));  
            return response;
        }



        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetUserInfo")]
        [Authorize]
        public IActionResult GetUserInfo()
        {

            // 获取用请求携带token
            var users = session.User;
            var roles = session.Roles.Select(x => x.Name).ToList();
            var menus = session.UserMenus;

            List<MenuTree> router = new List<MenuTree>();
            // 组织menus
            var parent = menus.Where(x => x.MenusId == Guid.Empty).ToList();
            parent.ForEach(p =>
            {
                router.Add(GetMenuTree(p, menus));
            });


            // 获取用户菜单
            return Ok(new { 
                Success = true
                , code = CodeDescription.Success
                , roles = roles
                , name = users.NikeName
                , data = Token
                , router = router
                , avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif" });
        }


        private MenuTree GetMenuTree(Menus menu, List<Menus> menus)
        {
            var child = GetChilds(menu.Id, menus);
            return new MenuTree()
            {
                Id = menu.Id,
                path = menu.Path,
                component = menu.Component,
                name = menu.MenuName,
                meta = new MenuMeta() { icon = menu.MenuIcon, title = menu.MenuName, noCache = true },
                children = child,
                redirect = child.Count == 0 ? null : child.FirstOrDefault().path
            };
        }


        private List<MenuTree> GetChilds(Guid ParentID, List<Menus> menus)
        {
            List<MenuTree> result = new List<MenuTree>();
            menus.Where(x => x.MenusId == ParentID).ToList().ForEach(p => result.Add(GetMenuTree(p, menus)));
            return result;
        }
    }

    public class PublicConst
    {
        public const string Domain = "";
        public const string SecurityKey = "1234567890abcdefg";
    }
}
