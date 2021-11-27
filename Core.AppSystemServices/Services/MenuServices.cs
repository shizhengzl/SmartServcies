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

        public List<Menus> GetSupperMenus()
        {
            return GetEntitys<Menus>().ToList();
        }
        public List<Menus> GetParentMenus()
        {
            return GetEntitys<Menus>().Where(x=>x.Component == "Layout").ToList();
        }
    }
}
