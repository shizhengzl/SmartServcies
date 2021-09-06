using System;
using System.Collections.Generic;
using System.Text;
using Core.FreeSqlServices;
using Core.UsuallyCommon;
using System.Linq;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserServices : SystemServices
    { 
        public UserServices()
        {

        }

        public Response<CurrentUsers> RegisterUser(Users user)
        {
            Response<CurrentUsers> response = new Response<CurrentUsers>() { Success = false };
            CurrentUsers current = new CurrentUsers(); 
            if (user.UserName.IsNullOrEmpty())
            {
                response.Message = "用户名不能为空";
                return response;
            } 
            if (user.PassWord.IsNullOrEmpty())
            {
                response.Message = "密码不能为空";
                return response;
            }
            if (user.Email.IsNullOrEmpty())
            {
                response.Message = "邮箱不能为空";
                return response;
            }
            // check username
            if (UserIsExists(user))
            {
                response.Message = "用户已经存在";
                return response;
            }

            user.DefaultCompany = DefaultCommonEnum.defaultCompany.GetDescription().ToGuid();

            var cusers = this.Create<Users>(user);
            if (cusers.IsNull() || cusers.Id.IsNull()) {
                response.Message = "注册失败";
                return response;
            }

            // add cache  
            current.CurrentUser = GetUsers(user);

            // 获取菜单
            if (IsSupperAdmin(current.CurrentUser))
                current.UserMenus = GetSupperMenus();
            else if (current.CurrentUser.IsAdmin)
                current.UserMenus = GetAdminMenus(current.CurrentUser);
            else
                current.UserMenus = GetUserMenus(current.CurrentUser);

            CacheServices.MemoryCacheManager.SetCache<CurrentUsers>(user.UserName, current, null);
            response.Data = current;
            response.Success = true;
            return response;
        }

        public Response<CurrentUsers> Login(Users user)
        {
            Response<CurrentUsers> response = new Response<CurrentUsers>() { Success = false }; 
            CurrentUsers current = new CurrentUsers();

            if (user.UserName.IsNullOrEmpty())
            {
                response.Message = "用户名不能为空";
                return response;
            }
                
            if (user.PassWord.IsNullOrEmpty())
            { 
                response.Message = "密码不能为空";
                return response;
            }
            // check username
            if (!UserIsExists(user)) {
                response.Message = "用户不存在";
                return response;
            }
            // check password
            if (!ValidPassword(user))
            {
                response.Message = "用户密码不正确";
                return response;
            } 
            // add cache  
            current.CurrentUser = GetUsers(user);

            // 获取菜单
            if(IsSupperAdmin(current.CurrentUser))
                current.UserMenus = GetSupperMenus();
            else if(current.CurrentUser.IsAdmin)
                current.UserMenus = GetAdminMenus(current.CurrentUser);
            else
                current.UserMenus = GetUserMenus(current.CurrentUser);

            CacheServices.MemoryCacheManager.SetCache<CurrentUsers>(user.UserName, current,null);
            response.Data = current;
            response.Success = true;
            return response;
        }

        public bool IsSupperAdmin(Users user)
        {
            var result = false;
            result = user.UserName == "admin";
            return result;
        }

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        public List<Menus> GetUserMenus(Users user)
        {
            var defaultcompany = GetEntitys<Companys>().Where(x => x.Id == user.DefaultCompany).ToList().FirstOrDefault();
            List<Guid> menuids = new List<Guid>();
            switch (defaultcompany.GrantMode)
            {
                case GrantMode.CompanyGrant:
                    menuids = GetEntitys<CompanyMenus>().Where(x => x.CompanysId == user.DefaultCompany).ToList().Select(p => p.MenusId).ToList();
                    break;
                case GrantMode.RoleGrant:
                    // 获取用户角色
                    var uerroles = GetUserRole(user).Select(x=>x.RolesId).ToList();
                    menuids = GetEntitys<RoleMenus>().Where(x => uerroles.Contains(x.RolesId)).ToList().Select(p => p.MenusId).ToList();
                    break;
                case GrantMode.OrganizationGrant:
                    // 获取用户角色
                    var userOrganization = GetUserOrganization(user).Select(x => x.OrganizationsId).ToList();
                    menuids = GetEntitys<OrganizationMenus>().Where(x => userOrganization.Contains(x.OraganizationsId)).ToList().Select(p => p.MenusId).ToList();
                    break;
                case GrantMode.UserGrant:
                    break;
                default:
                    break;
            }
           
            return GetEntitys<Menus>().Where(x => menuids.Contains(x.MenusId)).ToList();
        }

        /// <summary>
        /// 获取用户组织机构
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<OrganizationUsers> GetUserOrganization(Users user)
        {
            return GetEntitys<OrganizationUsers>().Where(x => x.UsersId == user.Id && x.CompanysId == user.DefaultCompany).ToList();
        }


        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<RoleUsers> GetUserRole(Users user)
        {
            return GetEntitys<RoleUsers>().Where(x=>x.UsersId == user.Id && x.CompanysId == user.DefaultCompany).ToList();
        }

        /// <summary>
        /// 获取admin菜单
        /// </summary>
        public List<Menus> GetAdminMenus(Users user)
        {
            var companyId = user.DefaultCompany;
            var menus = GetEntitys<CompanyMenus>().Where(x=>x.CompanysId == companyId).ToList().Select(p=>p.MenusId.ToString().ToUpper()).ToList();
            return GetEntitys<Menus>().Where(x => menus.Contains(x.Id.ToString().ToUpper())).ToList();
        }

        /// <summary>
        /// 获取超级管理员菜单
        /// </summary>
        public List<Menus> GetSupperMenus()
        {
            return GetEntitys<Menus>().ToList();
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users GetUsers(Users user)
        {
            return GetEntitys<Users>().Where(x => (x.UserName == user.UserName || x.Phone == user.UserName || x.Email == user.UserName)
          && x.PassWord == user.PassWord).ToList().FirstOrDefault();
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ValidPassword(Users user)
        {
            return GetEntitys<Users>().Any(x => (x.UserName == user.UserName || x.Phone == user.UserName || x.Email == user.UserName)
            && x.PassWord == user.PassWord);
        } 

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="users"></param>
        public bool UserIsExists(Users user)
        {
            return GetEntitys<Users>().Any(x => x.UserName == user.UserName || x.Phone == user.UserName || x.Email == user.UserName);
        }
    }
}
