using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 登录缓存
    /// </summary>
    public class CurrentSesscion
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public Users User {  get; set; }
        
        /// <summary>
        /// 所有单位
        /// </summary>
        public List<Companys> UserCompanys { get; set; }

        /// <summary>
        /// 所有菜单
        /// </summary>
        public List<Menus> UserMenus { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public List<Roles> Roles {  get; set; } 
    }
}
