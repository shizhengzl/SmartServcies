using Core.FreeSqlServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppSystemServices
{
    /// <summary>
    /// 用户服务
    /// </summary>
    [AppServiceAttribute]
    public class MenuServices : SystemServices
    {

        public MenuServices() : base(DataBaseFactory.Core_Application.FreeSql)
        { 
        
        }

        /// <summary>
        /// 获取单位菜单
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<Menus> GetCompanyMenus(Guid CompanyId )
        {
            return GetEntitys<Menus>().Where(x=>x.CompanysId == CompanyId).ToList();
        }

        public List<Menus> GetSupperMenus()
        {
            return GetEntitys<Menus>().ToList();
        }
        public List<Menus> GetParentMenus()
        {
            return GetEntitys<Menus>().Where(x=>x.Component == "Layout").ToList();
        }

        /// <summary>
        /// 获取单位菜单按钮
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<PermissionButton> GetPermissionButtons(Guid CompanyId)
        {
            return GetEntitys<PermissionButton>().Where(x => x.CompanysId == CompanyId).ToList();
        }

    }
}
