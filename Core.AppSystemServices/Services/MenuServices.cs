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
        public List<Menus> GetSupperMenus()
        {
            return GetEntitys<Menus>().ToList();
        }

    }
}
