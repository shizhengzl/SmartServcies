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
using Core.AppSystemServices;

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
        public CommonServices commonServices { get; set; }
        public MenusController(MenuServices _menuServices, IMapper _mapper, CommonServices _commonServices)
        {
            menuServices = _menuServices;
            mapper = _mapper;
            commonServices = _commonServices;
        }

        /// <summary>
        /// 获取超级管理员信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetParentMenus")]
        [Authorize]
        public Response<List<DtoMenus>> GetParentMenus()
        {
            Response<List<DtoMenus>> response = new Response<List<DtoMenus>>();

            var menus = menuServices.GetParentMenus();
            var buttons = menuServices.GetPermissionButtons(this.session.User.CompanysId);
            var firstmenus = menus.Where(x => x.MenusId == Guid.Empty).ToList();
            response.Data = mapper.Map<List<DtoMenus>>(firstmenus);
            response.Data.ForEach(x =>
            {
                GetChildren(x, menus, buttons);
            });
            return response;
        }

        /// <summary>
        /// 获取单位菜单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetCompanyMenus")]
        [Authorize]
        public Response<List<DtoMenus>> GetCompanyMenus()
        {
            Response<List<DtoMenus>> response = new Response<List<DtoMenus>>();

            var menus = menuServices.GetCompanyMenus(this.session.User.CompanysId);
            var buttons = menuServices.GetPermissionButtons(this.session.User.CompanysId);
            var firstmenus = menus.Where(x => x.MenusId == Guid.Empty).ToList();
            response.Data = mapper.Map<List<DtoMenus>>(firstmenus);
            response.Data.ForEach(x =>
            {
                GetChildren(x, menus, buttons);
            });
            return response;
        }




        /// <summary>
        /// 获取超级管理员信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSupperMenus")]
        [Authorize]
        public Response<List<DtoMenus>> GetSupperMenus([FromBody] BaseRequest<Menus> request)
        {
            Response<List<DtoMenus>> response = new Response<List<DtoMenus>>();

            var menus = menuServices.GetSupperMenus();
            var buttons = menuServices.GetPermissionButtons(this.session.User.CompanysId);
            var firstmenus = menus.Where(x => x.MenusId == Guid.Empty).ToList();
            response.Data = mapper.Map<List<DtoMenus>>(firstmenus);
            response.Data.ForEach(x =>
            {
                GetChildren(x, menus, buttons);
            });
            return response;
        }


        private void GetChildren(DtoMenus dtoMenus, List<Menus> menus, List<PermissionButton> buttons)
        {
            var children = menus.Where(x => x.MenusId == dtoMenus.Id).ToList();
            dtoMenus.children = mapper.Map<List<DtoMenus>>(children);
            dtoMenus.buttons = buttons.Where(p => p.MenusId == dtoMenus.Id).ToList();

            dtoMenus.children.ForEach(x =>
            {
                GetChildren(x, menus, buttons);
            });

            // ok
            if (dtoMenus.children == null || dtoMenus.children.Count == 0 && dtoMenus.buttons != null && dtoMenus.buttons.Count > 0)
            {
                dtoMenus.children = new List<DtoMenus>();
                dtoMenus.buttons.ForEach(x =>
                {
                    dtoMenus.children.Add(new DtoMenus()
                    {
                        HasButton = true,
                        MenusId = x.Id,
                        MenuName = x.Name,
                        Description = x.Note
                    });
                });
            }
        }



    }
}
