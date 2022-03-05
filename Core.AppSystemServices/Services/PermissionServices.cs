using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 用户服务
    /// </summary>
    [AppServiceAttribute]
    public class PermissionServices : SystemServices
    {
        public PermissionServices() : base(DataBaseFactory.Core_Application.FreeSql)
        {

        }

        /// <summary>
        /// 保存用户权限
        /// </summary>
        /// <param name="userMenus"></param>
        /// <param name="userButtons"></param>
        /// <returns></returns>
        public Boolean SaveUserPermission(List<UserMenus> userMenus,List<UserButtons> userButtons)
        {
            bool response = true;

            var userid = userMenus.FirstOrDefault().UsersId;
            var companyid = userMenus.FirstOrDefault().CompanysId;

            var listmenus = GetEntitys<UserMenus>().Where(x => x.UsersId == userid && x.CompanysId == companyid).ToList();
            Remove<UserMenus>(listmenus.ToArray());


            var listbuttons = GetEntitys<UserButtons>().Where(x => x.UsersId == userid && x.CompanysId == companyid).ToList();
            Remove<UserButtons>(listbuttons.ToArray());

            var rus = Create<UserMenus>(userMenus);
            var ubs = Create<UserButtons>(userButtons);
            return response;
        }

        /// <summary>
        /// 保存角色授权
        /// </summary>
        /// <param name="roleMenus"></param>
        /// <param name="roleButtons"></param>
        /// <returns></returns>

        public Boolean SaveRolePermission(List<RoleMenus> roleMenus, List<RoleButtons> roleButtons)
        {
            bool response = true;

            var roleid = roleMenus.FirstOrDefault().RolesId;
            var companyid = roleMenus.FirstOrDefault().CompanysId;

            var rolemenus = GetEntitys<RoleMenus>().Where(x => x.RolesId == roleid && x.CompanysId == companyid).ToList();
            Remove<RoleMenus>(rolemenus.ToArray());


            var listbuttons = GetEntitys<RoleButtons>().Where(x => x.RolesId == roleid && x.CompanysId == companyid).ToList();
            Remove<RoleButtons>(listbuttons.ToArray());

            var rus = Create<RoleMenus>(roleMenus);
            var rbs = Create<RoleButtons>(roleButtons);
            return response;
        }

        /// <summary>
        /// 保存机构授权
        /// </summary>
        /// <param name="organizationMenus"></param>
        /// <param name="organizationButtons"></param>
        /// <returns></returns>
        public Boolean SaveOrganizationPermission(List<OrganizationMenus> organizationMenus, List<OrganizationButtons> organizationButtons)
        {
            bool response = true;

            var oraganizationsId = organizationMenus.FirstOrDefault().OrganizationsId;
            var companyid = organizationMenus.FirstOrDefault().CompanysId;

            var rolemenus = GetEntitys<OrganizationMenus>().Where(x => x.OrganizationsId == oraganizationsId && x.CompanysId == companyid).ToList();
            Remove<OrganizationMenus>(rolemenus.ToArray());

            var listbuttons = GetEntitys<OrganizationButtons>().Where(x => x.OraganizationsId == oraganizationsId && x.CompanysId == companyid).ToList();
            Remove<OrganizationButtons>(listbuttons.ToArray());

            var rus = Create<OrganizationMenus>(organizationMenus);
            var ubs = Create<OrganizationButtons>(organizationButtons);
            return response;
        }
    }
}
