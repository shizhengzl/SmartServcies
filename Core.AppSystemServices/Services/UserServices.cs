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
     [AppServiceAttribute]
    public class UserServices : SystemServices
    { 
        public UserServices():base(DataBaseFactory.Core_Application.FreeSql)
        {

        }

        public Response<CurrentSesscion> RegisterCompany(Users user,string companyName)
        {
            Response<CurrentSesscion> response = new Response<CurrentSesscion>() { Success = false };
            CurrentSesscion current = new CurrentSesscion();
            if (companyName.IsNullOrEmpty())
            {
                response.Message = "单位名不能为空";
                return response;
            }
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
            if (UserIsExists(user))
            {
                response.Message = "用户已经存在";
                return response;
            }

            var company = new Companys() { CompanyName = companyName   };
            this.Create<Companys>(company);
            if (company.Id.IsNull())
                user.CompanysId = company.Id;
            else {
                response.Message = "单位注册失败";
                return response;
            }
            // 默认管理员
            user.IsAdmin = true;
            user.NikeName = user.UserName;
            user.Phone = user.UserName;

            this.Create<Users>(user);
            if (user.Id.IsNull())
            {
                this.Remove<Companys>(company);
                response.Message = "注册失败";
                return response;
            }

            InitDataBase initdata = new InitDataBase();
            initdata.InitRole(company.Id,user.Id,Guid.NewGuid());
            initdata.InitOrganization(company.Id, user.Id,Guid.NewGuid(),company.CompanyName);
            initdata.InitCompanyMenuAndUser(company.Id, user.Id);


            // add cache  
            current.User = GetUsers(user);

            // 获取菜单
            if (IsSupperAdmin(current.User))
                current.UserMenus = GetSupperMenus();
            else if (current.User.IsAdmin)
                current.UserMenus = GetAdminMenus(current.User);
            else
                current.UserMenus = GetUserMenus(current.User);

            CacheServices.MemoryCacheManager.SetCache<CurrentSesscion>(user.UserName, current, null);
            response.Data = current;
            response.Success = true;
            return response;
        }

        public Response<CurrentSesscion> RegisterUser(Users user)
        {
            Response<CurrentSesscion> response = new Response<CurrentSesscion>() { Success = false };
            CurrentSesscion current = new CurrentSesscion(); 
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
            if (UserIsExists(user))
            {
                response.Message = "用户已经存在";
                return response;
            }

            user.CompanysId = DefaultCommonEnum.defaultCompany.GetDescription().ToGuid();
            user.NikeName = user.UserName;
            user.Phone = user.UserName;
            this.Create<Users>(user);
            if (user.Id.IsNull()) {
                response.Message = "注册失败";
                return response;
            }

            // add cache  
            current.User = GetUsers(user);

            // 获取菜单
            if (IsSupperAdmin(current.User))
                current.UserMenus = GetSupperMenus();
            else if (current.User.IsAdmin)
                current.UserMenus = GetAdminMenus(current.User);
            else
                current.UserMenus = GetUserMenus(current.User);

            CacheServices.MemoryCacheManager.SetCache<CurrentSesscion>(user.UserName, current, null);
            response.Data = current;
            response.Success = true;
            return response;
        }

        public Response<CurrentSesscion> Login(Users user)
        {
            Response<CurrentSesscion> response = new Response<CurrentSesscion>() { Success = false };
            CurrentSesscion current = new CurrentSesscion();

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
            current.User = GetUsers(user);

            // 获取菜单
            if(IsSupperAdmin(current.User))
                current.UserMenus = GetSupperMenus();
            else if(current.User.IsAdmin)
                current.UserMenus = GetAdminMenus(current.User);
            else
                current.UserMenus = GetUserMenus(current.User);

            current.Roles = GetUserRoles(current.User);

            CacheServices.MemoryCacheManager.SetCache<CurrentSesscion>(user.UserName, current,null);
            response.Data = current;
            response.Success = true;
            return response;
        }

        public bool IsSupperAdmin(Users user)
        {
            var result = user.UserName == "admin";
            return result;
        }

        /// <summary>
        /// 获取授权菜单
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Menus> GetGrantMenus(Users user,Companys company) 
        {
            List<Menus> response = new List<Menus>();
            // 获取菜单
            if (IsSupperAdmin(user))
                response = GetSupperMenus();
            else
                response = GetCompanyMenus(company);
            return response;
        }

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        public List<Menus> GetUserMenus(Users user)
        {
            var defaultcompany = GetEntitys<Companys>().Where(x => x.Id == user.CompanysId).ToList().FirstOrDefault();
            List<Guid> menuids = new List<Guid>();
            switch (defaultcompany.GrantMode)
            {
                case GrantMode.CompanyGrant:
                    menuids = GetEntitys<CompanyMenus>().Where(x => x.CompanysId == user.CompanysId).ToList().Select(p => p.MenusId).ToList();
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
           
            return GetEntitys<Menus>().Where(x => menuids.Contains(x.Id)).ToList();
        }

        /// <summary>
        /// 获取用户组织机构
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<OrganizationUsers> GetUserOrganization(Users user)
        {
            return GetEntitys<OrganizationUsers>().Where(x => x.UsersId == user.Id && x.CompanysId == user.CompanysId).ToList();
        }


        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<RoleUsers> GetUserRole(Users user)
        {
            return GetEntitys<RoleUsers>().Where(x=>x.UsersId == user.Id && x.CompanysId == user.CompanysId).ToList();
        }



        /// <summary>
        /// 获取单位菜单
        /// </summary>
        public List<Menus> GetCompanyMenus(Companys company)
        {
            var menus = GetEntitys<CompanyMenus>().Where(x => x.CompanysId == company.Id).ToList().Select(p => p.MenusId.ToString().ToUpper()).ToList();
            return GetEntitys<Menus>().Where(x => menus.Contains(x.Id.ToString().ToUpper())).ToList();
        }

        /// <summary>
        /// 获取admin菜单
        /// </summary>
        public List<Menus> GetAdminMenus(Users user)
        {
            var companyId = user.CompanysId;
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
        /// 获取用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Users GetUsers(Guid id)
        {
            return GetEntitys<Users>().Where(x => x.Id == id).ToList().FirstOrDefault();
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ResetPassword(Users user)
        {
            return Modify<Users>(user);
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



        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Roles> GetUserRoles(Users user)
        {
            var roleids = GetEntitys<RoleUsers>().Where(x => x.CompanysId == user.CompanysId && x.UsersId == user.Id).ToList().Select(p => p.RolesId);
            return GetEntitys<Roles>().Where(x => roleids.Contains(x.Id)).ToList();
        }

    }
}
