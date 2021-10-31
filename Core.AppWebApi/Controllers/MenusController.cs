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
using Core.DataBaseServices;
using Core.AppSystemServices.Services;

namespace Core.AppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController
    {

        /// <summary>
        /// 注入接口
        /// </summary>
        public readonly IMapper mapper;
        public MenuServices menuServices { get; set; }
        public CommonServices commonServices {  get; set; }
        public MenusController(MenuServices _menuServices, IMapper _mapper, CommonServices _commonServices)
        {
            menuServices = _menuServices;
            mapper = _mapper;
            commonServices = _commonServices;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSupperMenus")]
        [Authorize]
        public Response<List<DtoMenus>> GetSupperMenus()
        {
            Response<List<DtoMenus>> response = new Response<List<DtoMenus>>();

            var menus = menuServices.GetSupperMenus();  
            var firstmenus = menus.Where(x=>x.MenusId == Guid.Empty).ToList(); 
            response.Data = mapper.Map<List<DtoMenus>>(firstmenus);
            response.Data.ForEach(x => {
                GetChildren(x,menus);
            });
            return response;
        }


        private void GetChildren(DtoMenus dtoMenus,List<Menus> menus)
        {
            var children = menus.Where(x => x.MenusId == dtoMenus.Id).ToList();
            dtoMenus.children = mapper.Map<List<DtoMenus>>(children);  
            dtoMenus.children.ForEach(x => { 
                GetChildren(x, menus);
            }); 
        }


     
    }
}
