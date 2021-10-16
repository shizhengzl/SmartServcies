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
    public class MenusController : BaseController
    {

        /// <summary>
        /// 注入接口
        /// </summary>
        public readonly IMapper _mapper;
        public MenuServices _menuServices { get; set; }
        public MenusController(MenuServices menuServices, IMapper mapper)
        {
            _menuServices = menuServices;
            _mapper = mapper;
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

            var menus = _menuServices.GetSupperMenus();  
            var firstmenus = menus.Where(x=>x.MenusId == Guid.Empty).ToList(); 
            response.Data = _mapper.Map<List<DtoMenus>>(firstmenus);
            response.Data.ForEach(x => {
                GetChildren(x,menus);
            });
            return response;
        }


        private void GetChildren(DtoMenus dtoMenus,List<Menus> menus)
        {
            var children = menus.Where(x => x.MenusId == dtoMenus.Id).ToList();
            dtoMenus.children = _mapper.Map<List<DtoMenus>>(children);  
            dtoMenus.children.ForEach(x => { 
                GetChildren(x, menus);
            }); 
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetListHeader")]
        [Authorize]
        public Response<List<HeaderExtensions>> GetListHeader()
        {
            Response<List<HeaderExtensions>> response = new Response<List<HeaderExtensions>>();

            List<HeaderExtensions> list = new List<HeaderExtensions>();
            ObjectExtensions.GetPropertyExtensions<Menus>().ForEach(x =>
            {
                list.Add(new HeaderExtensions()
                {
                    ColumnDescription = x.PropertyDescription,
                    ColumnName = x.PropertyName.ToStringExtension().ToFirstCharToLower(),
                    IsShow = true,
                    Width = 200
                });

            });
            response.Data = list;
            return response;
        }
    }
}
