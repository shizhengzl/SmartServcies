using Core.AppSystemServices;
using Core.UsuallyCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.AppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : BaseController
    {
        public PermissionServices _permissionServices { get; set; }
        public PermissionController(PermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }

        /// <summary>
        /// 保存用户权限
        /// </summary>
        /// <returns></returns>
        [HttpPost("SaveUserPermission")]
        [Authorize]
        public Response<string> SaveUserPermission([FromBody] RequestModel<SaveUserPermission> request)
        {
            Response<string> response = new Response<string>();
            var userpermission = request.Model;

            List<UserButtons> buttons = new List<UserButtons>();
            List<UserMenus> menus = new List<UserMenus>();
            if (userpermission != null) {
                if (userpermission.UserButtons != null) {
                    userpermission.UserButtons.ForEach(x =>{  
                        buttons.Add(new UserButtons()
                        {
                            ButtonsId = x.ButtonId,
                            UsersId = x.UserId,
                            CompanysId = session.User.CompanysId
                        });  
                    });
                }
                if (userpermission.UserMenus != null)
                {
                    userpermission.UserMenus.ForEach(x => {
                        menus.Add(new UserMenus()
                        {
                            MenusId = x.MenuId,
                            UsersId = x.UserId,
                            CompanysId = session.User.CompanysId
                        });
                    });
                }
            }

            response.Success = _permissionServices.SaveUserPermission(menus, buttons);
            return response;
        }


        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost("SaveRolePermission")]
        [Authorize]
        public Response<string> SaveRolePermission([FromBody] RequestModel<SaveRolePermission> request)
        {
            Response<string> response = new Response<string>();
            var rolepermission = request.Model; 
            List<RoleButtons> buttons = new List<RoleButtons>();
            List<RoleMenus> menus = new List<RoleMenus>();
            if (rolepermission != null)
            {
                if (rolepermission.RoleButtons != null)
                {
                    rolepermission.RoleButtons.ForEach(x => {
                        buttons.Add(new RoleButtons()
                        {
                            ButtonsId = x.ButtonId,
                            RolesId = x.RoleId,
                            CompanysId = session.User.CompanysId
                        });
                    });
                }
                if (rolepermission.RoleMenus != null)
                {
                    rolepermission.RoleMenus.ForEach(x => {
                        menus.Add(new RoleMenus()
                        {
                            MenusId = x.MenuId,
                            RolesId = x.RoleId,
                            CompanysId = session.User.CompanysId
                        });
                    });
                }
            } 
            response.Success = _permissionServices.SaveRolePermission(menus, buttons);
            return response;
        }



        /// <summary>
        /// 保存机构权限
        /// </summary>
        /// <returns></returns>
        [HttpPost("SaveOrganizationPermission")]
        [Authorize]
        public Response<string> SaveOrganizationPermission([FromBody] RequestModel<SaveOrganizationPermission> request)
        {
            Response<string> response = new Response<string>();
            var organizationpermission = request.Model;
            List<OrganizationButtons> buttons = new List<OrganizationButtons>();
            List<OrganizationMenus> menus = new List<OrganizationMenus>();
            if (organizationpermission != null)
            {
                if (organizationpermission.OrganizationButtons != null)
                {
                    organizationpermission.OrganizationButtons.ForEach(x => {
                        buttons.Add(new OrganizationButtons()
                        {
                            ButtonsId = x.ButtonId,
                            OraganizationsId = x.OrganizationId,
                            CompanysId = session.User.CompanysId
                        });
                    });
                }
                if (organizationpermission.OrganizationMenus != null)
                {
                    organizationpermission.OrganizationMenus.ForEach(x => {
                        menus.Add(new OrganizationMenus()
                        {
                            MenusId = x.MenuId,
                            OrganizationsId = x.OrganizationId,
                            CompanysId = session.User.CompanysId
                        });
                    });
                }
            }
            response.Success = _permissionServices.SaveOrganizationPermission(menus, buttons);
            return response;
        }
    }
}
