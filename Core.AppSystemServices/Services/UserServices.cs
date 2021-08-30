using System;
using System.Collections.Generic;
using System.Text;
using Core.FreeSqlServices;
using Core.UsuallyCommon;
using System.Linq;

namespace Core.AppSystemServices.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserServices : SystemServices
    { 
        public UserServices()
        {

        }

     

        public Response<String> Login(Users user)
        {
            Response<String> response = new Response<string>(); 
            CurrentUsers current = new CurrentUsers();

            // check username
            if (!UserIsExists(user))
                response.Data = "用户不存在";
            // check password
            if (!ValidPassword(user))
                response.Data = "用户密码不正确";
            // add cache  
            current.CurrentUser = GetUsers(user);

            // 获取菜单
            if(IsSupperAdmin(user))
                current.UserMenus = GetSupperMenus();
            else
                current.UserMenus = GetSupperMenus();

            CacheServices.MemoryCacheManager.SetCache<CurrentUsers>(user.UserName, current,null);

            return response;
        }

        public bool IsSupperAdmin(Users user)
        {
            var result = false;
            result = user.UserName == "admin";
            return result;
        }

        ///// <summary>
        ///// 获取用户菜单
        ///// </summary>
        //public List<Menus> GetSupperMenus(Users user)
        //{
        //    var companyId = user.DefaultCompany;
        //}

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
